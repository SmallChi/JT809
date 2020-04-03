using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路车辆动态信息交换业务
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_EXG_MSG</para>
    /// <para>描述:上级平台作为客户端向下级平台服务端发送车辆动态信息交换业务</para>
    /// </summary>
    public class JT809_0x9200: JT809ExchangeMessageBodies
    {
        public override ushort MsgId => JT809BusinessType.从链路车辆动态信息交换业务.ToUInt16Value();
        public override string Description => "从链路车辆动态信息交换业务";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
    }
}
