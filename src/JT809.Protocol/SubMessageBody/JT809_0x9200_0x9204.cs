using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  交换车辆静态信息消息
    ///  <para>子业务类型标识:DOWN_EXG_MSG_CAR_INFO</para>
    ///  <para>描述:在首次启动跨域车辆定位信息交换，或者以后交换过程中车辆静态信息有更新时，由上级平台向下级平台下发一次车辆静态信息。下.级平台接收后自行更新该车辆静态信息</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9200_0x9204_Formatter))]
    public class JT809_0x9200_0x9204:JT809SubBodies
    {
        /// <summary>
        /// 车辆信息
        /// </summary>
        public string CarInfo { get; set; }
    }
}
