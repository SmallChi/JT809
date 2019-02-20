using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1200_0x120D_Formatter : IJT809Formatter<JT809_0x1200_0x120D>
    {
        public JT809_0x1200_0x120D Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1200_0x120D jT809_0X1200_0X120D = new JT809_0x1200_0x120D();
            jT809_0X1200_0X120D.EwaybillLength = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1200_0X120D.EwaybillInfo = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, (int)jT809_0X1200_0X120D.EwaybillLength);
            readSize = offset;
            return jT809_0X1200_0X120D;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1200_0x120D value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, (uint)value.EwaybillInfo.Length);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.EwaybillInfo);
            return offset;
        }
    }
}
