using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补发车辆定位信息请求
    /// <para>子业务类型标识:UP_EXG_MSG_APPLY_HISGNSSDATA_REQ</para>
    /// <para>描述:在平台间传输链路中断并重新建立连接后，下级平台向上级平台请求中断期间内上级平台需交换至下级平台的车辆定位信息时，向上级平台发出补发车辆定位信息请求，上级平台对请求应答后进行“补发车辆定位信息”</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x1209Formatter))]
    public class JT809_0x1200_0x1209:JT809SubBodies
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
