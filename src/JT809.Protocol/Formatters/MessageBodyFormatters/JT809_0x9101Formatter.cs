using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9101Formatter : IJT809Formatter<JT809_0x9101>
    {
        public JT809_0x9101 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9101 jT809_0X9101 = new JT809_0x9101();
            jT809_0X9101.DynamicInfoTotal = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9101.StartTime = JT809BinaryExtensions.ReadUInt64Little(bytes, ref offset);
            jT809_0X9101.EndTime = JT809BinaryExtensions.ReadUInt64Little(bytes, ref offset);
            readSize = offset;
            return jT809_0X9101;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9101 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.DynamicInfoTotal);
            offset += JT809BinaryExtensions.WriteUInt64Little(bytes, offset, value.StartTime);
            offset += JT809BinaryExtensions.WriteUInt64Little(bytes, offset, value.EndTime);
            return offset;
        }
    }
}
