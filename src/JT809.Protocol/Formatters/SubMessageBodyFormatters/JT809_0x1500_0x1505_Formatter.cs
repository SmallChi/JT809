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
    public class JT809_0x1500_0x1505_Formatter : IJT809MessagePackFormatter<JT809_0x1500_0x1505>
    {
        public readonly static JT809_0x1500_0x1505_Formatter Instance = new JT809_0x1500_0x1505_Formatter();

        public JT809_0x1500_0x1505 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = new JT809_0x1500_0x1505();
            jT809_0X1500_0X1505.Result = (JT809_0x1505_Result)reader.ReadByte();
            return jT809_0X1500_0X1505;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1505 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
