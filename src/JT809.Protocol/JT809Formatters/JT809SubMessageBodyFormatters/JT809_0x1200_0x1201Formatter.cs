using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using JT809.Protocol.JT809Enums;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1200_0x1201Formatter : IJT809Formatter<JT809_0x1200_0x1201>
    {
        public JT809_0x1200_0x1201 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201();
            jT809_0X1200_0X1201.PlateformId= JT809BinaryExtensions.ReadBigNumberLittle(bytes, ref offset, 11);
            jT809_0X1200_0X1201.ProducerId = JT809BinaryExtensions.ReadBigNumberLittle(bytes, ref offset, 11);
            jT809_0X1200_0X1201.TerminalModelType = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            jT809_0X1200_0X1201.TerminalId = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 7);
            jT809_0X1200_0X1201.TerminalId = jT809_0X1200_0X1201.TerminalId.ToUpper();
            jT809_0X1200_0X1201.TerminalSimCode = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset, 12);
            readSize = offset;
            return jT809_0X1200_0X1201;
        }  

        public int Serialize(ref byte[] bytes, int offset, JT809_0x1200_0x1201 value)
        {
            offset += JT809BinaryExtensions.WriteBigNumberLittle(bytes, offset, value.PlateformId,11);
            offset += JT809BinaryExtensions.WriteBigNumberLittle(bytes, offset, value.ProducerId, 11);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.TerminalModelType, 20);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.TerminalId.ToUpper(), 7);
            offset += JT809BinaryExtensions.WriteStringPadRightLittle(bytes, offset, value.TerminalSimCode, 12);
            return offset;
        }
    }
}
