using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路断开通知消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_DISCONNECT_INFORM</para>
    /// <para>描述:'当主链路中断后，下级平台可通过从链路向上级平台发送本消息通知上级平台主链路中断</para>
    /// <para>主链路连接保持应答消息,数据体为空</para>
    /// <para>本条消息无需被通知方应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1007_Formatter))]
    public class JT809_0x1007:JT809Bodies
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x1007_ErrorCode ErrorCode { get; set; }
    }
}
