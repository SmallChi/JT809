using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// JT809头部数据包
    /// </summary>
    public class JT809HeaderPackage: IJT809MessagePackFormatter<JT809HeaderPackage>
    {
        public byte BeginFlag { get; set; } = JT809Package.BEGINFLAG;

        public JT809Header Header { get; set; }

        public byte[] Bodies { get; set; }

        public ushort CRCCode { get; set; }

        public byte EndFlag { get; set; } = JT809Package.ENDFLAG;

        public JT809HeaderPackage Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            // 1. 验证校验码
            if (!config.SkipCRCCode)
            {
                //  1.2. 验证校验码
                if (!reader.CheckXorCodeVali)
                {
                    throw new JT809Exception(JT809ErrorCode.CRC16CheckInvalid, $"{reader.CalculateCheckXorCode.ToString()}!={reader.RealCheckXorCode.ToString()}");
                }
            }
            JT809HeaderPackage jT809Package = new JT809HeaderPackage();
            // 2.读取起始头
            jT809Package.BeginFlag = reader.ReadStart();
            // 3.初始化消息头
            try
            {
                jT809Package.Header = config.GetMessagePackFormatter<JT809Header>().Deserialize(ref reader, config);
            }
            catch (Exception ex)
            {
                throw new JT809Exception(JT809ErrorCode.HeaderParseError, $"offset>{reader.ReadCurrentRemainContentLength().ToString()}", ex);
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
