using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1502Formatter : IJT809Formatter<JT809_0x1500_0x1502>
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
            jT809_0X1500_0X1502.Photo = JT809BinaryExtensions.ReadBytesLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1500_0X1502;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1500_0x1502 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.PhotoRspFlag);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.VehiclePosition.Encrypt);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.VehiclePosition.Day);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.VehiclePosition.Month);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, value.VehiclePosition.Year);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.VehiclePosition.Hour);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.VehiclePosition.Minute);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.VehiclePosition.Second);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.VehiclePosition.Lon);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.VehiclePosition.Lat);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, value.VehiclePosition.Vec1);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, value.VehiclePosition.Vec2);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.VehiclePosition.Vec3);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, value.VehiclePosition.Direction);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, value.VehiclePosition.Altitude);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.VehiclePosition.State);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.VehiclePosition.Alarm);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.LensID);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.PhotoLen);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.SizeType);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.Type);
            offset += JT809BinaryExtensions.WriteBytesLittle(memoryOwner, offset, value.Photo);
            return offset;
        }
    }
}
