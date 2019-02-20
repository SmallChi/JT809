using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 实时交换报警信息
    /// <para>子业务类型标识:DOWN_WARN_MSG_EXG_INFORM</para>
    /// <para>描述:用于上级平台向车辆跨域目的地下级平台下发相关车辆的当前报警情况</para>
    /// <para>本条消息下级平台无需应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9400_0x9403Formatter))]
    public class JT809_0x9400_0x9403:JT809SubBodies
    {
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public JT809WarnType WarnType { get; set; }
        /// <summary>
        /// 报警时间
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
