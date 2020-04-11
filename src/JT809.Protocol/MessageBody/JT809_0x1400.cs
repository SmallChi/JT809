using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路报警信息交互消息
    /// <para>主链路车辆报警信息业务</para>
    /// <para>链路类型:主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_WARN_MSG</para>
    /// <para>描述:下级平台向上级平台发送车辆报警信息业务</para>
    /// </summary>
    public class JT809_0x1400: JT809ExchangeMessageBodies, IJT809MessagePackFormatter<JT809_0x1400>, IJT809_2019_Version
    {
        public override ushort MsgId => JT809BusinessType.主链路报警信息交互消息.ToUInt16Value();
        public override string Description => "主链路报警信息交互消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;

        public JT809_0x1400 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400 value = new JT809_0x1400();
            if (config.Version == JT809Version.JTT2013)
            {
                value.VehicleNo = reader.ReadString(21);
                value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
                value.SubBusinessType = reader.ReadUInt16();
            }
            value.DataLength = reader.ReadUInt32();
            try
            {
                if (config.SubBusinessTypeFactory.TryGetValue(value.SubBusinessType, out object instance))
                {
                    if (instance is JT809SubBodies subBodies)
                    {
                        if (!subBodies.SkipSerialization)
                        {
                            value.SubBodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                instance,
                                ref reader, config);
                        }
                    }
                }
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2013)
            {
                writer.WriteStringPadRight(value.VehicleNo, 21);
                writer.WriteByte((byte)value.VehicleColor);
            }
            writer.WriteUInt16(value.SubBusinessType);
            try
            {
                // 先写入内容，然后在根据内容反写内容长度
                writer.Skip(4, out int subContentLengthPosition);
                if (value.SubBodies != null)
                {
                    if (!value.SubBodies.SkipSerialization)
                    {
                        JT809MessagePackFormatterResolverExtensions.JT809DynamicSerialize(
                                   value.SubBodies,
                                   ref writer, value.SubBodies,
                                   config);
                    }
                }
                writer.WriteInt32Return(writer.GetCurrentPosition() - subContentLengthPosition - 4, subContentLengthPosition);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
        }
    }
}
