using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9400_0x9403Formatter : IJT809Formatter<JT809_0x9400_0x9403>
    {
        public JT809_0x9400_0x9403 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9400_0x9403 jT809_0X9400_0X9403 = new JT809_0x9400_0x9403();
            jT809_0X9400_0X9403.WarnSrc = (JT809WarnSrc)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9400_0X9403.WarnType = (JT809WarnType)JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X9400_0X9403.WarnTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X9400_0X9403.WarnLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9400_0X9403.WarnContent = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X9400_0X9403.WarnLength);
            readSize = offset;
            return jT809_0X9400_0X9403;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9400_0x9403 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.WarnSrc);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, (ushort)value.WarnType);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(bytes, offset, value.WarnTime);
            // 先计算内容长度（汉字为两个字节）
            offset += 4;
            int byteLength = JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.WarnContent);
            JT809BinaryExtensions.WriteInt32Little(bytes, offset - 4, byteLength);
            offset += byteLength;
            return offset;
        }
    }
}
