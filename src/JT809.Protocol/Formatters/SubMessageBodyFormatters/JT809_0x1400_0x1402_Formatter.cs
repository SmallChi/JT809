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
    public class JT809_0x1400_0x1402_Formatter : IJT809MessagePackFormatter<JT809_0x1400_0x1402>
    {
        public readonly static JT809_0x1400_0x1402_Formatter Instance = new JT809_0x1400_0x1402_Formatter();

        public JT809_0x1400_0x1402 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400_0x1402 jT809_0X1400_0X1402 = new JT809_0x1400_0x1402();
            jT809_0X1400_0X1402.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            jT809_0X1400_0X1402.WarnType = (JT809WarnType)reader.ReadUInt16();
            jT809_0X1400_0X1402.WarnTime = reader.ReadUTCDateTime();
            jT809_0X1400_0X1402.InfoID = reader.ReadUInt32();
            jT809_0X1400_0X1402.InfoLength = reader.ReadUInt32();
            jT809_0X1400_0X1402.InfoContent = reader.ReadString((int)jT809_0X1400_0X1402.InfoLength);
            return jT809_0X1400_0X1402;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1402 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.WarnSrc);
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteUInt32(value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.InfoContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
