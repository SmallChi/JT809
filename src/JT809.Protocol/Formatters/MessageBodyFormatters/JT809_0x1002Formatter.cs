using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x1002Formatter : IJT809Formatter<JT809_0x1002>
    {
        public JT809_0x1002 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1002 jT809_0X1002 = new JT809_0x1002 ();
            jT809_0X1002.Result=(JT809_0x1002_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1002.VerifyCode= JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            readSize =offset;
            return jT809_0X1002;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1002 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Result);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.VerifyCode);
            return offset;
        }
    }
}
