using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.Internal;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters
{
    public class JT809PackageFormatter : IJT809MessagePackFormatter<JT809Package>
    {
        public readonly static JT809PackageFormatter Instance = new JT809PackageFormatter();
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
            JT809Package jT809Package = new JT809Package
            {
                // 2.读取起始头
                BeginFlag = reader.ReadStart()
            };
            // 3.初始化消息头
            try
            {
                jT809Package.Header = JT809HeaderFormatter.Instance.Deserialize(ref reader, config);
            }
            catch (Exception ex)
            {
                throw new JT809Exception(JT809ErrorCode.HeaderParseError, $"offset>{reader.ReadCurrentRemainContentLength()}", ex);
            }
            // 5.数据体处理
            //  5.1 判断是否有数据体（总长度-固定长度）> 0
            if ((jT809Package.Header.MsgLength - JT809Package.FixedByteLength) > 0)
            {
                try
                {
                    Type jT809BodiesImplType = config.BusinessTypeFactory.GetBodiesImplTypeByBusinessType(jT809Package.Header.BusinessType, jT809Package.Header.MsgGNSSCENTERID);
                    if (jT809BodiesImplType != null)
                    {
                        // 5.2 是否加密
                        switch (jT809Package.Header.EncryptFlag)
                        {
                            case JT809Header_Encrypt.None:
                                // 5.3 处理消息体
                                jT809Package.Bodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                 config.GetMessagePackFormatterByType(jT809BodiesImplType),
                                 ref reader, config);
                                break;
                            case JT809Header_Encrypt.Common:
                                // 5.4. 处理加密消息体
                                byte[] bodiesData = config.Encrypt.Decrypt(reader.ReadContent(), config.EncryptOptions, jT809Package.Header.EncryptKey);
                                JT809MessagePackReader bodiesReader = new JT809MessagePackReader(bodiesData);
                                jT809Package.Bodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                                                 config.GetMessagePackFormatterByType(jT809BodiesImplType),
                                                                 ref bodiesReader, config);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new JT809Exception(JT809ErrorCode.BodiesParseError, $"offset>{reader.ReadCurrentRemainContentLength()}", ex);
                }
            }
            jT809Package.CRCCode = reader.CalculateCheckXorCode;
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
            // 2.8 发送消息时系统UTC时间
            writer.WriteUTCDateTime(value.Header.Time);
            // 3.写入数据体
            //  3.1.记录当前开始位置
            int startIndex = writer.GetCurrentPosition();
            //  3.2.写入数据对应数据体
            if (value.Bodies != null)
            {
                JT809MessagePackFormatterResolverExtensions.JT809DynamicSerialize(
                           config.GetMessagePackFormatterByType(value.Bodies.GetType()),
                           ref writer, value.Bodies,
                           config);
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
    }
}
