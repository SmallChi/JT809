using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809MessageBody
{
    /// <summary>
    /// 主链路车辆动态信息交换业务
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_EXG_MSG</para>
    /// <para>描述:下级平台向上级平台发送车辆动态信息交换业务数据包</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1200Formatter))]
    public class JT809_0x1200:JT809Bodies
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        public JT809VehicleColorType VehicleColor { get; set; }
        /// <summary>
        /// 子业务类型标识
        /// </summary>
        public JT809SubBusinessType SubBusinessType { get; set; }
        /// <summary>
        /// 后续数据长度
        /// </summary>
        public uint DataLength { get; set; }
        /// <summary>
        /// 数据部分
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 子业务数据体
        /// </summary>
        public JT809SubBodies JT809SubBodies { get; set; }
    }
}
