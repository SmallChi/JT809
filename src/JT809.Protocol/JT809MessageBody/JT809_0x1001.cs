using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 主链路登录请求消息
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1001Formatter))]
    public class JT809_0x1001: JT809Bodies
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public uint UserId { get; set; }
        /// <summary>
        /// 密码
        /// 8位
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 下级平台提供对应的从链路服务端 IP 地址
        /// 32位
        /// </summary>
        public string DownLinkIP { get; set; }
        /// <summary>
        /// 下级平台提供对应的从链路服务器端口号
        /// </summary>
        public ushort DownLinkPort { get; set; }
    }
}
