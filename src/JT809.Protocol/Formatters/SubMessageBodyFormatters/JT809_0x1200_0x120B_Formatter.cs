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
    public class JT809_0x1200_0x120B_Formatter : IJT809MessagePackFormatter<JT809_0x1200_0x120B>
    {
        public readonly static JT809_0x1200_0x120B_Formatter Instance = new JT809_0x1200_0x120B_Formatter();

        public JT809_0x1200_0x120B Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120B jT809_0X1200_0X120B = new JT809_0x1200_0x120B();
            jT809_0X1200_0X120B.EwaybillLength = reader.ReadUInt32();
            jT809_0X1200_0X120B.EwaybillInfo = reader.ReadString((int)jT809_0X1200_0X120B.EwaybillLength);
            return jT809_0X1200_0X120B;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120B value, IJT809Config config)
        {
            writer.WriteUInt32((uint)value.EwaybillInfo.Length);
            writer.WriteString(value.EwaybillInfo);
        }
    }
}
