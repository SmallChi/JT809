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
    public class JT809_0x9500_0x9505_Formatter : IJT809MessagePackFormatter<JT809_0x9500_0x9505>
    {
        public readonly static JT809_0x9500_0x9505_Formatter Instance = new JT809_0x9500_0x9505_Formatter();

        public JT809_0x9500_0x9505 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9505 jT809_0X9500_0X9505 = new JT809_0x9500_0x9505();
            jT809_0X9500_0X9505.AuthenticationCode = reader.ReadBCD(20);
            jT809_0X9500_0X9505.AccessPointName = reader.ReadString(20);
            jT809_0X9500_0X9505.UserName = reader.ReadString(49);
            jT809_0X9500_0X9505.Password = reader.ReadString(22);
            jT809_0X9500_0X9505.ServerIP = reader.ReadString(32);
            jT809_0X9500_0X9505.TcpPort = reader.ReadUInt16();
            jT809_0X9500_0X9505.UdpPort = reader.ReadUInt16();
            jT809_0X9500_0X9505.EndTime = reader.ReadUTCDateTime();
            return jT809_0X9500_0X9505;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9505 value, IJT809Config config)
        {
            writer.WriteBCD(value.AuthenticationCode, 20);
            writer.WriteStringPadRight(value.AccessPointName, 20);
            writer.WriteStringPadRight(value.UserName, 49);
            writer.WriteStringPadRight(value.Password, 22);
            writer.WriteStringPadRight(value.ServerIP, 32);
            writer.WriteUInt16(value.TcpPort);
            writer.WriteUInt16(value.UdpPort);
            writer.WriteUTCDateTime(value.EndTime);
        }
    }
}
