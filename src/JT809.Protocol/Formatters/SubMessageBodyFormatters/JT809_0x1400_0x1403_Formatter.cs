using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1400_0x1403_Formatter : IJT809Formatter<JT809_0x1400_0x1403>
    {
        public JT809_0x1400_0x1403 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1400_0x1403 jT809_0X1400_0X1403 = new JT809_0x1400_0x1403();
            jT809_0X1400_0X1403.InfoID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1400_0X1403.Result = (JT809_0x1403_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1400_0X1403;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1400_0x1403 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.InfoID);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Result);
            return offset;
        }
    }
}
