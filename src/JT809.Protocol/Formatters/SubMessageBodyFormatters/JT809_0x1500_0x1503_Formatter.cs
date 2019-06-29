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
    public class JT809_0x1500_0x1503_Formatter : IJT809MessagePackFormatter<JT809_0x1500_0x1503>
    {
        public readonly static JT809_0x1500_0x1503_Formatter Instance = new JT809_0x1500_0x1503_Formatter();

        public JT809_0x1500_0x1503 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = new JT809_0x1500_0x1503();
            jT809_0X1500_0X1503.MsgID = reader.ReadUInt32();
            jT809_0X1500_0X1503.Result = (JT809_0x1503_Result)reader.ReadByte();
            return jT809_0X1500_0X1503;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1503 value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgID);
            writer.WriteByte((byte)value.Result);
        }
    }
}
