using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Internal;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using JT809.Protocol.MessageBody;

namespace JT809.Protocol.Formatters
{
    public class JT809BodiesFormatter<TJT809Bodies> : IJT809MessagePackFormatter<TJT809Bodies>
       where TJT809Bodies: JT809ExchangeMessageBodies, new ()
    {
        public readonly static JT809BodiesFormatter<JT809_0x1200> Instance_0x1200 = new JT809BodiesFormatter<JT809_0x1200>();
        public readonly static JT809BodiesFormatter<JT809_0x1400> Instance_0x1400 = new JT809BodiesFormatter<JT809_0x1400>();
        public readonly static JT809BodiesFormatter<JT809_0x1500> Instance_0x1500 = new JT809BodiesFormatter<JT809_0x1500>();
        public readonly static JT809BodiesFormatter<JT809_0x1600> Instance_0x1600 = new JT809BodiesFormatter<JT809_0x1600>();
        public readonly static JT809BodiesFormatter<JT809_0x9200> Instance_0x9200 = new JT809BodiesFormatter<JT809_0x9200>();
        public readonly static JT809BodiesFormatter<JT809_0x9400> Instance_0x9400 = new JT809BodiesFormatter<JT809_0x9400>();
        public readonly static JT809BodiesFormatter<JT809_0x9500> Instance_0x9500 = new JT809BodiesFormatter<JT809_0x9500>();
        public readonly static JT809BodiesFormatter<JT809_0x9600> Instance_0x9600 = new JT809BodiesFormatter<JT809_0x9600>();

        public TJT809Bodies Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            TJT809Bodies jT809Bodies = new TJT809Bodies();
            jT809Bodies.VehicleNo = reader.ReadString(21);
            jT809Bodies.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
            jT809Bodies.SubBusinessType = reader.ReadUInt16();
            jT809Bodies.DataLength = reader.ReadUInt32();
            try
            {
                Type jT809SubBodiesImplType = config.SubBusinessTypeFactory.GetSubBodiesImplTypeBySubBusinessType(jT809Bodies.SubBusinessType);
                if (jT809SubBodiesImplType != null)
                    jT809Bodies.SubBodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                 config.GetMessagePackFormatterByType(jT809SubBodiesImplType),
                                 ref reader, config);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{jT809Bodies.SubBusinessType.ToString()}");
            }
            return jT809Bodies;
        }

        public void Serialize(ref JT809MessagePackWriter writer, TJT809Bodies value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.VehicleNo, 21);
            writer.WriteByte((byte)value.VehicleColor);
            writer.WriteUInt16(value.SubBusinessType);
            try
            {
                // 先写入内容，然后在根据内容反写内容长度
                writer.Skip(4, out int subContentLengthPosition);
                if (value.SubBodies != null)
                {
                    JT809MessagePackFormatterResolverExtensions.JT809DynamicSerialize(
                               config.GetMessagePackFormatterByType(value.SubBodies.GetType()),
                               ref writer, value.SubBodies,
                               config);
                }
                writer.WriteInt32Return(writer.GetCurrentPosition()- subContentLengthPosition - 4, subContentLengthPosition);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
        }
    }
}
