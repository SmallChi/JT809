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
    public class JT809_0x1200_0x120C_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x120C>
    {
        public readonly static JT809_0x1200_0x120C_Formatter Instance = new JT809_0x1200_0x120C_Formatter();

        public JT809_0x1200_0x120C Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120C jT809_0X1200_0X120C = new JT809_0x1200_0x120C();
            jT809_0X1200_0X120C.DriverName = reader.ReadString(16);
            jT809_0X1200_0X120C.DriverID = reader.ReadString(20);
            jT809_0X1200_0X120C.Licence = reader.ReadString(40);
            jT809_0X1200_0X120C.OrgName = reader.ReadString(200);
            return jT809_0X1200_0X120C;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120C value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.DriverName, 16);
            writer.WriteStringPadRight(value.DriverID, 20);
            writer.WriteStringPadRight(value.Licence, 40);
            writer.WriteStringPadRight(value.OrgName, 200);
        }
    }
}
