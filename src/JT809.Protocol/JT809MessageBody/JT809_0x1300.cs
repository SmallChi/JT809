using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 主链路平台间信息交互消息
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_PLATFORM_MSG</para>
    /// <para>描述:下级平台向上级平台发送平台间交互信息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1300Formatter))]
    public class JT809_0x1300: JT809ExchangeMessageBodies
    {
        
    }
}
