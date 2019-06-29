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
    public class JT809_0x1500_0x1501_Formatter : IJT809MessagePackFormatter<JT809_0x1500_0x1501>
    {
        public readonly static JT809_0x1500_0x1501_Formatter Instance = new JT809_0x1500_0x1501_Formatter();

        public JT809_0x1500_0x1501 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1501 jT809_0X1500_0X1501 = new JT809_0x1500_0x1501();
            jT809_0X1500_0X1501.Result = (JT809_0x1501_Result)reader.ReadByte();
            return jT809_0X1500_0X1501;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1501 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
