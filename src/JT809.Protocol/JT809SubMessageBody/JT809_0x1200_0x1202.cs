using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using JT809.Protocol.JT809Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 实时上传车辆定位信息
    /// <para>子业务类型标识:UP_EXG_MSG_REAL_LOCATION</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200_0x1202Formatter))]
    public class JT809_0x1200_0x1202:JT809SubBodies
    {
        public JT809_0x1200_0x1202()
        {
            VehiclePosition = new JT809VehiclePositionProperties();
        }
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }
    }
}
