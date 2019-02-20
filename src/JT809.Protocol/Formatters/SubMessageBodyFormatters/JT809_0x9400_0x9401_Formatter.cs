using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9400_0x9401_Formatter : IJT809Formatter<JT809_0x9400_0x9401>
    {
        public JT809_0x9400_0x9401 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9400_0x9401 jT809_0X9400_0X9401 = new JT809_0x9400_0x9401();
            jT809_0X9400_0X9401.WarnSrc = (JT809WarnSrc)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9400_0X9401.WarnType =(JT809WarnType) JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X9400_0X9401.WarnTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X9400_0X9401.SupervisionID = JT809BinaryExtensions.ReadHexStringLittle(bytes, ref offset,4);
            jT809_0X9400_0X9401.SupervisionEndTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X9400_0X9401.SupervisionLevel = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9400_0X9401.Supervisor = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,16);
            jT809_0X9400_0X9401.SupervisorTel = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,20);
            jT809_0X9400_0X9401.SupervisorEmail = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,32);
            readSize = offset;
            return jT809_0X9400_0X9401;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9400_0x9401 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.WarnSrc);
            offset += JT809BinaryExtensions.WriteUInt16Little(bytes, offset, (ushort)value.WarnType);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(bytes, offset, value.WarnTime);
            offset += JT809BinaryExtensions.WriteHexStringLittle(bytes, offset, value.SupervisionID,4);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(bytes, offset, value.SupervisionEndTime);
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, value.SupervisionLevel);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.Supervisor,16);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.SupervisorTel,20);
            offset += JT809BinaryExtensions.WriteStringLittle(bytes, offset, value.SupervisorEmail,32);
            return offset;
        }
    }
}
