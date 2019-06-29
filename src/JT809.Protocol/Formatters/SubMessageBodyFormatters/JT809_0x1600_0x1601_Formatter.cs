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
    public class JT809_0x1600_0x1601_Formatter : IJT809MessagePackFormatter<JT809_0x1600_0x1601>
    {
        public readonly static JT809_0x1600_0x1601_Formatter Instance = new JT809_0x1600_0x1601_Formatter();

        public JT809_0x1600_0x1601 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1600_0x1601 jT809_0X9600_0X1601 = new JT809_0x1600_0x1601();
            jT809_0X9600_0X1601.CarInfo = reader.ReadRemainStringContent();
            return jT809_0X9600_0X1601;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1600_0x1601 value, IJT809Config config)
        {
            writer.WriteString(value.CarInfo);
        }
    }
}
