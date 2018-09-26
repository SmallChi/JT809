using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters;


namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 主链路静态信息交换消息
    /// <para>链路类型:主链路</para>
    /// <para>业务数据类型标识:UP_ BASE_ MSG</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>描述:下级平台向上级平台发送车辆睁态信息交换业务</para>
    /// </summary>
    [JT809Formatter(typeof(JT809BodiesFormatter<JT809_0x1600>))]
    public class JT809_0x1600:JT809Bodies
    {

    }
}
