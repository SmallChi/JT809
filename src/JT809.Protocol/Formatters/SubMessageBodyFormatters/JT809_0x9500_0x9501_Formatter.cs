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
    public class JT809_0x9500_0x9501_Formatter : IJT809MessagePackFormatter<JT809_0x9500_0x9501>
    {
        public readonly static JT809_0x9500_0x9501_Formatter Instance = new JT809_0x9500_0x9501_Formatter();

        public JT809_0x9500_0x9501 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9501 jT809_0X9500_0X9501 = new JT809_0x9500_0x9501();
            jT809_0X9500_0X9501.MonitorTel = reader.ReadString(20);
            return jT809_0X9500_0X9501;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9501 value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.MonitorTel, 20);
        }
    }
}
