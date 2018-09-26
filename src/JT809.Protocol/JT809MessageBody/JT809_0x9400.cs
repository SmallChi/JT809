using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 从链路报警信息交互消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_WARN_MSG</para>
    /// <para>描述：上级平台向下级平台发送报瞥信息业务</para>
    /// </summary>
    [JT809Formatter(typeof(JT809BodiesFormatter<JT809_0x9400>))]
    public class JT809_0x9400:JT809Bodies
    {
        
    }
}
