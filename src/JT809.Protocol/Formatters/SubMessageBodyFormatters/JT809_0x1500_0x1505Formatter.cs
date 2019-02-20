using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1505Formatter : IJT809Formatter<JT809_0x1500_0x1505>
    {
        public JT809_0x1500_0x1505 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = new JT809_0x1500_0x1505();
            jT809_0X1500_0X1505.Result = (JT809_0x1505_Result) JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1500_0X1505;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1500_0x1505 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset,(byte)value.Result);
            return offset;
        }
    }
}
