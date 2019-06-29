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
    public class JT809_0x9200_0x9207_Formatter : IJT809MessagePackFormatter<JT809_0x9200_0x9207>
    {
        public readonly static JT809_0x9200_0x9207_Formatter Instance = new JT809_0x9200_0x9207_Formatter();

        public JT809_0x9200_0x9207 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9207 jT809_0X1200_0x9207 = new JT809_0x9200_0x9207();
            jT809_0X1200_0x9207.Result = (JT809_0x9207_Result)reader.ReadByte();
            return jT809_0X1200_0x9207;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9207 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
