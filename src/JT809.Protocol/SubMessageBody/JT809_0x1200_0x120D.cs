using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报车辆电子运单信息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_EWAYBILL_INFO</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x120D_Formatter))]
    public class JT809_0x1200_0x120D:JT809SubBodies
    {
        /// <summary>
        /// 电子运单数据体长度
        /// </summary>
        public uint EwaybillLength { get; set; }
        /// <summary>
        /// 电子运单数据内容
        /// </summary>
        public string EwaybillInfo { get; set; }
    }
}
