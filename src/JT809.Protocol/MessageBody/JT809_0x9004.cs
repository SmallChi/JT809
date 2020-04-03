using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路注销应答消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型构之识:DOWN_DISCONNECT_RSP</para>
    /// <para>描述:下级平台在收到上级平台发送的从链路注销请求消息后，返回从链路注销应答消息，记录相关日志，中断该从链路</para>
    /// <para>从链路注销应答消息，数据体为空</para>
    /// </summary>
    public class JT809_0x9004:JT809Bodies
    {
        public override ushort MsgId => JT809BusinessType.从链路注销应答消息.ToUInt16Value();
        public override string Description => "从链路注销应答消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
    }
}
