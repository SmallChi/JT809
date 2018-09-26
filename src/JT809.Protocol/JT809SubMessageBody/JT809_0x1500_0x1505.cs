using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 车辆应急接入监管平台应答消息
    /// <para>子业务类型标识: UP_CTRL_MSG_EMERGENCY_MONITORING_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的车辆应急接入监管平台请求消息应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1500_0x1505Formatter))]
    public class JT809_0x1500_0x1505:JT809SubBodies
    {
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1505_Result Result { get; set; }
    }
}
