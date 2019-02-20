using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9500_0x9501_Formatter : IJT809Formatter<JT809_0x9500_0x9501>
    {
        public JT809_0x9500_0x9501 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9500_0x9501 jT809_0X9500_0X9501 = new JT809_0x9500_0x9501();
            jT809_0X9500_0X9501.MonitorTel = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,20);
            readSize = offset;
            return jT809_0X9500_0X9501;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9500_0x9501 value)
        {
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.MonitorTel,20);
            return offset;
        }
    }
}
