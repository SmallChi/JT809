using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9003Formatter : IJT809Formatter<JT809_0x9003>
    {
        public JT809_0x9003 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9003 jT809_0X9003 = new JT809_0x9003();
            jT809_0X9003.VerifyCode = (JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset));
            readSize = offset;
            return jT809_0X9003;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9003 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VerifyCode);
            return offset;
        }
    }
}
