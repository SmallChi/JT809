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
    public class JT809_0x1003_Formatter : IJT809MessagePackFormatter<JT809_0x1003>
    {
        public readonly static JT809_0x1003_Formatter Instance = new JT809_0x1003_Formatter();
        public JT809_0x1003 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1003 jT809_0X1003 = new JT809_0x1003();
            jT809_0X1003.UserId = reader.ReadUInt32();
            jT809_0X1003.Password = reader.ReadString(8);
            return jT809_0X1003;
        }
        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1003 value, IJT809Config config)
        {
            writer.WriteUInt32(value.UserId);
            writer.WriteStringPadLeft(value.Password, 8);
        }
    }
}
