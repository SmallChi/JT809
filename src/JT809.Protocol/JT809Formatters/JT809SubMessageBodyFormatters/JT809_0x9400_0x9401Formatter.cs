using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x9400_0x9401Formatter : IJT809Formatter<JT809_0x9400_0x9401>
    {
        public JT809_0x9400_0x9401 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9400_0x9401 jT809_0X9400_0X9401 = new JT809_0x9400_0x9401();
            jT809_0X9400_0X9401.WarnSrc = (JT809Enums.JT809_0x9401_WarnSrc)JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9400_0X9401.WarnType = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jT809_0X9400_0X9401.WarnTime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X9400_0X9401.SupervisionID = JT809BinaryExtensions.ReadUInt32Little(bytes, ref offset);
            jT809_0X9400_0X9401.SupervisionEndtime = JT809BinaryExtensions.ReadUTCDateTimeLittle(bytes, ref offset);
            jT809_0X9400_0X9401.SupervisionLevel = JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT809_0X9400_0X9401.Supervisor = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,16);
            jT809_0X9400_0X9401.SupervisorTel = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,20);
            jT809_0X9400_0X9401.SupervisorEmail = JT809BinaryExtensions.ReadStringLittle(bytes, ref offset,32);
            readSize = offset;
            return jT809_0X9400_0X9401;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x9400_0x9401 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.WarnSrc);
            offset += JT809BinaryExtensions.WriteUInt16Little(memoryOwner, offset, value.WarnType);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(memoryOwner, offset, value.WarnTime);
            offset += JT809BinaryExtensions.WriteUInt32Little(memoryOwner, offset, value.SupervisionID);
            offset += JT809BinaryExtensions.WriteUTCDateTimeLittle(memoryOwner, offset, value.SupervisionEndtime);
            offset += JT809BinaryExtensions.WriteByteLittle(memoryOwner, offset, value.SupervisionLevel);
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.Supervisor,16);
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.SupervisorTel,20);
            offset += JT809BinaryExtensions.WriteStringLittle(memoryOwner, offset, value.SupervisorEmail,32);
            return offset;
        }
    }
}
