using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters
{
    public class JT809PackageFormatter : IJT809Formatter<JT809Package>
    {
        public JT809Package Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809Package jT809Package = new JT809Package();
            // 转义还原——>验证校验码——>解析消息
            // 1. 解码（转义还原）
            ReadOnlySpan<byte> buffer = JT809Util.JT809DeEscape(bytes);
            // 2. 验证校验码
            //  2.1. 获取校验位索引
            int checkIndex = buffer.Length - 3;
            //  2.2. 获取校验码
            int crcCodeOffset = 0;
            jT809Package.CRCCode = JT809BinaryExtensions.ReadUInt16Little(buffer.Slice(checkIndex,2),ref crcCodeOffset);
            if (!JT809GlobalConfig.Instance.SkipCRCCode)
            {
                //  2.3. 从消息头到校验码前一个字节
                ushort checkCode = buffer.ToCRC16_CCITT(1, checkIndex);
                //  2.4. 验证校验码
                if (jT809Package.CRCCode != checkCode)
                {
                    throw new JT809Exception(JT809ErrorCode.CRC16CheckInvalid, $"{jT809Package.CRCCode.ToString()}!={checkCode.ToString()}");
                }
            }
            jT809Package.BeginFlag = JT809BinaryExtensions.ReadByteLittle(buffer, ref offset);
            // 3.初始化消息头
            try
            {
                jT809Package.Header = JT809FormatterExtensions.GetFormatter<JT809Header>().Deserialize(buffer.Slice(offset, JT809Header.FixedByteLength), out readSize);
            }
            catch (Exception ex)
            {
                throw new JT809Exception(JT809ErrorCode.HeaderParseError, $"offset>{offset.ToString()}", ex);
            }
            offset += readSize;
            // 5.数据体处理
            //  5.1 判断是否有数据体（总长度-固定长度）> 0
            if ((jT809Package.Header.MsgLength - JT809Package.FixedByteLength) > 0)
            {
                //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
                JT809BodiesTypeAttribute jT809BodiesTypeAttribute = jT809Package.Header.BusinessType.GetAttribute<JT809BodiesTypeAttribute>();
                if (jT809BodiesTypeAttribute != null)
                {
                    try
                    {
                        // 5.2 是否加密
                        switch (jT809Package.Header.EncryptFlag)
                        {
                            case JT809Header_Encrypt.None:
                                //5.3 处理消息体
                                jT809Package.Bodies = JT809FormatterResolverExtensions.JT809DynamicDeserialize(JT809FormatterExtensions.GetFormatter(jT809BodiesTypeAttribute.JT809BodiesType), buffer.Slice(offset, checkIndex - offset), out readSize);
                                break;
                            case JT809Header_Encrypt.Common:
                                byte[] bodiesData = JT809GlobalConfig.Instance.Encrypt.Decrypt(buffer.Slice(offset, checkIndex - offset).ToArray(), jT809Package.Header.EncryptKey);
                                jT809Package.Bodies = JT809FormatterResolverExtensions.JT809DynamicDeserialize(JT809FormatterExtensions.GetFormatter(jT809BodiesTypeAttribute.JT809BodiesType), bodiesData, out readSize);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new JT809Exception(JT809ErrorCode.BodiesParseError,$"offset>{offset.ToString()}", ex);
                    }
                }
            }
            jT809Package.EndFlag = buffer[buffer.Length - 1];
            readSize = buffer.Length;
            return jT809Package;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809Package value)
        {
            // 1. 先序列化数据体，根据数据体的长度赋值给头部，在序列化头部。
            int messageBodyOffset = 0;
            JT809BodiesTypeAttribute jT809BodiesTypeAttribute = value.Header.BusinessType.GetAttribute<JT809BodiesTypeAttribute>();
            if (jT809BodiesTypeAttribute != null)
            {
                if (value.Bodies != null)
                {
                    // 1.1 处理数据体
                    messageBodyOffset = JT809FormatterResolverExtensions.JT809DynamicSerialize(JT809FormatterExtensions.GetFormatter(jT809BodiesTypeAttribute.JT809BodiesType), ref bytes, messageBodyOffset, value.Bodies);
                }
            }
            byte[] messageBodyData=null;
            if (messageBodyOffset != 0)
            {
                messageBodyData = bytes.AsSpan(0, messageBodyOffset).ToArray();
                // 1.2 数据加密
                switch (value.Header.EncryptFlag)
                {
                    case JT809Header_Encrypt.None:
                        break;
                    case JT809Header_Encrypt.Common:
                        messageBodyData = JT809GlobalConfig.Instance.Encrypt.Encrypt(messageBodyData, value.Header.EncryptKey);
                        break;
                }
            }
            // ------------------------------------开始组包
            // 1.起始符
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.BeginFlag);
            // 2.赋值头数据长度
            if (messageBodyOffset != 0)
            {
                value.Header.MsgLength = (uint)(JT809Package.FixedByteLength + messageBodyData.Length);
            }
            else
            {
                value.Header.MsgLength = JT809Package.FixedByteLength;
            }
            // 2.1写入头部数据
            offset = JT809FormatterExtensions.GetFormatter<JT809Header>().Serialize(ref bytes, offset, value.Header);
            if (messageBodyOffset != 0)
            {
                // 3. 写入数据体
                Array.Copy(messageBodyData, 0, bytes, offset, messageBodyData.Length);
                offset += messageBodyData.Length;
                messageBodyData = null;
            }
            // 4.校验码
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, bytes.ToCRC16_CCITT(1, offset));
            // 5.终止符
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.EndFlag);
            // 6.转义
            return JT809Util.JT809Escape(ref bytes, offset);
        }
    }
}
