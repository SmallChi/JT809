using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// 交换信息体
    /// </summary>
    public abstract  class JT809ExchangeMessageBodies: JT809Bodies
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
        public ushort SubBusinessType { get; set; } 
        /// <summary>
        /// 后续数据长度
        /// </summary>
        public uint DataLength { get; set; }
        /// <summary>
        /// 子业务数据体
        /// </summary>
        public JT809SubBodies SubBodies { get; set; }
    }
}
