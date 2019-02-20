using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆应急接入监管平台请求消息
    /// <para>子业务类型标识:UP_CTRL_MSG_EMERGENCY_MONITORING_REQ</para>
    /// <para>描述:发生应急情况时，政府监管平台需要及时监控该车辆时，就向该车辆归属的下级平台发送该命令</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9500_0x9505Formatter))]
    public class JT809_0x9500_0x9505:JT809SubBodies
    {
        /// <summary>
        /// 监管平台下发的鉴权码
        /// </summary>
        public string AuthenticationCode { get; set; }
        /// <summary>
        /// 拨号点名称
        /// </summary>
        public string AccessPointName { get; set; }
        /// <summary>
        /// 拨号用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 拨号密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 服务器TCP端口
        /// </summary>
        public ushort TcpPort { get; set; }
        /// <summary>
        /// 服务器UDP端口
        /// </summary>
        public ushort UdpPort { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
