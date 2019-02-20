using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补报车辆静态信息应答
    /// <para>子业务类型标识:UP_BASE_MSG_VEHICLE_ADDED_ACK</para>
    /// <para>描述:上级平台应答下级平台发送的补报车辆静态信息清求消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9600_0x1601_Formatter))]
    public class JT809_0x1600_0x1601:JT809SubBodies
    {
        /// <summary>
        /// 车辆信息
        /// </summary>
        public string CarInfo { get; set; }
    }
}
