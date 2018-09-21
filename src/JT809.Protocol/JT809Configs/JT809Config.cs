using JT809.Protocol.ProtocolPacket;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Configs
{
    public class JT809Config
    {
        public JT809Config() { }

        public JT809Config(uint sessionId, JT809Version jt809Version)
        {
            SessionId = sessionId;
            JT809Version = jt809Version;
        }

        public JT809Config(uint sessionId, JT809Version jt809Version, JT809EncryptConfig encryptConfig)
        {
            SessionId = sessionId;
            JT809Version = jt809Version;
            JT809EncryptConfig = encryptConfig;
        }

        /// <summary>
        /// 下级平台接入码，上级平台给下级平台分配唯一标识码。
        /// </summary>
        public uint SessionId { get; set; }

        /// <summary>
        /// 加密配置
        /// </summary>
        public JT809EncryptConfig JT809EncryptConfig { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public JT809Version JT809Version { get; set; } = new JT809Version();
    }
}
