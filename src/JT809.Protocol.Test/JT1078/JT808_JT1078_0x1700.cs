using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Test.JT1078
{
    public class JT808_JT1078_0x1700 : JT809ExchangeMessageBodies,IJT809MessagePackFormatter<JT808_JT1078_0x1700>
    {
        public override ushort MsgId => 0x1700;

        public override JT809_LinkType LinkType =>  JT809_LinkType.main;

        public override string Description => "0x1700";

        public JT808_JT1078_0x1700 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT808_JT1078_0x1700 jT808_JT1078_0X1700 = new JT808_JT1078_0x1700();
            jT808_JT1078_0X1700.VehicleNo = reader.ReadString(21);
            jT808_JT1078_0X1700.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
            jT808_JT1078_0X1700.SubBusinessType = reader.ReadUInt16();
            jT808_JT1078_0X1700.DataLength = reader.ReadUInt32();
            try
            {
                if (config.SubBusinessTypeFactory.TryGetValue(jT808_JT1078_0X1700.SubBusinessType, out object instance))
                {
                    if (instance is JT809SubBodies subBodies)
                    {
                        if (!subBodies.SkipSerialization)
                        {
                            jT808_JT1078_0X1700.SubBodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                instance,
                                ref reader, config);
                        }
                    }
                }
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
                writer.WriteStringPadRight(value.VehicleNo, 21);
                writer.WriteByte((byte)value.VehicleColor);
                writer.WriteUInt16(value.SubBusinessType);
                // 先写入内容，然后在根据内容反写内容长度
                writer.Skip(4, out int subContentLengthPosition);
                if (value.SubBodies != null)
                {
                   
                    JT809MessagePackFormatterResolverExtensions.JT809DynamicSerialize(
                               value.SubBodies,
                               ref writer, value.SubBodies,
                               config);
                }
                writer.WriteInt32Return(writer.GetCurrentPosition() - subContentLengthPosition - 4, subContentLengthPosition);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType}");
            }
        }
    }
}
