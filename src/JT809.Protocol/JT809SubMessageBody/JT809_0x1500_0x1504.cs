using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 上报车辆行驶记录应答消息
    /// <para>子业务类型标识:UP_CTRL_MSG_TAKE_T'RAVEL_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的上报车辆行驶记录请求消息，将车辆行驶记录数据上传至上级平台</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1500_0x1504Formatter))]
    public class JT809_0x1500_0x1504:JT809SubBodies
    {
        /// <summary>
        /// 命令字
        /// </summary>
        public byte CommandType { get; set; }
        /// <summary>
        /// 车辆行驶记录数据体长度
        /// </summary>
        public uint TraveldataLength { get; set; }
        /// <summary>
        /// 车辆行驶记录信息
        /// </summary>
        public string TraveldataInfo { get; set; }
    }
}
