
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路报警信息交互消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_WARN_MSG</para>
    /// <para>描述：上级平台向下级平台发送报瞥信息业务</para>
    /// </summary>
    public class JT809_0x9400: JT809ExchangeMessageBodies
    {
        public override ushort MsgId => JT809BusinessType.从链路报警信息交互消息.ToUInt16Value();
        public override string Description => "从链路报警信息交互消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
    }
}
