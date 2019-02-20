using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters;


namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路车辆动态信息交换业务
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_EXG_MSG</para>
    /// <para>描述:下级平台向上级平台发送车辆动态信息交换业务数据包</para>
    /// </summary>
    [JT809Formatter(typeof(JT809BodiesFormatter<JT809_0x1200>))]
    public class JT809_0x1200: JT809ExchangeMessageBodies
    {
        
    }
}
