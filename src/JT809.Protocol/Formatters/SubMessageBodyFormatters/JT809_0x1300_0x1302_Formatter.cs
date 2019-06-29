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
    public class JT809_0x1300_0x1302_Formatter : IJT809MessagePackFormatter<JT809_0x1300_0x1302>
    {
        public readonly static JT809_0x1300_0x1302_Formatter Instance = new JT809_0x1300_0x1302_Formatter();

        public JT809_0x1300_0x1302 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1300_0x1302 jT809_0X1200_0X1302 = new JT809_0x1300_0x1302();
            jT809_0X1200_0X1302.InfoID = reader.ReadUInt32();
            return jT809_0X1200_0X1302;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1300_0x1302 value, IJT809Config config)
        {
            writer.WriteUInt32(value.InfoID);
        }
    }
}
