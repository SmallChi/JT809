using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1505Formatter : IJT809Formatter<JT809_0x1500_0x1505>
    {
        public JT809_0x1500_0x1505 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = new JT809_0x1500_0x1505();
            jT809_0X1500_0X1505.Result = (JT809Enums.JT809_0x1505_Result) JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1500_0X1505;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1500_0x1505 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset,(byte)value.Result);
            return offset;
        }
    }
}
