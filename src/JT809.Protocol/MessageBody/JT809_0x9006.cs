using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路连接保持应答消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_LINKTEST_REP</para>
    /// <para>描述:下级平台收到上级平台链路连接保持请求消息后，向上级平台返回从链路连接保持应答消息，保持从链路连接状态</para>
    /// <para>从链路连接保持应答消息，数据体为空</para>
    /// </summary>
    public class JT809_0x9006:JT809Bodies
    {
        public override ushort MsgId => JT809BusinessType.从链路连接保持应答消息.ToUInt16Value();
        public override string Description => "从链路连接保持应答消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
    }
}
