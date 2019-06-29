using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1504_Formatter : IJT809MessagePackFormatter<JT809_0x1500_0x1504>
    {
        public readonly static JT809_0x1500_0x1504_Formatter Instance = new JT809_0x1500_0x1504_Formatter();

        public JT809_0x1500_0x1504 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1504 jT809_0X1500_0X1504 = new JT809_0x1500_0x1504();
            jT809_0X1500_0X1504.CommandType = (JT809CommandType)reader.ReadByte();
            jT809_0X1500_0X1504.TraveldataLength = reader.ReadUInt32();
            jT809_0X1500_0X1504.TraveldataInfo = reader.ReadString((int)jT809_0X1500_0X1504.TraveldataLength);
            return jT809_0X1500_0X1504;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1504 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.CommandType);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.TraveldataInfo);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
