using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using System;

namespace JT809.Protocol.Formatters
{
    public class JT809HeaderPackageFromatter : IJT809Formatter<JT809HeaderPackage>
    {
        public JT809HeaderPackage Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809HeaderPackage jT809HeaderPackage = new JT809HeaderPackage();
            // 转义还原——>验证校验码——>解析消息
            // 1. 解码（转义还原）
            ReadOnlySpan<byte> buffer = JT809Util.JT809DeEscape(bytes);
            // 2. 验证校验码
            //  2.1. 获取校验位索引
            int checkIndex = buffer.Length - 3;
            //  2.2. 获取校验码
            int crcCodeOffset = 0;
            jT809HeaderPackage.CRCCode = JT809BinaryExtensions.ReadUInt16Little(buffer.Slice(checkIndex, 2), ref crcCodeOffset);
            if (!JT809GlobalConfig.Instance.SkipCRCCode)
            {
                //  2.3. 从消息头到校验码前一个字节
                ushort checkCode = buffer.ToCRC16_CCITT(1, checkIndex);
                //  2.4. 验证校验码
                if (jT809HeaderPackage.CRCCode != checkCode)
                {
                    throw new JT809Exception(JT809ErrorCode.CRC16CheckInvalid, $"{jT809HeaderPackage.CRCCode.ToString()}!={checkCode.ToString()}");
                }
            }
            jT809HeaderPackage.BeginFlag = JT809BinaryExtensions.ReadByteLittle(buffer, ref offset);
            // 3.初始化消息头
            try
            {
                jT809HeaderPackage.Header = JT809FormatterExtensions.GetFormatter<JT809Header>().Deserialize(buffer.Slice(offset, JT809Header.FixedByteLength), out readSize);
            }
            catch (Exception ex)
            {
                throw new JT809Exception(JT809ErrorCode.HeaderParseError, $"offset>{offset.ToString()}", ex);
            }
            offset += readSize;
            // 5.数据体处理
            //  5.1 判断是否有数据体（总长度-固定长度）> 0
            if ((jT809HeaderPackage.Header.MsgLength - JT809Package.FixedByteLength) > 0)
            {
                //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
                JT809BodiesTypeAttribute jT809BodiesTypeAttribute = jT809HeaderPackage.Header.BusinessType.GetAttribute<JT809BodiesTypeAttribute>();
                if (jT809BodiesTypeAttribute != null)
                {
                    try
                    {
                        // 5.2 是否加密
                        switch (jT809HeaderPackage.Header.EncryptFlag)
                        {
                            case JT809Header_Encrypt.None:
                                //5.3 处理消息体
                                jT809HeaderPackage.Bodies = buffer.Slice(offset, checkIndex - offset).ToArray();
                                break;
                            case JT809Header_Encrypt.Common:
                                byte[] bodiesData = JT809GlobalConfig.Instance.Encrypt.Decrypt(buffer.Slice(offset, checkIndex - offset).ToArray(), jT809HeaderPackage.Header.EncryptKey);
                                jT809HeaderPackage.Bodies = bodiesData;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new JT809Exception(JT809ErrorCode.BodiesParseError, $"offset>{offset.ToString()}", ex);
                    }
                }
            }
            jT809HeaderPackage.EndFlag = buffer[buffer.Length - 1];
            readSize = buffer.Length;
            return jT809HeaderPackage;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809HeaderPackage value)
        {
            throw new NotImplementedException("只适用反序列化");
        }
    }
}
