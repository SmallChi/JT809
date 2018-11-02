using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809MessageBodyFormatters
{
    public class JT809_0x1001Formatter : IJT809Formatter<JT809_0x1001>
    {
        public JT809_0x1001 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1001 jT809_0X1001 = new JT809_0x1001();
            jT809_0X1001.UserId = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1001.Password = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 8);
            jT809_0X1001.DownLinkIP = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 32);
            jT809_0X1001.DownLinkPort = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jT809_0X1001;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1001 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.UserId);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.Password,8);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.DownLinkIP,32);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.DownLinkPort);
            return offset;
        }
    }
}
