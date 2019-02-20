using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1502_Formatter : IJT809Formatter<JT809_0x1500_0x1502>
    {
        public JT809_0x1500_0x1502 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1500_0x1502 jT809_0X1500_0X1502 = new JT809_0x1500_0x1502();
            jT809_0X1500_0X1502.PhotoRspFlag= (JT809_0x1502_PhotoRspFlag)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Day = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Month = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Year = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Hour = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Minute = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Second = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Lon = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Lat = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Vec1 = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Vec2 = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Vec3 = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Direction = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Altitude = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.State = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1502.VehiclePosition.Alarm = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1502.LensID = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.PhotoLen = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1502.SizeType = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1502.Type = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            if (jT809_0X1500_0X1502.PhotoLen > 0)
            {
                jT809_0X1500_0X1502.Photo = JT809BinaryExtensions.ReadBytesLittle(bytes, ref offset, (int)jT809_0X1500_0X1502.PhotoLen);
            }
            readSize = offset;
            return jT809_0X1500_0X1502;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1500_0x1502 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.PhotoRspFlag);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.VehiclePosition.Encrypt);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.VehiclePosition.Day);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.VehiclePosition.Month);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.VehiclePosition.Year);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.VehiclePosition.Hour);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.VehiclePosition.Minute);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.VehiclePosition.Second);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VehiclePosition.Lon);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VehiclePosition.Lat);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.VehiclePosition.Vec1);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.VehiclePosition.Vec2);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VehiclePosition.Vec3);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.VehiclePosition.Direction);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.VehiclePosition.Altitude);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VehiclePosition.State);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VehiclePosition.Alarm);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.LensID);
            bool isPhoto = (value.Photo != null && value.Photo.Length > 0);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, isPhoto ? (uint)value.Photo.Length : 0);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.SizeType);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.Type);
            if (isPhoto)
            {
                offset += JT809BinaryExtensions.WriteBytesLittle(bytes, offset, value.Photo);
            }
            return offset;
        }
    }
}
