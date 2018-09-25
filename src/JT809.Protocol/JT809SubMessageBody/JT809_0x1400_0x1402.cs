using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 上报报警信息消息
    /// <para>子业务类型标识:UP_WARN_MSG_ADPT_INFO</para>
    /// <para>描述:下级平台向上级平台上报某车辆的报警信息</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1400_0x1402Formatter))]
    public class JT809_0x1400_0x1402:JT809SubBodies
    {
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809_0x1402_WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public ushort WarnType { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint InfoLength { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public string InfoContent { get; set; }
    }
}
