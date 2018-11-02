using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x9200_0x9204Formatter : IJT809Formatter<JT809_0x9200_0x9204>
    {
        public JT809_0x9200_0x9204 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9200_0x9204 jT809_0X1200_0x9204 = new JT809_0x9200_0x9204();
            jT809_0X1200_0x9204.CarInfo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0x9204;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9200_0x9204 value)
        {
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.CarInfo);
            return offset;
        }
    }
}
