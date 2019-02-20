using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1200_0x1202_Formatter : IJT809Formatter<JT809_0x1200_0x1202>
    {
        public JT809_0x1200_0x1202 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.VehiclePosition.Encrypt = (JT809_VehiclePositionEncrypt)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Day= JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Month = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Year = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Hour = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Minute = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Second = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Lon = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Lat = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Vec1 = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Vec2 = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Vec3 = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Direction = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Altitude = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.State = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X1202.VehiclePosition.Alarm = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0X1202;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1200_0x1202 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset,(byte) value.VehiclePosition.Encrypt);
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
            return offset;
          }
    }
}
