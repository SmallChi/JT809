using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路连接请求消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_CONNECT_REQ</para>
    /// <para>描述:主链路建立连接后，上级平台向下级平台发送从链路连接清求消息，以建立从链路连接</para>
    /// <para>下级平台在收到本息后，根据本校验码 VERIFY CODE 来实现数据的校验，校验后，则返回DOWN CONNECT RSP 消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9001_Formatter))]
    public class JT809_0x9001 : JT809Bodies
    {
        /// <summary>
        /// 4.5.1.2 对应的校验码
        /// </summary>
        public uint VerifyCode { get; set; }
    }
}
