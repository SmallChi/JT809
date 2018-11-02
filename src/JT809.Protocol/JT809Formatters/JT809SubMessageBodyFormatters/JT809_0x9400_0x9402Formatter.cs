using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x9400_0x9402Formatter : IJT809Formatter<JT809_0x9400_0x9402>
    {
        public JT809_0x9400_0x9402 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9400_0x9402 jT809_0X9400_0X9402 = new JT809_0x9400_0x9402();
            jT809_0X9400_0X9402.WarnSrc = (JT809Enums.JT809WarnSrc)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9400_0X9402.WarnType = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X9400_0X9402.WarnTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X9400_0X9402.WarnLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9400_0X9402.WarnContent = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,(int)jT809_0X9400_0X9402.WarnLength);
            readSize = offset;
            return jT809_0X9400_0X9402;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9400_0x9402 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.WarnSrc);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.WarnType);
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
