using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1200_0x1207Formatter : IJT809Formatter<JT809_0x1200_0x1207>
    {
        public JT809_0x1200_0x1207 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1200_0x1207 jT809_0X1200_0X1207 = new JT809_0x1200_0x1207();
            jT809_0X1200_0X1207.StartTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X1200_0X1207.EndTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1200_0X1207;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1200_0x1207 value)
        {
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(memoryOwner, offset, value.StartTime);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(memoryOwner, offset, value.EndTime);
            return offset;
        }
    }
}
