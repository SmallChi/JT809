using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 实时上传车辆定位信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REAL_LOCATION</para>
    /// <para>车辆的实时定位信息</para>
    /// <para>无需应答</para>
    /// </summary>
    public class JT809_0x1200_0x1202:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1202>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.实时上传车辆定位信息.ToUInt16Value();

        public override string Description => "实时上传车辆定位信息";
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }

        public JT809VehiclePositionProperties_2019 GNSSData { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1200_0x1202 value = new JT809_0x1200_0x1202();
            writer.WriteStartObject("车辆定位信息");
            if (config.Version == JT809Version.JTT2011)
            {
                value.VehiclePosition = new JT809VehiclePositionProperties();        
                value.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                writer.WriteString($"[{value.VehiclePosition.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", value.VehiclePosition.Encrypt.ToString());
                value.VehiclePosition.Day = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Day.ReadNumber()}]日", value.VehiclePosition.Day);
                value.VehiclePosition.Month = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Month.ReadNumber()}]月", value.VehiclePosition.Month);
                value.VehiclePosition.Year = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Year.ReadNumber()}]年", value.VehiclePosition.Year);
                value.VehiclePosition.Hour = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Hour.ReadNumber()}]时", value.VehiclePosition.Hour);
                value.VehiclePosition.Minute = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Minute.ReadNumber()}]分", value.VehiclePosition.Minute);
                value.VehiclePosition.Second = reader.ReadByte();
                writer.WriteNumber($"[{value.VehiclePosition.Second.ReadNumber()}]秒", value.VehiclePosition.Second);
                value.VehiclePosition.Lon = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Lon.ReadNumber()}]经度", value.VehiclePosition.Lon);
                value.VehiclePosition.Lat = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Lat.ReadNumber()}]经度", value.VehiclePosition.Lat);
                value.VehiclePosition.Vec1 = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Vec1.ReadNumber()}]速度", value.VehiclePosition.Vec1);
                value.VehiclePosition.Vec2 = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Vec2.ReadNumber()}]行驶记录仪速度", value.VehiclePosition.Vec2);
                value.VehiclePosition.Vec3 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Vec3.ReadNumber()}]车辆当前总里程数", value.VehiclePosition.Vec3);
                value.VehiclePosition.Direction = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Direction.ReadNumber()}]方向", value.VehiclePosition.Direction);
                value.VehiclePosition.Altitude = reader.ReadUInt16();
                writer.WriteNumber($"[{value.VehiclePosition.Altitude.ReadNumber()}]海拔高度", value.VehiclePosition.Altitude);
                value.VehiclePosition.State = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.State.ReadNumber()}]车辆状态", value.VehiclePosition.State);
                value.VehiclePosition.Alarm = reader.ReadUInt32();
                writer.WriteNumber($"[{value.VehiclePosition.Alarm.ReadNumber()}]报警", value.VehiclePosition.Alarm);
            }
            else
            {
                value.GNSSData = new JT809VehiclePositionProperties_2019();
                value.GNSSData.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                writer.WriteString($"[{value.VehiclePosition.Encrypt.ToByteValue()}]是否使用国家测绘局批准的地图保密插件进行加密", value.VehiclePosition.Encrypt.ToString());
                value.GNSSData.DataLength = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.DataLength.ReadNumber()}]车辆定位信息数据长度", value.GNSSData.DataLength);
                value.GNSSData.GnssData = reader.ReadArray((int)value.GNSSData.DataLength).ToArray();
#warning 此处需要提供接口注入
                writer.WriteString($"[{value.GNSSData.GnssData.ToHexString()}]车辆定位信息内容",value.GNSSData.GnssData.ToHexString());
                var virtualHex = reader.ReadVirtualArray(11);
                value.GNSSData.PlatformId1 = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]监控平台唯一编码", value.GNSSData.PlatformId1);
                value.GNSSData.Alarm1 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.Alarm1.ReadNumber()}]报警状态", value.GNSSData.Alarm1);
                virtualHex = reader.ReadVirtualArray(11);
                value.GNSSData.PlatformId2 = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]市级监控平台唯一编码", value.GNSSData.PlatformId2);
                value.GNSSData.Alarm2 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.Alarm1.ReadNumber()}]报警状态", value.GNSSData.Alarm1);
                virtualHex = reader.ReadVirtualArray(11);
                value.GNSSData.PlatformId3 = reader.ReadString(11);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]省级监控平台唯一编码", value.GNSSData.PlatformId3);
                value.GNSSData.Alarm3 = reader.ReadUInt32();
                writer.WriteNumber($"[{value.GNSSData.Alarm1.ReadNumber()}]报警状态", value.GNSSData.Alarm1);
            }
            writer.WriteEndObject();
        }

        public JT809_0x1200_0x1202 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1202 value = new JT809_0x1200_0x1202();
            if (config.Version == JT809Version.JTT2011)
            {
                value.VehiclePosition = new JT809VehiclePositionProperties();
                value.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
                value.VehiclePosition.Day = reader.ReadByte();
                value.VehiclePosition.Month = reader.ReadByte();
                value.VehiclePosition.Year = reader.ReadUInt16();
                value.VehiclePosition.Hour = reader.ReadByte();
                value.VehiclePosition.Minute = reader.ReadByte();
                value.VehiclePosition.Second = reader.ReadByte();
                value.VehiclePosition.Lon = reader.ReadUInt32();
                value.VehiclePosition.Lat = reader.ReadUInt32();
                value.VehiclePosition.Vec1 = reader.ReadUInt16();
                value.VehiclePosition.Vec2 = reader.ReadUInt16();
                value.VehiclePosition.Vec3 = reader.ReadUInt32();
                value.VehiclePosition.Direction = reader.ReadUInt16();
                value.VehiclePosition.Altitude = reader.ReadUInt16();
                value.VehiclePosition.State = reader.ReadUInt32();
                value.VehiclePosition.Alarm = reader.ReadUInt32();
            }
            else 
            {
               value.GNSSData = new JT809VehiclePositionProperties_2019();
               value.GNSSData.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
               value.GNSSData.DataLength = reader.ReadUInt32();
#warning 引用808的0x0200协议
                value.GNSSData.GnssData = reader.ReadArray((int)value.GNSSData.DataLength).ToArray();
               value.GNSSData.PlatformId1 = reader.ReadString(11);
               value.GNSSData.Alarm1 = reader.ReadUInt32();
               value.GNSSData.PlatformId2 = reader.ReadString(11);
                value.GNSSData.Alarm2 = reader.ReadUInt32();
               value.GNSSData.PlatformId3 = reader.ReadString(11);
                value.GNSSData.Alarm3 = reader.ReadUInt32();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1202 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
                writer.WriteByte((byte)value.VehiclePosition.Encrypt);
                writer.WriteByte(value.VehiclePosition.Day);
                writer.WriteByte(value.VehiclePosition.Month);
                writer.WriteUInt16(value.VehiclePosition.Year);
                writer.WriteByte(value.VehiclePosition.Hour);
                writer.WriteByte(value.VehiclePosition.Minute);
                writer.WriteByte(value.VehiclePosition.Second);
                writer.WriteUInt32(value.VehiclePosition.Lon);
                writer.WriteUInt32(value.VehiclePosition.Lat);
                writer.WriteUInt16(value.VehiclePosition.Vec1);
                writer.WriteUInt16(value.VehiclePosition.Vec2);
                writer.WriteUInt32(value.VehiclePosition.Vec3);
                writer.WriteUInt16(value.VehiclePosition.Direction);
                writer.WriteUInt16(value.VehiclePosition.Altitude);
                writer.WriteUInt32(value.VehiclePosition.State);
                writer.WriteUInt32(value.VehiclePosition.Alarm);
            }
            else 
            {
                writer.WriteByte((byte)value.GNSSData.Encrypt);
                writer.Skip(4, out int position);
                writer.WriteArray(value.GNSSData.GnssData);
                writer.WriteUInt32Return((uint)(writer.GetCurrentPosition() - position - 4), position);
                writer.WriteStringPadRight(value.GNSSData.PlatformId1,11);
                writer.WriteUInt32(value.GNSSData.Alarm1);
                writer.WriteStringPadRight(value.GNSSData.PlatformId2,11);
                writer.WriteUInt32(value.GNSSData.Alarm2);
                writer.WriteStringPadRight(value.GNSSData.PlatformId3,11);
                writer.WriteUInt32(value.GNSSData.Alarm3);
            }
        }
    }
}
