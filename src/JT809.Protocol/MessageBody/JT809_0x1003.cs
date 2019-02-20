using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路注销请求消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向：下级平台往上级平台</para>
    /// <para>业务数据类型标识：UP-DISCONNECT-REQ</para>
    /// <para>描述：下级平台在中断与上级平台的主链路连接时，应向上级平台发送主链路注销请求消息。</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1003Formatter))]
    public class JT809_0x1003 : JT809Bodies
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public uint UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
