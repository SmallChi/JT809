
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路静态信息交换消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级台</para>
    /// <para>业务数据类型标识:DOWN_BASE_MSG</para>
    /// <para>描述:上级平台向下级平台发送车辆静态信息交换业务</para>
    /// </summary>
    public class JT809_0x9600: JT809ExchangeMessageBodies
    {
        public override ushort MsgId => JT809BusinessType.从链路静态信息交换消息.ToUInt16Value();
        public override string Description => "从链路静态信息交换消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
    }
}
