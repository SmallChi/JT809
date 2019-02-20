using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发车辆报文应答消息
    /// <para>子业务类型标识:UP_CTRL_MSG_TEXT_INFO_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的报文是否成功到达指定车辆</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1500_0x1503Formatter))]
    public class JT809_0x1500_0x1503:JT809SubBodies
    {
        /// <summary>
        /// 消息ID
        /// 对应“下发车辆报文请求消息”中的MSG_ID
        /// </summary>
        public uint MsgID { get; set; }
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1503_Result Result { get; set; }
    }
}
