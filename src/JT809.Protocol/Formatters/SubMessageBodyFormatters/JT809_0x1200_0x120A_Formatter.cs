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
    public class JT809_0x1200_0x120A_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x120A>
    {
        public readonly static JT809_0x1200_0x120A_Formatter Instance = new JT809_0x1200_0x120A_Formatter();

        public JT809_0x1200_0x120A Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120A jT809_0X1200_0X120A = new JT809_0x1200_0x120A();
            jT809_0X1200_0X120A.DriverName = reader.ReadString(16);
            jT809_0X1200_0X120A.DriverID = reader.ReadString(20);
            jT809_0X1200_0X120A.Licence = reader.ReadString(40);
            jT809_0X1200_0X120A.OrgName = reader.ReadString(200);
            return jT809_0X1200_0X120A;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120A value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.DriverName, 16);
            writer.WriteStringPadRight(value.DriverID, 20);
            writer.WriteStringPadRight(value.Licence, 40);
            writer.WriteStringPadRight(value.OrgName, 200);
        }
    }
}
