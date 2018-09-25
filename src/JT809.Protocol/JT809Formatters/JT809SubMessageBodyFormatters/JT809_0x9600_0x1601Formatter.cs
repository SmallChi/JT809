using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x9600_0x1601Formatter : IJT809Formatter<JT809_0x1600_0x1601>
    {
        public JT809_0x1600_0x1601 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1600_0x1601 jT809_0X9600_0X1601 = new JT809_0x1600_0x1601();
            jT809_0X9600_0X1601.CarInfo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X9600_0X1601;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1600_0x1601 value)
        {
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.CarInfo);
            return offset;
        }
    }
}
