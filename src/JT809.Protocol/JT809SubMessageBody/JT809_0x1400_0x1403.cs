using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 主动上报报警处理结果信息
    /// <para>子业务类型标识:UP_WARN_MSG_ADPT_TODO_INFO</para>
    /// <para>描述:下级平台向上级平台上报报警处理结果</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1400_0x1403Formatter))]
    public class JT809_0x1400_0x1403:JT809SubBodies
    {
        /// <summary>
        /// 报警信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public JT809_0x1403_Result Result { get; set; }
    }
}
