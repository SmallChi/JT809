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
    public class JT809_0x9101_Formatter : IJT809MessagePackFormatter<JT809_0x9101>
    {
        public readonly static JT809_0x9101_Formatter Instance = new JT809_0x9101_Formatter();

        public JT809_0x9101 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9101 jT809_0X9101 = new JT809_0x9101();
            jT809_0X9101.DynamicInfoTotal = reader.ReadUInt32();
            jT809_0X9101.StartTime = reader.ReadUInt64();
            jT809_0X9101.EndTime = reader.ReadUInt64();
            return jT809_0X9101;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9101 value, IJT809Config config)
        {
            writer.WriteUInt32(value.DynamicInfoTotal);
            writer.WriteUInt64(value.StartTime);
            writer.WriteUInt64(value.EndTime);
        }
    }
}
