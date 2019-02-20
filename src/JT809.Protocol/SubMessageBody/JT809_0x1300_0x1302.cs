using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发平台间报文应答消息
    /// <para>子业务类型标识:UP_PLATFORM_MSG_INFO_ACK</para>
    /// <para>描述:下级平台收到上级平台发送的下发平台间报文请求消息后，发送应答消息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1300_0x1302Formatter))]
    public class JT809_0x1300_0x1302:JT809SubBodies
    {
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
    }
}
