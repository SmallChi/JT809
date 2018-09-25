using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 报警督办应答消息
    /// <para>子业务类型标识:UP_WARN_MSG_URGE_TODO_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的报警督办请求消息，向上.级平台上报车辆的报瞥处理结果</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1400_0x1401Formatter))]
    public class JT809_0x1400_0x1401:JT809SubBodies
    {
        /// <summary>
        /// 报警督办 ID
        /// </summary>
        public uint SupervisionID { get; set; }
        /// <summary>
        /// 报警处理结果
        /// </summary>
        public JT809_0x1401_Result Result { get; set; }
    }
}
