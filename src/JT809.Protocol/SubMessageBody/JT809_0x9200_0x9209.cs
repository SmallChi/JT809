using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 取消交换指定车辆定位信息应答
    /// <para>子业务类型标识:DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9200_0x9209_Formatter))]
    public class JT809_0x9200_0x9209: JT809SubBodies
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public JT809_0x9209_Result Result { get; set; }
    }
}
