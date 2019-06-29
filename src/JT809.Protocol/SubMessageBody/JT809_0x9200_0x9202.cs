using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters.SubMessageBodyFormatters;
using JT809.Protocol.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 交换车辆定位信息消息
    /// <para>子业务类型标识:DOWN_EXG_MSG_CAR_LOCATION</para>
    /// <para>描述:上级平台通过该消息不间断地向车辆驶入区域所属的下级平台发送车辆定位信息，直到该车驶离该区域</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x9200_0x9202_Formatter))]
    public class JT809_0x9200_0x9202:JT809SubBodies
    {
        public JT809_0x9200_0x9202()
        {
            VehiclePosition = new JT809VehiclePositionProperties();
        }
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }
    }
}
