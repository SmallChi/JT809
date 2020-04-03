using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路连接保持应答消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:UP_LINKTEST_RSP。</para>
    /// <para>描述:上级平台收到下级平台的主链路连接保持请求消息后，向下级平台返回.主链路连接保持应答消息，保持主链路的连接状态。</para>
    /// <para>主链路连接保持应答消息,数据体为空。</para>
    /// </summary>
    public class JT809_0x1006:JT809Bodies
    {
        public override bool SkipSerialization => true;
        public override ushort MsgId => JT809BusinessType.主链路连接保持应答消息.ToUInt16Value();
        public override string Description => "主链路连接保持应答消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;
    }
}
