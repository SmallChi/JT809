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
    public class JT809_0x1400_0x1401_Formatter : IJT809MessagePackFormatter<JT809_0x1400_0x1401>
    {
        public readonly static JT809_0x1400_0x1401_Formatter Instance = new JT809_0x1400_0x1401_Formatter();

        public JT809_0x1400_0x1401 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400_0x1401 jT809_0X1400_0X1401 = new JT809_0x1400_0x1401();
            jT809_0X1400_0X1401.SupervisionID = reader.ReadUInt32();
            jT809_0X1400_0X1401.Result = (JT809_0x1401_Result)reader.ReadByte();
            return jT809_0X1400_0X1401;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1401 value, IJT809Config config)
        {
            writer.WriteUInt32(value.SupervisionID);
            writer.WriteByte((byte)value.Result);
        }
    }
}
