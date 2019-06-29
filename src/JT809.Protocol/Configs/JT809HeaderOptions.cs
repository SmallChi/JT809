using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Configs
{
    public class JT809HeaderOptions
    {
        /// <summary>
        /// 下级平台接入码，上级平台给下级平台分配唯一标识码。
        /// </summary>
        public uint MsgGNSSCENTERID { get; set; }
        /// <summary>
        /// 协议版本号标识，上下级平台之间采用的标准协议版
        /// 编号；长度为 3 个字节来表示，0x01 0x02 0x0F 标识
        /// 的版本号是 v1.2.15，以此类推。
        /// </summary>
        public JT809Header_Version Version { get; set; } = new JT809Header_Version();
        /// <summary>
        /// 报文加密标识位 b: 0 表示报文不加密，1 表示报文加密。
        /// </summary>
        public JT809Header_Encrypt EncryptFlag { get; set; } = JT809Header_Encrypt.None;
        /// <summary>
        /// 数据加密的密匙，长度为 4 个字节
        /// </summary>
        public uint EncryptKey { get; set; }
    }
}
