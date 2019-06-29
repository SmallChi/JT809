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
    public class JT809_0x1400_0x1403_Formatter : IJT809MessagePackFormatter<JT809_0x1400_0x1403>
    {
        public readonly static JT809_0x1400_0x1403_Formatter Instance = new JT809_0x1400_0x1403_Formatter();

        public JT809_0x1400_0x1403 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400_0x1403 jT809_0X1400_0X1403 = new JT809_0x1400_0x1403();
            jT809_0X1400_0X1403.InfoID = reader.ReadUInt32();
            jT809_0X1400_0X1403.Result = (JT809_0x1403_Result)reader.ReadByte();
            return jT809_0X1400_0X1403;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1403 value, IJT809Config config)
        {
            writer.WriteUInt32(value.InfoID);
            writer.WriteByte((byte)value.Result);
        }
    }
}
