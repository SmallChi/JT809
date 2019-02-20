using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1504_Formatter : IJT809Formatter<JT809_0x1500_0x1504>
    {
        public JT809_0x1500_0x1504 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1500_0x1504 jT809_0X1500_0X1504 = new JT809_0x1500_0x1504();
            jT809_0X1500_0X1504.CommandType = (JT809CommandType)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X1500_0X1504.TraveldataLength= JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1504.TraveldataInfo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X1500_0X1504.TraveldataLength);
            readSize = offset;
            return jT809_0X1500_0X1504;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1500_0x1504 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.CommandType);
            // 先计算内容长度（汉字为两个字节）
            offset += 4;
            int byteLength = JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.TraveldataInfo);
            JT809BinaryExtensions.WriteInt32Little(bytes, offset - 4, byteLength);
            offset += byteLength;
            return offset;
        }
    }
}
