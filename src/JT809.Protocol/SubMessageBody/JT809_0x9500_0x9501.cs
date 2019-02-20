using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆单向监听请求消息
    /// <para>子业务类型标识:DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ</para>
    /// <para>描述:上级平台向下级平台下发车辆单向监听清求消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9500_0x9501Formatter))]
    public class JT809_0x9500_0x9501:JT809SubBodies
    {
        /// <summary>
        /// 回拨电话号码
        /// </summary>
        public string MonitorTel { get; set; }
    }
}
