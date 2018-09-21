using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters
{
    public class JT809_0x9001Formatter : IJT809Formatter<JT809_0x9001>
    {
        public JT809_0x9001 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9001 jT809_0X9001 = new JT809_0x9001();
            jT809_0X9001.VerifyCode = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize = offset;
            return jT809_0X9001;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x9001 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.VerifyCode);
            return offset;
        }
    }
}
