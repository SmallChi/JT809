using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Metadata
{
    public class JT809VehiclePositionProperties_2019
    {
        /// <summary>
        /// 是否使用国测局批准的地图保密插件进行加密 1 已加密 0未加密
        /// </summary>
        public JT809_VehiclePositionEncrypt Encrypt { get; set; }
        /// <summary>
        /// 车辆定位信息数据长度
        /// </summary>
        public uint DataLength { get; set; }
        /// <summary>
        /// 车辆定位信息内容，包括车辆位置基本信息和位置附加信息
        /// 其数据格式安装 808-2019中8.12要求
        /// </summary>
        public byte[] GnssData { get; set; }
        /// <summary>
        /// 监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        /// </summary>
        public byte[] PlatformId1 { get; set; } = new byte[11];
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm1 { get; set; }
        /// <summary>
        /// 市级监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        /// 未填写时，全填0，无市级平台应由省级平台全填1
        /// </summary>
        public byte[] PlatformId2 { get; set; } = new byte[11];
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm2 { get; set; }
        /// <summary>
        /// 省级监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        ///  未填写时，全填0
        /// </summary>
        public byte[] PlatformId3 { get; set; } = new byte[11];
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm3 { get; set; }
    }
}
