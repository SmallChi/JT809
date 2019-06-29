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
    public class JT809_0x1007_Formatter : IJT809MessagePackFormatter<JT809_0x1007>
    {
        public readonly static JT809_0x1007_Formatter Instance = new JT809_0x1007_Formatter();

        public JT809_0x1007 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1007 jT809_0X1007 = new JT809_0x1007();
            jT809_0X1007.ErrorCode = (JT809_0x1007_ErrorCode)reader.ReadByte();
            return jT809_0X1007;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1007 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ErrorCode);
        }
    }
}
