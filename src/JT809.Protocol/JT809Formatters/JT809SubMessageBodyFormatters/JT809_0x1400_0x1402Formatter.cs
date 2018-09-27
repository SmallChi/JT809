using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1400_0x1402Formatter : IJT809Formatter<JT809_0x1400_0x1402>
    {
        public JT809_0x1400_0x1402 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1400_0x1402 jT809_0X1400_0X1402 = new JT809_0x1400_0x1402();
            jT809_0X1400_0X1402.WarnSrc = (JT809Enums.JT809WarnSrc)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1400_0X1402.WarnType=(JT809Enums.JT809WarnType) JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X1400_0X1402.WarnTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X1400_0X1402.InfoID= JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1400_0X1402.InfoLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1400_0X1402.InfoContent= JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X1400_0X1402.InfoLength);
            readSize = offset;
            return jT809_0X1400_0X1402;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1400_0x1402 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.WarnSrc);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset,(ushort)value.WarnType);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(memoryOwner, offset, value.WarnTime);
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
