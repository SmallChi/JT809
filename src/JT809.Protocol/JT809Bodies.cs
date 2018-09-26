using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public abstract  class JT809Bodies
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        public JT809VehicleColorType VehicleColor { get; set; } = JT809VehicleColorType.其他;
        /// <summary>
        /// 子业务类型标识
        /// </summary>
        public JT809SubBusinessType SubBusinessType { get; set; } = JT809SubBusinessType.None;
        /// <summary>
        /// 后续数据长度
        /// </summary>
        public uint DataLength { get; set; }
        /// <summary>
        /// 子业务数据体
        /// </summary>
        public JT809SubBodies JT809SubBodies { get; set; }
    }
}
