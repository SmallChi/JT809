using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using JT809.Protocol.Internal;
using JT809.Protocol.MessageBody;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.MessageBodyFormatters
{
    public class JT809_0x9300_Formatter : IJT809MessagePackFormatter<JT809_0x9300>
    {
        public readonly static JT809_0x9300_Formatter Instance = new JT809_0x9300_Formatter();

        public JT809_0x9300 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9300 jT809_0X9300 = new JT809_0x9300();
            jT809_0X9300.SubBusinessType = (JT809SubBusinessType)reader.ReadUInt16();
            jT809_0X9300.DataLength = reader.ReadUInt32();
            //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
            try
            {
                jT809_0X9300.SubBodies = jT809_0X9300.SubBusinessType.Deserialize(ref reader, config);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{jT809_0X9300.SubBusinessType.ToString()}");
            }
            return jT809_0X9300;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9300 value, IJT809Config config)
        {
            writer.WriteUInt16((ushort)value.SubBusinessType);
            //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
            try
            {
                // 先写入内容，然后在根据内容反写内容长度
                writer.Skip(4, out int subContentLengthPosition);
                value.SubBusinessType.Serialize(ref writer, value.SubBodies, config);
                writer.WriteInt32Return(writer.GetCurrentPosition() - subContentLengthPosition - 4, subContentLengthPosition);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
        }
    }
}
