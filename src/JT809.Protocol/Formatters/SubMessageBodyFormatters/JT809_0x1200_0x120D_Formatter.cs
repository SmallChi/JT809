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
    public class JT809_0x1200_0x120D_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x120D>
    {
        public readonly static JT809_0x1200_0x120D_Formatter Instance = new JT809_0x1200_0x120D_Formatter();

        public JT809_0x1200_0x120D Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120D jT809_0X1200_0X120D = new JT809_0x1200_0x120D();
            jT809_0X1200_0X120D.EwaybillLength = reader.ReadUInt32();
            jT809_0X1200_0X120D.EwaybillInfo = reader.ReadString((int)jT809_0X1200_0X120D.EwaybillLength);
            return jT809_0X1200_0X120D;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120D value, IJT809Config config)
        {
            writer.WriteUInt32((uint)value.EwaybillInfo.Length);
            writer.WriteString(value.EwaybillInfo);
        }
    }
}
