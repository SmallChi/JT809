using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9200_0x9206_Formatter : IJT809Formatter<JT809_0x9200_0x9206>
    {
        public JT809_0x9200_0x9206 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9200_0x9206 jT809_0X1200_0x9206 = new JT809_0x9200_0x9206();
            jT809_0X1200_0x9206.ReasonCode = (JT809_0x9206_ReasonCode)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0x9206;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9200_0x9206 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.ReasonCode);
            return offset;
        }
    }
}
