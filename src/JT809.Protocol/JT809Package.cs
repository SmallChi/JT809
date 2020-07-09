using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT809.Protocol
{
    public class JT809Package:IJT809MessagePackFormatter<JT809Package>, IJT809Analyze, IJT809_2019_Version
    {
        public const byte BEGINFLAG = 0X5B;

        public const byte ENDFLAG = 0X5D;

        /// <summary>
        /// 固定为26个字节长度
        /// <para>Head flag + Message Header + CRC Code + End Flag</para>
        /// <para>1 + 22 + 2 + 1 = 26</para>
        /// </summary>
        public const int FixedByteLength = 26;
        /// <summary>
        /// 固定为26个字节长度
        /// <para>Head flag + Message Header + CRC Code + End Flag</para>
        /// <para>1 + 30 + 2 + 1 = 26</para>
        /// </summary>
        public const int FixedByteLength_2019 = 34;

        public byte BeginFlag { get; set; } = BEGINFLAG;

        public JT809Header Header { get; set; }

        public JT809Bodies Bodies { get; set; }

        public ushort CRCCode { get; set; }

        public byte EndFlag { get; set; } = ENDFLAG;

        public JT809Package Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            // 1. 验证校验码
            if (!config.SkipCRCCode)
            {
                //  1.2. 验证校验码
                if (!reader.CheckXorCodeVali)
                {
                    throw new JT809Exception(JT809ErrorCode.CRC16CheckInvalid, $"{reader.CalculateCheckXorCode}!={reader.RealCheckXorCode}");
                }
            }
            JT809Package jT809Package = new JT809Package();
            // 2.读取起始头
            jT809Package.BeginFlag = reader.ReadStart();
            // 3.初始化消息头
            try
            {
                jT809Package.Header = config.GetMessagePackFormatter<JT809Header>().Deserialize(ref reader, config);
            }
            catch (Exception ex)
            {
                throw new JT809Exception(JT809ErrorCode.HeaderParseError, $"offset>{reader.ReadCurrentRemainContentLength()}", ex);
            }
            // 5.数据体处理
            //  5.1 判断是否有数据体（总长度-固定长度）> 0
            int fixedByteLength = config.Version == JT809Version.JTT2019 ? FixedByteLength_2019 : FixedByteLength;
            if ((jT809Package.Header.MsgLength - fixedByteLength) > 0)
            {
                if (config.BusinessTypeFactory.TryGetValue(jT809Package.Header.BusinessType, config.Version, out object instance))
                {
                    try
                    {
                        // 5.2 是否加密
                        switch (jT809Package.Header.EncryptFlag)
                        {
                            case JT809Header_Encrypt.None:
                                // 5.3 处理消息体
                                jT809Package.Bodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(instance,ref reader, config);
                                break;
                            case JT809Header_Encrypt.Common:
                                // 5.4. 处理加密消息体
                                byte[] bodiesData = config.Encrypt.Decrypt(reader.ReadContent(), config.EncryptOptions, jT809Package.Header.EncryptKey);
                                JT809MessagePackReader bodiesReader = new JT809MessagePackReader(bodiesData);
                                jT809Package.Bodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(instance,ref bodiesReader, config);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new JT809Exception(JT809ErrorCode.BodiesParseError, $"offset>{reader.ReadCurrentRemainContentLength().ToString()}", ex);
                    }
                }
            }

            jT809Package.CRCCode = reader.ReadUInt16();
            jT809Package.EndFlag = reader.ReadEnd();
            return jT809Package;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809Package value, IJT809Config config)
        {
            // -----------开始组包----------
            // 1.起始符
            writer.WriteByte(value.BeginFlag);
            // 2.写入头部数据
            //  2.1.跳过数据长度的写入
            writer.Skip(4, out int lengthPosition);
            //  2.2.报文序列号
            value.Header.MsgSN = value.Header.MsgSN > 0 ? value.Header.MsgSN : config.MsgSNDistributed.Increment();
            writer.WriteUInt32(value.Header.MsgSN);
            //  2.3.业务数据类型
            writer.WriteUInt16(value.Header.BusinessType);
            //  2.4.下级平台接入码
            writer.WriteUInt32(value.Header.MsgGNSSCENTERID);
            //  2.5.版本号
            writer.WriteArray(value.Header.Version.Buffer);
            //  2.6.报文加密
            writer.WriteByte((byte)value.Header.EncryptFlag);
            //  2.7.数据加密密钥
            writer.WriteUInt32(value.Header.EncryptKey);
            if(config.Version== JT809Version.JTT2019)
            {
                // 2.8.UTC时间戳
                writer.WriteUTCDateTime(value.Header.Time);
            }
            // 3.写入数据体
            //  3.1.记录当前开始位置
            int startIndex = writer.GetCurrentPosition();
            //  3.2.写入数据对应数据体
            if (value.Bodies != null)
            {
                JT809MessagePackFormatterResolverExtensions.JT809DynamicSerialize(value.Bodies,ref writer, value.Bodies,config);
            }
            //  3.3.记录当前结束位置
            int endIndex = writer.GetCurrentPosition();
            int contentLength = endIndex - startIndex;
            if (contentLength > 0)
            {
                // 3.4. 数据加密
                switch (value.Header.EncryptFlag)
                {
                    case JT809Header_Encrypt.None:
                        break;
                    case JT809Header_Encrypt.Common:
                        // 3.5. 提取数据体并进行加密处理
                        byte[] messageBodyDatEncrypted = config.Encrypt.Encrypt(writer.Extract(startIndex), config.EncryptOptions, value.Header.EncryptKey);
                        int flagLength = messageBodyDatEncrypted.Length - contentLength;
                        if (flagLength == 0)
                        {
                            // 相等复制
                            writer.CopyTo(messageBodyDatEncrypted, startIndex);
                        }
                        else if (flagLength > 0)
                        {
                            // 扩容
                            writer.Skip(flagLength, out _);
                            writer.CopyTo(messageBodyDatEncrypted, startIndex);
                        }
                        else
                        {
                            // 缩减
                            writer.CopyTo(messageBodyDatEncrypted, startIndex);
                            writer.Shrink(-flagLength);
                        }
                        break;
                }
            }
            // 4.计算内容的总长度(校验码2+终止符1=3)
            writer.WriteInt32Return(writer.GetCurrentPosition() + 3, lengthPosition);
            // 5.校验码
            writer.WriteCRC16();
            // 6.终止符
            writer.WriteByte(value.EndFlag);
            // 7.转义
            writer.WriteEncode();
            // -----------组包完成----------
        }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809Package jT809Package = new JT809Package();
            writer.WriteStartObject();
            // 2.读取起始头
            jT809Package.BeginFlag = reader.ReadStart();
            writer.WriteNumber($"[{jT809Package.BeginFlag.ReadNumber()}]起始标识", jT809Package.BeginFlag);
            // 3.初始化消息头
            JT809Header jT809Header=new JT809Header();
            writer.WriteStartObject("消息头");
            try
            {
                jT809Header.MsgLength = reader.ReadUInt32();
                writer.WriteNumber($"[{jT809Header.MsgLength.ReadNumber()}]数据长度", jT809Header.MsgLength);
                jT809Header.MsgSN = reader.ReadUInt32();
                writer.WriteNumber($"[{jT809Header.MsgSN.ReadNumber()}]报文序列号", jT809Header.MsgSN);
                jT809Header.BusinessType = reader.ReadUInt16();
                writer.WriteString($"[{jT809Header.BusinessType.ReadNumber()}]业务类型标识", ((JT809BusinessType)jT809Header.BusinessType).ToString());
                jT809Header.MsgGNSSCENTERID = reader.ReadUInt32();
                writer.WriteNumber($"[{jT809Header.MsgGNSSCENTERID.ReadNumber()}]下级平台接入码", jT809Header.MsgGNSSCENTERID);
                var virtualHex = reader.ReadVirtualArray(JT809Header_Version.FixedByteLength);
                jT809Header.Version = new JT809Header_Version(reader.ReadArray(JT809Header_Version.FixedByteLength));
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]协议版本号标识", jT809Header.Version.ToString());
                jT809Header.EncryptFlag = (JT809Header_Encrypt)reader.ReadByte();
                writer.WriteString($"[{ jT809Header.EncryptFlag.ToByteValue()}]报文加密标识位", jT809Header.EncryptFlag.ToString());
                jT809Header.EncryptKey = reader.ReadUInt32();
                writer.WriteNumber($"[{jT809Header.EncryptKey.ReadNumber()}]数据加密的密匙", jT809Header.EncryptKey);
                if (config.Version == JT809Version.JTT2019)
                {
                    virtualHex = reader.ReadVirtualArray(8);
                    jT809Header.Time = reader.ReadUTCDateTime();
                    writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]发送消息时的系统UTC时间", jT809Header.Time);
                }
            }
            catch (Exception ex)
            {
                writer.WriteString($"[{(int)JT809ErrorCode.HeaderParseError}]消息头异常", $"offset>{reader.ReadCurrentRemainContentLength()},异常消息：{ex.Message}");
            }
            writer.WriteEndObject();
            writer.WriteStartObject("消息体");
            // 5.数据体处理
            //  5.1 判断是否有数据体（总长度-固定长度）> 0
            int fixedByteLength = config.Version == JT809Version.JTT2019 ? FixedByteLength_2019 : FixedByteLength;
            if ((jT809Header.MsgLength - fixedByteLength) > 0)
            {
                if (config.BusinessTypeFactory.TryGetValue(jT809Header.BusinessType, config.Version, out object instance))
                {
                    try
                    {
                      
                        // 5.2 是否加密
                        switch (jT809Header.EncryptFlag)
                        {
                            case JT809Header_Encrypt.None:
                                // 5.3 处理消息体
                          
                                instance.Analyze(ref reader, writer, config);
                                break;
                            case JT809Header_Encrypt.Common:
                                // 5.4. 处理加密消息体
                                byte[] bodiesData = config.Encrypt.Decrypt(reader.ReadContent(), config.EncryptOptions, jT809Header.EncryptKey);
                                JT809MessagePackReader bodiesReader = new JT809MessagePackReader(bodiesData);
                                instance.Analyze(ref bodiesReader, writer, config);
                                break;
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        writer.WriteString($"[{(int)JT809ErrorCode.BodiesParseError}]消息体异常", $"offset>{reader.ReadCurrentRemainContentLength()},异常消息：{ex.Message}");
                    }
                }         
            }
            writer.WriteEndObject();
            jT809Package.CRCCode = reader.ReadUInt16();
            writer.WriteNumber($"[{jT809Package.CRCCode.ReadNumber()}]校验码", jT809Package.CRCCode);
            // 1. 验证校验码
            if (!config.SkipCRCCode)
            {
                //  1.2. 验证校验码
                if (!reader.CheckXorCodeVali)
                {
                    writer.WriteString($"[{(int)JT809ErrorCode.CRC16CheckInvalid}]校验码异常", $"{reader.CalculateCheckXorCode}!={reader.RealCheckXorCode}");
                }
            }
            jT809Package.EndFlag = reader.ReadEnd();
            writer.WriteNumber($"[{jT809Package.EndFlag.ReadNumber()}]结束标识", jT809Package.EndFlag);
            writer.WriteEndObject();
        }
    }
}
