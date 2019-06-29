using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1502_Formatter : IJT809MessagePackFormatter<JT809_0x1500_0x1502>
    {
        public readonly static JT809_0x1500_0x1502_Formatter Instance = new JT809_0x1500_0x1502_Formatter();

        public JT809_0x1500_0x1502 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1502 jT809_0X1500_0X1502 = new JT809_0x1500_0x1502();
            jT809_0X1500_0X1502.PhotoRspFlag = (JT809_0x1502_PhotoRspFlag)reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Day = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Month = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Year = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Hour = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Minute = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Second = reader.ReadByte();
            jT809_0X1500_0X1502.VehiclePosition.Lon = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Lat = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Vec1 = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Vec2 = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Vec3 = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Direction = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.Altitude = reader.ReadUInt16();
            jT809_0X1500_0X1502.VehiclePosition.State = reader.ReadUInt32();
            jT809_0X1500_0X1502.VehiclePosition.Alarm = reader.ReadUInt32();
            jT809_0X1500_0X1502.LensID = reader.ReadByte();
            jT809_0X1500_0X1502.PhotoLen = reader.ReadUInt32();
            jT809_0X1500_0X1502.SizeType = reader.ReadByte();
            jT809_0X1500_0X1502.Type = reader.ReadByte();
            if (jT809_0X1500_0X1502.PhotoLen > 0)
            {
                jT809_0X1500_0X1502.Photo = reader.ReadArray((int)jT809_0X1500_0X1502.PhotoLen).ToArray();
            }
            return jT809_0X1500_0X1502;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1502 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.PhotoRspFlag);
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
            writer.WriteByte(value.LensID);
            bool isPhoto = (value.Photo != null && value.Photo.Length > 0);
            writer.WriteUInt32(isPhoto ? (uint)value.Photo.Length : 0);
            writer.WriteByte(value.SizeType);
            writer.WriteByte(value.Type);
            if (isPhoto)
            {
                writer.WriteArray(value.Photo);
            }
        }
    }
}
