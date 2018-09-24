using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 上报车辆电子运单应答消息
    /// <para>子业务类型标识:UP_CXG_MSG_TAKE_EWAYBILL_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的上报车辆电子运单请求消息，向上级平台上传车辆当前电子运单</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x120BFormatter))]
    public class JT809_0x1200_0x120B:JT809SubBodies
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
