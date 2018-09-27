using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 报警预警
    /// <para>子业务类型标识:DOWN_WARN_MSG_INFORM_TIPS</para>
    /// <para>描述:用于上级平台向车辆归属或车辆跨域下级平台下发相关车辆的报警顶警或运行提示信息</para>
    /// <para>本条消息下级平台无需应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9400_0x9402Formatter))]
    public class JT809_0x9400_0x9402:JT809SubBodies
    {
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public ushort WarnType { get; set; }
        /// <summary>
        /// 报警时间 UTCDateTime
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint WarnLength { get; set; }
        /// <summary>
        /// 报警描述
        /// </summary>
        public string WarnContent { get; set; }
    }
}
