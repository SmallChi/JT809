using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;

namespace JT809.Protocol.Formatters
{
    public class JT809HeaderPackageFormatter : IJT809MessagePackFormatter<JT809HeaderPackage>
    {
        public readonly static JT809HeaderPackageFormatter Instance = new JT809HeaderPackageFormatter();
        public JT809HeaderPackage Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
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
            JT809HeaderPackage jT809Package = new JT809HeaderPackage
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
                    // 5.2 是否加密
                    switch (jT809Package.Header.EncryptFlag)
                    {
                        case JT809Header_Encrypt.None:
                            // 5.3 处理消息体
                            jT809Package.Bodies = reader.ReadContent().ToArray();
                            break;
                        case JT809Header_Encrypt.Common:
                            // 5.4. 处理加密消息体
                            byte[] bodiesData = config.Encrypt.Decrypt(reader.ReadContent(), config.EncryptOptions, jT809Package.Header.EncryptKey);
                            jT809Package.Bodies = bodiesData;
                            break;
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

        public void Serialize(ref JT809MessagePackWriter writer, JT809HeaderPackage value, IJT809Config config)
        {
            throw new NotImplementedException("只适用反序列化");
        }
    }
}
