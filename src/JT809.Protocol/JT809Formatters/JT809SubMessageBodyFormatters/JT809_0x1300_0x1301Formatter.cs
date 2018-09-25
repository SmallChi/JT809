using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1300_0x1301Formatter : IJT809Formatter<JT809_0x1300_0x1301>
    {
        public JT809_0x1300_0x1301 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1300_0x1301 jT809_0X1200_0X1301 = new JT809_0x1300_0x1301();
            jT809_0X1200_0X1301.ObjectType = (JT809Enums.JT809_0x1301_ObjectType)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1200_0X1301.ObjectID = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 12);
            jT809_0X1200_0X1301.InfoID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X1301.InfoLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X1301.InfoContent = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X1200_0X1301.InfoLength);
            readSize = offset;
            return jT809_0X1200_0X1301;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1300_0x1301 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.ObjectType);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(memoryOwner, offset, value.ObjectID, 12);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            offset += 4;
            int byteLength = JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.InfoContent);
            JT809BinaryExtensions.WriteInt32Little(memoryOwner, offset - 4, byteLength);
            offset += byteLength;
            return offset;
        }
    }
}
