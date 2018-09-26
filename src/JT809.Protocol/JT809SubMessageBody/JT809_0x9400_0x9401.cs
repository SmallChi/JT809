using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 报警督办请求消息
    /// <para>子业务类型标识:DOWN_WARN_MSG_URGE_TODO_REQ</para>
    /// <para>描述:上级平台向车辆归属下级平台下发本消息，催促其及时处理相关车辆的报警信息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9400_0x9401Formatter))]
    public class JT809_0x9400_0x9401:JT809SubBodies
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
        /// 报警时间
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 报警督办ID
        /// </summary>
        public uint SupervisionID { get; set; }
        /// <summary>
        /// 督办截止时间
        /// </summary>
        public DateTime SupervisionEndtime { get; set; }
        /// <summary>
        /// 督办级别
        /// </summary>
        public byte SupervisionLevel { get; set; }
        /// <summary>
        /// 督办人
        /// </summary>
        public string Supervisor { get; set; }
        /// <summary>
        /// 督办联系电话
        /// </summary>
        public string SupervisorTel { get; set; }
        /// <summary>
        /// 督办联系电子邮件
        /// </summary>
        public string SupervisorEmail { get; set; }
    }
}
