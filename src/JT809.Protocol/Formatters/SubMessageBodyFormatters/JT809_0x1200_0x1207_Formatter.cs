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
    public class JT809_0x1200_0x1207_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x1207>
    {
        public readonly static JT809_0x1200_0x1207_Formatter Instance = new JT809_0x1200_0x1207_Formatter();

        public JT809_0x1200_0x1207 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1207 jT809_0X1200_0X1207 = new JT809_0x1200_0x1207();
            jT809_0X1200_0X1207.StartTime = reader.ReadUTCDateTime();
            jT809_0X1200_0X1207.EndTime = reader.ReadUTCDateTime();
            return jT809_0X1200_0X1207;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1207 value, IJT809Config config)
        {
           writer.WriteUTCDateTime(value.StartTime);
            writer.WriteUTCDateTime(value.EndTime);
        }
    }
}
