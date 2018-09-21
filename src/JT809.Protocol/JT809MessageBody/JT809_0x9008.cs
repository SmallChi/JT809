using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 上级平台主动关闭链路通知消息
    /// <para>业务数据类型标识:DOWN_CLOSELINK_INFORM</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9008Formatter))]
    public class JT809_0x9008:JT809Bodies
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x9008_ReasonCode ReasonCode { get; set; }
    }
}
