using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路注销应答消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:UP_DISCONNECT_RSP</para>
    /// <para>描述:上级平台收到下级平台发送的主链路注销请求消息后，向下级平台返回主链路注销应答消息，并记录链路注销日志，下级平台接收到应答消息后，可中断主从链路联接。</para>
    /// <para>主链路注销应答消息，数据体为空。</para>
    /// </summary>
    public class JT809_0x1004 : JT809Bodies
    {
        public override bool SkipSerialization => true;
        public override ushort MsgId => JT809BusinessType.主链路注销应答消息.ToUInt16Value();
        public override string Description => "主链路注销应答消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;
    }
}
