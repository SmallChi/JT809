using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9200_0x9209Formatter : IJT809Formatter<JT809_0x9200_0x9209>
    {
        public JT809_0x9200_0x9209 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9200_0x9209 jT809_0X1200_0x9209 = new JT809_0x9200_0x9209();
            jT809_0X1200_0x9209.Result = (JT809_0x9209_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0x9209;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9200_0x9209 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Result);
            return offset;
        }
    }
}
