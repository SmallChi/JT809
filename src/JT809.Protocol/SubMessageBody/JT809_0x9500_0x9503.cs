using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发车辆报文请求
    /// <para>子业务类型标识:DOWN_CTRL_MSG_TEXT_INFO</para>
    /// <para>描述:用于上级平台向下级平台下发报文到某指定车辆</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9500_0x9503_Formatter))]
    public class JT809_0x9500_0x9503:JT809SubBodies
    {
        /// <summary>
        /// 消息ID序号
        /// </summary>
        public uint MsgSequence { get; set; }
        /// <summary>
        /// 报文优先级
        /// </summary>
        public byte MsgPriority { get; set; }
        /// <summary>
        /// 报文信息长度
        /// </summary>
        public uint MsgLength { get; set; }
        /// <summary>
        /// 报文信息内容
        /// </summary>
        public string MsgContent { get; set; }
    }
}
