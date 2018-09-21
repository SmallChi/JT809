using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    ///  接收车辆定位信息数量通知消息
    /// <para>链路类型：从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务类型标识: DOWN_TOTAL_RECV_BACK_MSG</para>
    /// <para>描述:上级平台向下级平台定星通知已经收到下级平台上传的车辆定位信息数量(如:每收到10,000 条车辆定位信息通知一次)</para>
    /// <para>本条消息不需下级平台应答。</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9101Formatter))]
    public class JT809_0x9101:JT809Bodies
    {
        /// <summary>
        /// START_TIME_END_TIME共收到的车辆定位信息数量
        /// </summary>
        public uint DynamicInfoTotal { get; set; }
        /// <summary>
        /// 开始时间，用 UTC 时间表示
        /// 注：采用 UTC 时间表示，如 2010-1-10 9:7:54 的 UTC 值为 1263085674，其在协议中表示为0x000000004B49286A.
        /// </summary>
        public ulong StartTime { get; set; }
        /// <summary>
        /// 结束时间，用 UTC 时间表示
        /// 注：采用 UTC 时间表示，如 2010-1-10 9:7:54 的 UTC 值为 1263085674，其在协议中表示为0x000000004B49286A.
        /// </summary>
        public ulong EndTime { get; set; }
    }
}
