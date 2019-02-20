using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9500_0x9505_Formatter : IJT809Formatter<JT809_0x9500_0x9505>
    {
        public JT809_0x9500_0x9505 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9500_0x9505 jT809_0X9500_0X9505 = new JT809_0x9500_0x9505();
            jT809_0X9500_0X9505.AuthenticationCode= JT809BinaryExtensions.ReadBCDLittle(bytes, ref offset,20);
            jT809_0X9500_0X9505.AccessPointName = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            jT809_0X9500_0X9505.UserName = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,49);
            jT809_0X9500_0X9505.Password = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,22);
            jT809_0X9500_0X9505.ServerIP = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 32);
            jT809_0X9500_0X9505.TcpPort = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X9500_0X9505.UdpPort = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X9500_0X9505.EndTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X9500_0X9505;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9500_0x9505 value)
        {
            offset += JT809BinaryExtensions.WriteBCDLittle(bytes, offset, value.AuthenticationCode,20);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.AccessPointName,20);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.UserName, 49);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.Password, 22);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.ServerIP, 32);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.TcpPort);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.UdpPort);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(bytes, offset, value.EndTime);
            return offset;
        }
    }
}
