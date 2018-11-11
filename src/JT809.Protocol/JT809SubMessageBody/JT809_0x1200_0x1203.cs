using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using JT809.Protocol.JT809Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    ///  车辆定位信息自动补报请求消息
    ///  <para>子业务类型标识:UP_EXG_MSG_HISTORY_LOCATION</para>
    ///  <para>描述:如果平台间传输链路中断，下级平台重新登录并与上级平台建立通信链路后，下级平台应将中断期间内车载终端上传的车辆定位信息自动补报到上级平台。
    ///  如果系统断线期间，该车需发送的数据包条数大于 5，则以每包五条进行补发，直到补发完毕。
    ///  多条数据以卫星定位时间先后顺序排列。
    ///  本条消息上级平台采用定量回复，即收到一定数量的数据后，即通过从链路应答数据量。
    ///  </para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x1203Formatter))]
    public class JT809_0x1200_0x1203 : JT809SubBodies
    {
        /// <summary>
        /// 卫星定位数据个数 1大于GNSS_CNT小于5
        /// </summary>
        public byte GNSSCount { get; set; }
        /// <summary>
        /// 卫星定位数据集合
        /// </summary>
        public List<JT809_0x1200_0x1202> GNSS { get; set; }
    }
}
