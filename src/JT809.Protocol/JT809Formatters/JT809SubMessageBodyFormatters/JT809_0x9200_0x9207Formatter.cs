using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x9200_0x9207Formatter : IJT809Formatter<JT809_0x9200_0x9207>
    {
        public JT809_0x9200_0x9207 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9200_0x9207 jT809_0X1200_0x9207 = new JT809_0x9200_0x9207();
            jT809_0X1200_0x9207.Result = (JT809_0x9207_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0x9207;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9200_0x9207 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Result);
            return offset;
        }
    }
}
