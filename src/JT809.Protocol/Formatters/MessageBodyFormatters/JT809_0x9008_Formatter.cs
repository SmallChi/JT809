using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9008_Formatter : IJT809MessagePackFormatter<JT809_0x9008>
    {
        public readonly static JT809_0x9008_Formatter Instance = new JT809_0x9008_Formatter();

        public JT809_0x9008 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9008 jT809_0X9008 = new JT809_0x9008();
            jT809_0X9008.ReasonCode = (JT809_0x9008_ReasonCode)reader.ReadByte();
            return jT809_0X9008;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9008 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
