using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆行驶记录请求消息
    /// <para>子业务类型标识:DOVJN_CTRL_MSG_TAKE_TRAVEL_REQ</para>
    /// <para>描述:上级平台向下级平台下发上报车辆行驶记录请求消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9500_0x9504_Formatter))]
    public class JT809_0x9500_0x9504:JT809SubBodies
    {
        /// <summary>
        /// 命令字ID
        /// </summary>
        public JT809CommandType Command { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 最大数据数
        /// </summary>
        public ushort Max { get; set; }
    }
}
