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
    public class JT809_0x9500_0x9502_Formatter : IJT809MessagePackFormatter<JT809_0x9500_0x9502>
    {
        public readonly static JT809_0x9500_0x9502_Formatter Instance = new JT809_0x9500_0x9502_Formatter();

        public JT809_0x9500_0x9502 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9502 jT809_0X9500_0X9502 = new JT809_0x9500_0x9502();
            jT809_0X9500_0X9502.LensID = reader.ReadByte();
            jT809_0X9500_0X9502.SizeType = reader.ReadByte();
            return jT809_0X9500_0X9502;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9502 value, IJT809Config config)
        {
            writer.WriteByte(value.LensID);
            writer.WriteByte(value.SizeType);
        }
    }
}
