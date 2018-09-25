using JT809.Protocol.JT809Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Properties
{
    /// <summary>
    /// 车辆定位
    /// </summary>
    public class JT809VehiclePositionProperties
    {
        /// <summary>
        /// 该字段标识传输的定位信息是否使用国家测绘局批准的地图保密插件进行加密。
        /// </summary>
        public JT809_VehiclePositionEncrypt Encrypt { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public byte Day { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public byte Month { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public ushort Year { get; set; }
        /// <summary>
        /// 时
        /// </summary>
        public byte Hour { get; set; }
        /// <summary>
        /// 分
        /// </summary>
        public byte Minute { get; set; }
        /// <summary>
        /// 秒
        /// </summary>
        public byte Second { get; set; }
        /// <summary>
        /// 经度，单位为 1*10^-6 度。
        /// </summary>
        public uint Lon { get; set; }
        /// <summary>
        /// 纬度，单位为 1*10^-6 度。
        /// </summary>
        public uint Lat { get; set; }
        /// <summary>
        /// 速度，指卫星定位车载终端设备上传的行车速度信息，为必填项。单位为千米每小时（km/h）。
        /// </summary>
        public ushort Vec1 { get; set; }
        /// <summary>
        /// 行驶记录速度，指车辆行驶记录设备上传的行车速度 信息，为必填项。单位为千米每小时（km/h）。
        /// </summary>
        public ushort Vec2 { get; set; }
        /// <summary>
        /// 车辆当前总里程数，值车辆上传的行车里程数。单位单位为千米（km）
        /// </summary>
        public uint Vec3 { get; set; }
        /// <summary>
        /// 方向，0-359，单位为度（。），正北为 0，顺时针。
        /// </summary>
        public ushort Direction { get; set; }
        /// <summary>
        /// 海拔高度，单位为米（m）。
        /// </summary>
        public ushort Altitude { get; set; }
        /// <summary>
        /// 车辆状态，二进制表示，B31B30B29。。。。。。B2B1B0.具体定义按照 JT/T808-2011 中表 17 的规定
        /// </summary>
        public uint State { get; set; }
        /// <summary>
        /// 报警状态，二进制表示，0 标识正常，1 表示报警： B31B30B29 。。。。。。 B2B1B0.具 体 定 义 按 照JT/T808-2011 中表 18 的规定
        /// </summary>
        public uint Alarm { get; set; }
    }
}
