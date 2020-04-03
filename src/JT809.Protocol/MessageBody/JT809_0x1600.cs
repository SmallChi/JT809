using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路静态信息交换消息
    /// <para>链路类型:主链路</para>
    /// <para>业务数据类型标识:UP_ BASE_ MSG</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>描述:下级平台向上级平台发送车辆睁态信息交换业务</para>
    /// </summary>
    public class JT809_0x1600: JT809ExchangeMessageBodies
    {
        public override ushort MsgId => JT809BusinessType.主链路静态信息交换消息.ToUInt16Value();
        public override string Description => "主链路静态信息交换消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;
    }
}
