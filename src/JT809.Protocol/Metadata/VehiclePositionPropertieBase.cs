using System.Text.Json;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Metadata
{
    public abstract class VehiclePositionPropertieBase
    {
        public static void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
                var VehiclePosition = new VehiclePositionPropertieOf2011();
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
            }
            else
            {
                var GNSSData = new VehiclePositionPropertieOf2019();
                GNSSData.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                writer.WriteString($"[{GNSSData.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", GNSSData.Encrypt.ToString());
                var gnssDataLength = reader.ReadUInt32();
                writer.WriteNumber($"[{gnssDataLength.ReadNumber()}]车辆定位信息数据长度", gnssDataLength);
                GNSSData.GnssData = reader.ReadArray((int)gnssDataLength).ToArray();
                writer.WriteString($"[{GNSSData.GnssData.ToHexString()}]车辆定位信息内容", GNSSData.GnssData.ToHexString());
                var virtualHex = reader.ReadVirtualArray(11);
                GNSSData.PlatformId1 = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]监控平台唯一编码", GNSSData.PlatformId1);
                GNSSData.Alarm1 = reader.ReadUInt32();
                writer.WriteNumber($"[{GNSSData.Alarm1.ReadNumber()}]报警状态1", GNSSData.Alarm1);
                virtualHex = reader.ReadVirtualArray(11);
                GNSSData.PlatformId2 = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]市级监控平台唯一编码", GNSSData.PlatformId2);
                GNSSData.Alarm2 = reader.ReadUInt32();
                writer.WriteNumber($"[{GNSSData.Alarm1.ReadNumber()}]报警状态2", GNSSData.Alarm2);
                virtualHex = reader.ReadVirtualArray(11);
                GNSSData.PlatformId3 = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]省级监控平台唯一编码", GNSSData.PlatformId3);
                GNSSData.Alarm3 = reader.ReadUInt32();
                writer.WriteNumber($"[{GNSSData.Alarm1.ReadNumber()}]报警状态3", GNSSData.Alarm3);
            }
        }

        public static VehiclePositionPropertieBase Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            return config.Version switch
            {
                JT809Version.JTT2011 => new VehiclePositionPropertieOf2011
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
                },
                JT809Version.JTT2019 => new VehiclePositionPropertieOf2019
                {
                    Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte(),
                    GnssData = reader.ReadArray((int)reader.ReadUInt32()).ToArray(),
                    PlatformId1 = reader.ReadString(11),
                    Alarm1 = reader.ReadUInt32(),
                    PlatformId2 = reader.ReadString(11),
                    Alarm2 = reader.ReadUInt32(),
                    PlatformId3 = reader.ReadString(11),
                    Alarm3 = reader.ReadUInt32(),
                },
                _ => throw new JT809Exception(JT809ErrorCode.IllegalArgument, "根据版本解析车辆位置信息时检测到不支持的版本")
            };
        }
        public static void Serialize(ref JT809MessagePackWriter writer, VehiclePositionPropertieBase value, IJT809Config config)
        {
            switch (value)
            {
                case VehiclePositionPropertieOf2011 vehiclePositionPropertieOf2011:

                    writer.WriteByte((byte)vehiclePositionPropertieOf2011.Encrypt);
                    writer.WriteByte(vehiclePositionPropertieOf2011.Day);
                    writer.WriteByte(vehiclePositionPropertieOf2011.Month);
                    writer.WriteUInt16(vehiclePositionPropertieOf2011.Year);
                    writer.WriteByte(vehiclePositionPropertieOf2011.Hour);
                    writer.WriteByte(vehiclePositionPropertieOf2011.Minute);
                    writer.WriteByte(vehiclePositionPropertieOf2011.Second);
                    writer.WriteUInt32(vehiclePositionPropertieOf2011.Lon);
                    writer.WriteUInt32(vehiclePositionPropertieOf2011.Lat);
                    writer.WriteUInt16(vehiclePositionPropertieOf2011.Vec1);
                    writer.WriteUInt16(vehiclePositionPropertieOf2011.Vec2);
                    writer.WriteUInt32(vehiclePositionPropertieOf2011.Vec3);
                    writer.WriteUInt16(vehiclePositionPropertieOf2011.Direction);
                    writer.WriteUInt16(vehiclePositionPropertieOf2011.Altitude);
                    writer.WriteUInt32(vehiclePositionPropertieOf2011.State);
                    writer.WriteUInt32(vehiclePositionPropertieOf2011.Alarm);
                    break;
                case VehiclePositionPropertieOf2019 vehiclePositionPropertieOf2019:
                    writer.WriteByte((byte)vehiclePositionPropertieOf2019.Encrypt);
                    writer.Skip(4, out int position);
                    writer.WriteArray(vehiclePositionPropertieOf2019.GnssData);
                    writer.WriteUInt32Return((uint)(writer.GetCurrentPosition() - position - 4), position);
                    writer.WriteStringPadRight(vehiclePositionPropertieOf2019.PlatformId1, 11);
                    writer.WriteUInt32(vehiclePositionPropertieOf2019.Alarm1);
                    writer.WriteStringPadRight(vehiclePositionPropertieOf2019.PlatformId2, 11);
                    writer.WriteUInt32(vehiclePositionPropertieOf2019.Alarm2);
                    writer.WriteStringPadRight(vehiclePositionPropertieOf2019.PlatformId3, 11);
                    writer.WriteUInt32(vehiclePositionPropertieOf2019.Alarm3);
                    break;
                default: throw new JT809Exception(JT809ErrorCode.IllegalArgument, "根据版本解析车辆位置信息时检测到不支持的版本");
            }
        }
    }
    public class VehiclePositionPropertieOf2011 : VehiclePositionPropertieBase
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
    public class VehiclePositionPropertieOf2019 : VehiclePositionPropertieBase
    {
        /// <summary>
        /// 是否使用国测局批准的地图保密插件进行加密 1 已加密 0未加密
        /// </summary>
        public JT809_VehiclePositionEncrypt Encrypt { get; set; }
        /// <summary>
        /// 车辆定位信息内容，包括车辆位置基本信息和位置附加信息
        /// 其数据格式安装 808-2019中8.12要求
        /// </summary>
        public byte[] GnssData { get; set; }
        /// <summary>
        /// 监控平台唯一编码，由平台所在地行政区域代码和平台编码组成  11位
        /// </summary>
        public string PlatformId1 { get; set; }
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm1 { get; set; }
        /// <summary>
        /// 市级监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        /// 未填写时，全填0，无市级平台应由省级平台全填1  11位
        /// </summary>
        public string PlatformId2 { get; set; }
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm2 { get; set; }
        /// <summary>
        /// 省级监控平台唯一编码，由平台所在地行政区域代码和平台编码组成
        ///  未填写时，全填0  11位
        /// </summary>
        public string PlatformId3 { get; set; }
        /// <summary>
        /// 报警状态，二进制标识 0 正常 1表示报警
        /// 具体定义按照808-2019中表18的规定
        /// </summary>
        public uint Alarm3 { get; set; }
    }
}