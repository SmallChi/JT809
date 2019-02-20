using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9300_0x9302_Formatter : IJT809Formatter<JT809_0x9300_0x9302>
    {
        public JT809_0x9300_0x9302 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9300_0x9302 jT809_0X9300_0X9302 = new JT809_0x9300_0x9302();
            jT809_0X9300_0X9302.ObjectType = (JT809_0x9302_ObjectType)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9300_0X9302.ObjectID = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 12);
            jT809_0X9300_0X9302.InfoID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9300_0X9302.InfoLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9300_0X9302.InfoContent = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X9300_0X9302.InfoLength);
            readSize = offset;
            return jT809_0X9300_0X9302;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9300_0x9302 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.ObjectType);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.ObjectID, 12);
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            offset += 4;
            int byteLength = JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.InfoContent);
            JT809BinaryExtensions.WriteInt32Little(bytes, offset - 4, byteLength);
            offset += byteLength;
            return offset;
        }
    }
}
