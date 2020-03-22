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
    public class JT809_0x1001_Formatter : IJT809MessagePackFormatter<JT809_0x1001>
    {
        public readonly static JT809_0x1001_Formatter Instance = new JT809_0x1001_Formatter();

        public JT809_0x1001 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1001 jT809_0X1001 = new JT809_0x1001();
            jT809_0X1001.UserId = reader.ReadUInt32();
            jT809_0X1001.Password = reader.ReadString(8);
            jT809_0X1001.MsgGNSSCENTERID = reader.ReadUInt32();
            jT809_0X1001.DownLinkIP = reader.ReadString(32);
            jT809_0X1001.DownLinkPort = reader.ReadUInt16();
            return jT809_0X1001;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1001 value, IJT809Config config)
        {
            writer.WriteUInt32(value.UserId);
            writer.WriteStringPadRight(value.Password, 8);
            writer.WriteUInt32(value.MsgGNSSCENTERID);
            writer.WriteStringPadRight(value.DownLinkIP, 32);
            writer.WriteUInt16(value.DownLinkPort);
        }
    }
}
