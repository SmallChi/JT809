using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 申请交换指定车辆定位信息应答
    /// <para>子业务类型标识:DOWN_EXG_MSG_APPLY_FOR_MONITOR_STARTUP_ACK</para>
    /// <para>描述：应答下级平台申请交换指定车辆定位信息,请求消息."即 UP_EXG_MSG_APPLY_FOR_MONITOR_STARTUP</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9200_0x9207Formatter))]
    public class JT809_0x9200_0x9207:JT809SubBodies
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public JT809_0x9207_Result Result { get; set; }
    }
}
