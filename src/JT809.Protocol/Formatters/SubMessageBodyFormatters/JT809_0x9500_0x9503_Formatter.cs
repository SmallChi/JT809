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
    public class JT809_0x9500_0x9503_Formatter : IJT809MessagePackFormatter<JT809_0x9500_0x9503>
    {
        public readonly static JT809_0x9500_0x9503_Formatter Instance = new JT809_0x9500_0x9503_Formatter();

        public JT809_0x9500_0x9503 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9503 jT809_0X9500_0X9503 = new JT809_0x9500_0x9503();
            jT809_0X9500_0X9503.MsgSequence = reader.ReadUInt32();
            jT809_0X9500_0X9503.MsgPriority = reader.ReadByte();
            jT809_0X9500_0X9503.MsgLength = reader.ReadUInt32();
            jT809_0X9500_0X9503.MsgContent = reader.ReadString((int)jT809_0X9500_0X9503.MsgLength);
            return jT809_0X9500_0X9503;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9503 value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgSequence);
            writer.WriteByte(value.MsgPriority);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.MsgContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
