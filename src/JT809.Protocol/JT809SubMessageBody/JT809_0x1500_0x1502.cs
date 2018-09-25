using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters;
using JT809.Protocol.JT809Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809SubMessageBody
{
    /// <summary>
    /// 车辆拍照应答
    /// <para>子业务类型标识:UP_ CTRL_ MSG _TAKE_ PHOTO_ ACK</para>
    /// <para>描述:下级平台应答上级平台发送的车辆拍照请求消息，上传图片信息到上级平台</para>
    /// </summary>
    [JT809Formatter(typeof(JT809_0x1500_0x1502Formatter))]
    public class JT809_0x1500_0x1502:JT809SubBodies
    {
        /// <summary>
        /// 拍照应答标识
        /// </summary>
        public JT809_0x1502_PhotoRspFlag PhotoRspFlag { get; set; }

        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }
        /// <summary>
        /// 镜头ID
        /// </summary>
        public byte LensID { get; set; }
        /// <summary>
        /// 图片长度
        /// </summary>
        public uint PhotoLen { get; set; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public byte SizeType { get; set; }
        /// <summary>
        /// 图像格式
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 图片内容
        /// </summary>
        public byte[] Photo { get; set; }
    }
}
