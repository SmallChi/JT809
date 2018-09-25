using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x9200_0x9208Formatter : IJT809Formatter<JT809_0x9200_0x9208>
    {
        public JT809_0x9200_0x9208 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9200_0x9208 jT809_0X1200_0x9208 = new JT809_0x9200_0x9208();
            jT809_0X1200_0x9208.Result = (JT809_0x9208_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0x9208;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x9200_0x9208 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.Result);
            return offset;
        }
    }
}
