using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 申请交换指定车辆定位信息请求消息
    /// <para>子业务类型标识:UP_EXG_MSG_APPLY-FOR_MONITOR_STARTUP</para>
    /// <para>描述:当下级平台需要在特定时问段内监控特殊车辆时，可上传此命令到上级平台申请对该车辆定位数据交换到下级平台，申请成功后，此车辆定位数据将在指定时间内交换到该平台(即使该车没有进入该平台所属区域也会交换)</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x1207Formatter))]
    public class JT809_0x1200_0x1207:JT809SubBodies
    {
        /// <summary>
        /// 开始时间，用 UTC 时间表示
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间，用 UTC 时间表示
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
