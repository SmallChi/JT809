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
    public class JT809_0x9400_0x9403_Formatter : IJT809MessagePackFormatter<JT809_0x9400_0x9403>
    {
        public readonly static JT809_0x9400_0x9403_Formatter Instance = new JT809_0x9400_0x9403_Formatter();

        public JT809_0x9400_0x9403 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9400_0x9403 jT809_0X9400_0X9403 = new JT809_0x9400_0x9403();
            jT809_0X9400_0X9403.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            jT809_0X9400_0X9403.WarnType = (JT809WarnType)reader.ReadUInt16();
            jT809_0X9400_0X9403.WarnTime = reader.ReadUTCDateTime();
            jT809_0X9400_0X9403.WarnLength = reader.ReadUInt32();
            jT809_0X9400_0X9403.WarnContent = reader.ReadString((int)jT809_0X9400_0X9403.WarnLength);
            return jT809_0X9400_0X9403;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9400_0x9403 value, IJT809Config config)
        {
            writer.WriteByte( (byte)value.WarnSrc);
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.WarnContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
