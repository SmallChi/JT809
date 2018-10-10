using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters;


namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 从链路车辆监管消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_CTRL_MSG</para>
    /// <para>描述:上级平台向下级平台发送车辆监监管业务</para>
    /// </summary>
    [JT809Formatter(typeof(JT809BodiesFormatter<JT809_0x9500>))]
    public class JT809_0x9500: JT809ExchangeMessageBodies
    {
        
    }
}
