using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1400_0x1401Formatter : IJT809Formatter<JT809_0x1400_0x1401>
    {
        public JT809_0x1400_0x1401 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1400_0x1401 jT809_0X1400_0X1401 = new JT809_0x1400_0x1401();
            jT809_0X1400_0X1401.SupervisionID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1400_0X1401.Result = (JT809Enums.JT809_0x1401_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1400_0X1401;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1400_0x1401 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.SupervisionID);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset,(byte)value.Result);
            return offset;
        }
    }
}
