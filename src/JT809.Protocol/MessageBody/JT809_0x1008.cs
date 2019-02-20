using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 下级平台主动关闭主从链路通知消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_CLOSELINIC INFORM</para>
    /// <para>描述:下级平台作为服务端，发现从链路出现异常时，下级平台通过从链路向上级平台发送本消息，通知上级平台下级平台即将关闭主从链路</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1008Formatter))]
    public class JT809_0x1008:JT809Bodies
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x1008_ReasonCode ReasonCode { get; set; }
    }
}
