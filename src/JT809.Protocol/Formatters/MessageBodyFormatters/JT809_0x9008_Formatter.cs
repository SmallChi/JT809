using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9008_Formatter : IJT809Formatter<JT809_0x9008>
    {
        public JT809_0x9008 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9008 jT809_0X9008 = new JT809_0x9008();
            jT809_0X9008.ReasonCode = (JT809_0x9008_ReasonCode)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X9008;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9008 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.ReasonCode);
            return offset;
        }
    }
}
