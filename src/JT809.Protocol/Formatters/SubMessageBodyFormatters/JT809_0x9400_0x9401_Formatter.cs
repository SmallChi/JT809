using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9400_0x9401_Formatter : IJT809MessagePackFormatter<JT809_0x9400_0x9401>
    {
        public readonly static JT809_0x9400_0x9401_Formatter Instance = new JT809_0x9400_0x9401_Formatter();

        public JT809_0x9400_0x9401 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9400_0x9401 jT809_0X9400_0X9401 = new JT809_0x9400_0x9401();
            jT809_0X9400_0X9401.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            jT809_0X9400_0X9401.WarnType =reader.ReadUInt16();
            jT809_0X9400_0X9401.WarnTime = reader.ReadUTCDateTime();
            jT809_0X9400_0X9401.SupervisionID = reader.ReadHex(4);
            jT809_0X9400_0X9401.SupervisionEndTime = reader.ReadUTCDateTime();
            jT809_0X9400_0X9401.SupervisionLevel = reader.ReadByte();
            jT809_0X9400_0X9401.Supervisor = reader.ReadString(16);
            jT809_0X9400_0X9401.SupervisorTel = reader.ReadString(20);
            jT809_0X9400_0X9401.SupervisorEmail = reader.ReadString(32);
            return jT809_0X9400_0X9401;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9400_0x9401 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.WarnSrc);
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteHex(value.SupervisionID, 4);
            writer.WriteUTCDateTime(value.SupervisionEndTime);
            writer.WriteByte(value.SupervisionLevel);
            writer.WriteStringPadRight(value.Supervisor, 16);
            writer.WriteStringPadRight(value.SupervisorTel, 20);
            writer.WriteStringPadRight(value.SupervisorEmail, 32);
        }
    }
}
