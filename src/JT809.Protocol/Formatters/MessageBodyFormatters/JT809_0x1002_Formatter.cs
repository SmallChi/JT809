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
    public class JT809_0x1002_Formatter : IJT809MessagePackFormatter<JT809_0x1002>
    {
        public readonly static JT809_0x1002_Formatter Instance = new JT809_0x1002_Formatter();

        public JT809_0x1002 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1002 jT809_0X1002 = new JT809_0x1002();
            jT809_0X1002.Result = (JT809_0x1002_Result)reader.ReadByte();
            jT809_0X1002.VerifyCode = reader.ReadUInt32();
            return jT809_0X1002;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1002 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
            writer.WriteUInt32(value.VerifyCode);
        }
    }
}
