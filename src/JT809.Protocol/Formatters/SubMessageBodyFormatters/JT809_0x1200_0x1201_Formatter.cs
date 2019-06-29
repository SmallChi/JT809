using JT809.Protocol.Extensions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Enums;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x1200_0x1201_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x1201>
    {
        public readonly static JT809_0x1200_0x1201_Formatter Instance = new JT809_0x1200_0x1201_Formatter();

        public JT809_0x1200_0x1201 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1201 jT809_0X1200_0X1201 = new JT809_0x1200_0x1201();
            jT809_0X1200_0X1201.PlateformId = reader.ReadBigNumber(11);
            jT809_0X1200_0X1201.ProducerId = reader.ReadBigNumber(11);
            jT809_0X1200_0X1201.TerminalModelType = reader.ReadString(20);
            jT809_0X1200_0X1201.TerminalId = reader.ReadString(7);
            jT809_0X1200_0X1201.TerminalId = jT809_0X1200_0X1201.TerminalId.ToUpper();
            jT809_0X1200_0X1201.TerminalSimCode = reader.ReadString(12);
            return jT809_0X1200_0X1201;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1201 value, IJT809Config config)
        {
            writer.WriteBigNumber(value.PlateformId, 11);
            writer.WriteBigNumber(value.ProducerId, 11);
            writer.WriteStringPadRight(value.TerminalModelType, 20);
            writer.WriteStringPadRight(value.TerminalId.ToUpper(), 7);
            writer.WriteStringPadRight(value.TerminalSimCode, 12);
        }
    }
}
