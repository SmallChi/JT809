using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报驾驶员身份识别信息应答消息
    /// <para>子业务类型标识:UP_EXG_MSG_REPORT_DRIVER_INFO_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的上报驾驶员身份识别信息请求消息，上传指定车辆的驾驶员身份识别信息数据</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x120A_Formatter))]
    public class JT809_0x1200_0x120A:JT809SubBodies
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
