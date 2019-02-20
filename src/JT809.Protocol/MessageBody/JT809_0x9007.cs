using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路断开通知消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_DISCONNECT_INFORM</para>
    /// <para>描述:
    /// 情景 1:上级平台与下级平台的从链路中断后，重连二次仍未成功时，上级平台通过主链路发送本消息给下级平台。
    /// 情景 2:上级平台作为客户端向下级平台登录时，根据之前收到的 IP 地址及端口无法连接到下级平台服务端时发送本消息通知下级平台。
    /// </para>
    /// <para>本条消息无需被通知方应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9007Formatter))]
    public class JT809_0x9007:JT809Bodies
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x9007_ReasonCode ReasonCode { get; set; }
    }
}
