using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1200_0x120B_Formatter : IJT809Formatter<JT809_0x1200_0x120B>
    {
        public JT809_0x1200_0x120B Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1200_0x120B jT809_0X1200_0X120B = new JT809_0x1200_0x120B();
            jT809_0X1200_0X120B.EwaybillLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X120B.EwaybillInfo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X1200_0X120B.EwaybillLength);
            readSize = offset;
            return jT809_0X1200_0X120B;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1200_0x120B value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, (uint)value.EwaybillInfo.Length);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.EwaybillInfo);
            return offset;
        }
    }
}
