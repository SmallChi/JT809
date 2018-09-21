using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 从链路连接应答信息
    /// <para>链路类型:从链路</para>
    /// <para>消息方问:下级平台往上级平台</para>
    /// <para>业务数据类型标识:DOWN_CONNNECT_RSP</para>
    /// <para>描述：下级平台作为服务器端向上级平台客户端返回从链路连接应答消息，上级平台在接收到该应答消息结果后</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9002Formatter))]
    public class JT809_0x9002:JT809Bodies
    {
        /// <summary>
        /// 验证结果
        /// </summary>
        public JT809_0x9002_Result Result { get; set; }
    }
}
