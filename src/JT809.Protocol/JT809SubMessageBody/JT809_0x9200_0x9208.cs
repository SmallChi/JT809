using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 取消交换指定车辆定位信息应答
    /// <para>子业务类型标识:DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9200_0x9208Formatter))]
    public class JT809_0x9200_0x9208:JT809SubBodies
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public JT809_0x9208_Result Result { get; set; }
    }
}
