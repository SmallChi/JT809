using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.Metadata
{
    /// <summary>
    /// 车辆定位
    /// </summary>
    public class JT809VehiclePositionProperties : IJT809MessagePackFormatter<JT809VehiclePositionProperties>, IJT809Analyze
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
        public  void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            writer.WriteStartObject("车辆定位信息");
            var VehiclePosition = new JT809VehiclePositionProperties();
            VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            writer.WriteString($"[{VehiclePosition.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", VehiclePosition.Encrypt.ToString());
            VehiclePosition.Day = reader.ReadByte();
            writer.WriteNumber($"[{VehiclePosition.Day.ReadNumber()}]日", VehiclePosition.Day);
            VehiclePosition.Month = reader.ReadByte();
            writer.WriteNumber($"[{VehiclePosition.Month.ReadNumber()}]月", VehiclePosition.Month);
            VehiclePosition.Year = reader.ReadUInt16();
            writer.WriteNumber($"[{VehiclePosition.Year.ReadNumber()}]年", VehiclePosition.Year);
            VehiclePosition.Hour = reader.ReadByte();
            writer.WriteNumber($"[{VehiclePosition.Hour.ReadNumber()}]时", VehiclePosition.Hour);
            VehiclePosition.Minute = reader.ReadByte();
            writer.WriteNumber($"[{VehiclePosition.Minute.ReadNumber()}]分", VehiclePosition.Minute);
            VehiclePosition.Second = reader.ReadByte();
            writer.WriteNumber($"[{VehiclePosition.Second.ReadNumber()}]秒", VehiclePosition.Second);
            VehiclePosition.Lon = reader.ReadUInt32();
            writer.WriteNumber($"[{VehiclePosition.Lon.ReadNumber()}]经度", VehiclePosition.Lon);
            VehiclePosition.Lat = reader.ReadUInt32();
            writer.WriteNumber($"[{VehiclePosition.Lat.ReadNumber()}]经度", VehiclePosition.Lat);
            VehiclePosition.Vec1 = reader.ReadUInt16();
            writer.WriteNumber($"[{VehiclePosition.Vec1.ReadNumber()}]速度", VehiclePosition.Vec1);
            VehiclePosition.Vec2 = reader.ReadUInt16();
            writer.WriteNumber($"[{VehiclePosition.Vec2.ReadNumber()}]行驶记录仪速度", VehiclePosition.Vec2);
            VehiclePosition.Vec3 = reader.ReadUInt32();
            writer.WriteNumber($"[{VehiclePosition.Vec3.ReadNumber()}]车辆当前总里程数", VehiclePosition.Vec3);
            VehiclePosition.Direction = reader.ReadUInt16();
            writer.WriteNumber($"[{VehiclePosition.Direction.ReadNumber()}]方向", VehiclePosition.Direction);
            VehiclePosition.Altitude = reader.ReadUInt16();
            writer.WriteNumber($"[{VehiclePosition.Altitude.ReadNumber()}]海拔高度", VehiclePosition.Altitude);
            VehiclePosition.State = reader.ReadUInt32();
            writer.WriteNumber($"[{VehiclePosition.State.ReadNumber()}]车辆状态", VehiclePosition.State);
            VehiclePosition.Alarm = reader.ReadUInt32();
            writer.WriteNumber($"[{VehiclePosition.Alarm.ReadNumber()}]报警", VehiclePosition.Alarm);
            writer.WriteEndObject();
        }
        public  JT809VehiclePositionProperties Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809VehiclePositionProperties value = new JT809VehiclePositionProperties
            {
                Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte(),
                Day = reader.ReadByte(),
                Month = reader.ReadByte(),
                Year = reader.ReadUInt16(),
                Hour = reader.ReadByte(),
                Minute = reader.ReadByte(),
                Second = reader.ReadByte(),
                Lon = reader.ReadUInt32(),
                Lat = reader.ReadUInt32(),
                Vec1 = reader.ReadUInt16(),
                Vec2 = reader.ReadUInt16(),
                Vec3 = reader.ReadUInt32(),
                Direction = reader.ReadUInt16(),
                Altitude = reader.ReadUInt16(),
                State = reader.ReadUInt32(),
                Alarm = reader.ReadUInt32(),
            };
            return value;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809VehiclePositionProperties value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Encrypt);
            writer.WriteByte(value.Day);
            writer.WriteByte(value.Month);
            writer.WriteUInt16(value.Year);
            writer.WriteByte(value.Hour);
            writer.WriteByte(value.Minute);
            writer.WriteByte(value.Second);
            writer.WriteUInt32(value.Lon);
            writer.WriteUInt32(value.Lat);
            writer.WriteUInt16(value.Vec1);
            writer.WriteUInt16(value.Vec2);
            writer.WriteUInt32(value.Vec3);
            writer.WriteUInt16(value.Direction);
            writer.WriteUInt16(value.Altitude);
            writer.WriteUInt32(value.State);
            writer.WriteUInt32(value.Alarm);
        }
    }
}
