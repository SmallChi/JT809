using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessageBody;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9002_Formatter : IJT809MessagePackFormatter<JT809_0x9002>
    {
        public readonly static JT809_0x9002_Formatter Instance = new JT809_0x9002_Formatter();

        public JT809_0x9002 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9002 jT809_0X9002 = new JT809_0x9002();
            jT809_0X9002.Result = (JT809_0x9002_Result)reader.ReadByte();
            return jT809_0X9002;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9002 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
