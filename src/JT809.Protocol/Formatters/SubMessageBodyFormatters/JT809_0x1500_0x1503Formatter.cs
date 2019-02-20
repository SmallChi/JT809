using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1503Formatter : IJT809Formatter<JT809_0x1500_0x1503>
    {
        public JT809_0x1500_0x1503 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = new JT809_0x1500_0x1503();
            jT809_0X1500_0X1503.MsgID= JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X1500_0X1503.Result = (JT809_0x1503_Result)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jT809_0X1500_0X1503;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1500_0x1503 value)
        {
            offset += JT809BinaryExtensions.WriteUInt32Little(bytes, offset, value.MsgID);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Result);
            return offset;
        }
    }
}
