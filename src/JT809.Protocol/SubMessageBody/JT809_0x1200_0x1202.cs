using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 实时上传车辆定位信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REAL_LOCATION</para>
    /// <para>车辆的实时定位信息</para>
    /// <para>无需应答</para>
    /// </summary>
    public class JT809_0x1200_0x1202:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1202>,IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.实时上传车辆定位信息.ToUInt16Value();

        public override string Description => "实时上传车辆定位信息";
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }

        public JT809VehiclePositionProperties_2019 GNSSData { get; set; }

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
               value.GNSSData.GnssData = reader.ReadArray((int)value.GNSSData.DataLength).ToArray();
               value.GNSSData.PlatformId1 = reader.ReadBigNumber(11);
               value.GNSSData.Alarm1 = reader.ReadUInt32();
               value.GNSSData.PlatformId2 = reader.ReadBigNumber(11);
                value.GNSSData.Alarm2 = reader.ReadUInt32();
               value.GNSSData.PlatformId3 = reader.ReadBigNumber(11);
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
                writer.WriteBigNumber(value.GNSSData.PlatformId1,11);
                writer.WriteUInt32(value.GNSSData.Alarm1);
                writer.WriteBigNumber(value.GNSSData.PlatformId2,11);
                writer.WriteUInt32(value.GNSSData.Alarm2);
                writer.WriteBigNumber(value.GNSSData.PlatformId3,11);
                writer.WriteUInt32(value.GNSSData.Alarm3);
                writer.WriteUInt32Return((uint)(writer.GetCurrentPosition() - position - 4), position);
            }
        }
    }
}
