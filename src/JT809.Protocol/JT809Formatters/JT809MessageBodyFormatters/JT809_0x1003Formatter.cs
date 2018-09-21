using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters
{
    public class JT809_0x1003Formatter : IJT809Formatter<JT809_0x1003>
    {
        public JT809_0x1003 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1003 jT809_0X1003 = new JT809_0x1003();
            jT809_0X1003.UserId = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1003.Password = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 8);
            readSize = offset;
            return jT809_0X1003;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1003 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.UserId);
            offset += JT809BinaryExtensions.WriteStringPadLeftLittle(memoryOwner, offset, value.Password,8);
            return offset;
        }
    }
}
