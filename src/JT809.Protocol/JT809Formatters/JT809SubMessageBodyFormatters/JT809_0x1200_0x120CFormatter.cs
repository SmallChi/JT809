using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1200_0x120CFormatter : IJT809Formatter<JT809_0x1200_0x120C>
    {
        public JT809_0x1200_0x120C Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1200_0x120C jT809_0X1200_0X120C = new JT809_0x1200_0x120C();
            jT809_0X1200_0X120C.DriverName = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 16);
            jT809_0X1200_0X120C.DriverID = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            jT809_0X1200_0X120C.Licence = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 40);
            jT809_0X1200_0X120C.OrgName = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 200);
            readSize = offset;
            return jT809_0X1200_0X120C;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1200_0x120C value)
        {
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.DriverName, 16);
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.DriverID, 20);
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.Licence, 40);
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.OrgName, 200);
            return offset;
        }
    }
}
