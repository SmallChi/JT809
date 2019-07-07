using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using System;

namespace JT809.Protocol.Test.JT1078
{
    public class JT808_JT1078_0x1700_Formatter : IJT809MessagePackFormatter<JT808_JT1078_0x1700>
    {
        public JT808_JT1078_0x1700 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT808_JT1078_0x1700 jT808_JT1078_0X1700 = new JT808_JT1078_0x1700();
            jT808_JT1078_0X1700.SubBusinessType = reader.ReadUInt16();
            try
            {
                Type jT809SubBodiesImplType = config.SubBusinessTypeFactory.GetSubBodiesImplTypeBySubBusinessType(jT808_JT1078_0X1700.SubBusinessType);
                if (jT809SubBodiesImplType != null)
                    jT808_JT1078_0X1700.SubBodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                 config.GetMessagePackFormatterByType(jT809SubBodiesImplType),
                                 ref reader, config);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{jT808_JT1078_0X1700.SubBusinessType.ToString()}");
            }
            return jT808_JT1078_0X1700;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT808_JT1078_0x1700 value, IJT809Config config)
        {
            try
            {
                writer.WriteUInt16(value.SubBusinessType);
                if (value.SubBodies != null)
                {
                    JT809MessagePackFormatterResolverExtensions.JT809DynamicSerialize(
                               config.GetMessagePackFormatterByType(value.SubBodies.GetType()),
                               ref writer, value.SubBodies,
                               config);
                }
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
        }
    }
}