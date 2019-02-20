using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报驾驶员身份信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_DRIVER_INFO</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x120CFormatter))]
    public class JT809_0x1200_0x120C:JT809SubBodies
    {
        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string DriverName { get; set; }
        /// <summary>
        /// 身份证编号
        /// </summary>
        public string DriverID { get; set; }
        /// <summary>
        /// 从业资格证（备用）
        /// </summary>
        public string Licence { get; set; }
        /// <summary>
        /// 发证机构名称（备用）
        /// </summary>
        public string OrgName { get; set; }
    }
}
