using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1300_0x1302_Formatter : IJT809Formatter<JT809_0x1300_0x1302>
    {
        public JT809_0x1300_0x1302 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1300_0x1302 jT809_0X1200_0X1302 = new JT809_0x1300_0x1302();
            jT809_0X1200_0X1302.InfoID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0X1302;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1300_0x1302 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.InfoID);
            return offset;
        }
    }
}
