using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  车辆定位信息交换补发消息
    ///  <para>子业务类型标识:DOWN_EXG_MSG_HISTORY_ARCOSSAREA</para>
    ///  <para>描述:本业务在 DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK 应答成功后，立即开始交换。如果申请失败，则不进行数据转发</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9200_0x9203Formatter))]
    public class JT809_0x9200_0x9203:JT809SubBodies
    {
        /// <summary>
        /// 卫星定位数据个数 1大于GNSS_CNT小于5
        /// </summary>
        public byte GNSSCount { get; set; }
        /// <summary>
        /// 卫星定位数据集合
        /// </summary>
        public List<JT809_0x9200_0x9202> GNSS { get; set; }
    }
}
