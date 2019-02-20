using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9500_0x9503Formatter : IJT809Formatter<JT809_0x9500_0x9503>
    {
        public JT809_0x9500_0x9503 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9500_0x9503 jT809_0X9500_0X9503 = new JT809_0x9500_0x9503();
            jT809_0X9500_0X9503.MsgSequence = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9500_0X9503.MsgPriority = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9500_0X9503.MsgLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9500_0X9503.MsgContent = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,(int)jT809_0X9500_0X9503.MsgLength);
            readSize = offset;
            return jT809_0X9500_0X9503;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9500_0x9503 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.MsgSequence);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.MsgPriority);
            // 先计算内容长度（汉字为两个字节）
            offset += 4;
            int byteLength = JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.MsgContent);
            JT809BinaryExtensions.WriteInt32Little(bytes, offset - 4, byteLength);
            offset += byteLength;
            return offset;
        }
    }
}
