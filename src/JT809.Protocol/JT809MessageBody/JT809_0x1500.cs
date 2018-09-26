using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters;


namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 主链路车辆监管消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_CTRL_MSG</para>
    /// <para>描述:下级平台向上级平台发送车辆监管业务</para>
    /// </summary>
    [JT809Formatter(typeof(JT809BodiesFormatter<JT809_0x1500>))]
    public class JT809_0x1500:JT809Bodies
    {
        
    }
}
