using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 车辆单向监听应答
    /// <para>子业务类型标识:UP_CTRL_MSG_MONITOR_VEHTCLE_ACK</para>
    /// <para>描述:下级平台向上级平台上传车辆单向监听请求消息的应答</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1500_0x1501Formatter))]
    public class JT809_0x1500_0x1501:JT809SubBodies
    {
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1501_Result Result { get; set; }
    }
}
