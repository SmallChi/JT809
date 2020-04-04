using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 交换车辆定位信息消息
    /// <para>子业务类型标识:DOWN_EXG_MSG_CAR_LOCATION</para>
    /// <para>描述:上级平台通过该消息不间断地向车辆驶入区域所属的下级平台发送车辆定位信息，直到该车驶离该区域</para>
    /// </summary>
    public class JT809_0x9200_0x9202:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9202>
    {
        public override ushort SubMsgId => JT809SubBusinessType.交换车辆定位信息消息.ToUInt16Value();

        public override string Description => "交换车辆定位信息消息";
        public JT809_0x9200_0x9202()
        {
            VehiclePosition = new JT809VehiclePositionProperties();
        }
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }

        public JT809_0x9200_0x9202 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9202 jT809_0X1200_0x9202 = new JT809_0x9200_0x9202();
            jT809_0X1200_0x9202.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            jT809_0X1200_0x9202.VehiclePosition.Day = reader.ReadByte();
            jT809_0X1200_0x9202.VehiclePosition.Month = reader.ReadByte();
            jT809_0X1200_0x9202.VehiclePosition.Year = reader.ReadUInt16();
            jT809_0X1200_0x9202.VehiclePosition.Hour = reader.ReadByte();
            jT809_0X1200_0x9202.VehiclePosition.Minute = reader.ReadByte();
            jT809_0X1200_0x9202.VehiclePosition.Second = reader.ReadByte();
            jT809_0X1200_0x9202.VehiclePosition.Lon = reader.ReadUInt32();
            jT809_0X1200_0x9202.VehiclePosition.Lat = reader.ReadUInt32();
            jT809_0X1200_0x9202.VehiclePosition.Vec1 = reader.ReadUInt16();
            jT809_0X1200_0x9202.VehiclePosition.Vec2 = reader.ReadUInt16();
            jT809_0X1200_0x9202.VehiclePosition.Vec3 = reader.ReadUInt32();
            jT809_0X1200_0x9202.VehiclePosition.Direction = reader.ReadUInt16();
            jT809_0X1200_0x9202.VehiclePosition.Altitude = reader.ReadUInt16();
            jT809_0X1200_0x9202.VehiclePosition.State = reader.ReadUInt32();
            jT809_0X1200_0x9202.VehiclePosition.Alarm = reader.ReadUInt32();
            return jT809_0X1200_0x9202;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9202 value, IJT809Config config)
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
    }
}
