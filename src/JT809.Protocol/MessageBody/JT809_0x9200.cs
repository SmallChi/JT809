using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路车辆动态信息交换业务
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_EXG_MSG</para>
    /// <para>描述:上级平台作为客户端向下级平台服务端发送车辆动态信息交换业务</para>
    /// </summary>
    public class JT809_0x9200: JT809ExchangeMessageBodies, IJT809MessagePackFormatter<JT809_0x9200>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.从链路车辆动态信息交换业务.ToUInt16Value();
        public override string Description => "从链路车辆动态信息交换业务";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9200 value = new JT809_0x9200();
            //1078qq群808432702:大兄弟提供的 
            //由于车辆注册信息应答消息0x9201子业务不存在车牌号和颜色需要跳过
            if (config.Version == JT809Version.JTT2019)
            {
                var subBusinessType = reader.ReadVirtualUInt16();
                if (subBusinessType != JT809SubBusinessType.车辆注册信息应答消息.ToUInt16Value())
                {
                    var virtualHex = reader.ReadVirtualArray(21);
                    value.VehicleNo = reader.ReadString(21);
                    writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车牌号", value.VehicleNo);
                    value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
                    writer.WriteString($"[{value.VehicleColor.ToByteValue()}]车牌颜色", value.VehicleColor.ToString());
                }
            }
            else
            {
                var virtualHex = reader.ReadVirtualArray(21);
                value.VehicleNo = reader.ReadString(21);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车牌号", value.VehicleNo);
                value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
                writer.WriteString($"[{value.VehicleColor.ToByteValue()}]车牌颜色", value.VehicleColor.ToString());
            }
            value.SubBusinessType = reader.ReadUInt16();
            writer.WriteString($"[{value.SubBusinessType.ReadNumber()}]子业务类型标识", ((JT809SubBusinessType)value.SubBusinessType).ToString());
            value.DataLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.DataLength.ReadNumber()}]后续数据长度", value.DataLength);
            try
            {
                if (config.SubBusinessTypeFactory.TryGetValue(value.SubBusinessType, out object instance))
                {
                    if (instance is JT809SubBodies subBodies)
                    {
                        if (!subBodies.SkipSerialization)
                        {
                            writer.WriteStartObject("子业务类型");
                            instance.Analyze(ref reader, writer, config);
                            writer.WriteEndObject();
                        }
                    }
                }
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
        }

        public JT809_0x9200 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200 value = new JT809_0x9200();
            //1078qq群808432702:大兄弟提供的 
            //由于车辆注册信息应答消息0x9201子业务不存在车牌号和颜色需要跳过
            if(config.Version== JT809Version.JTT2019)
            {
                var subBusinessType = reader.ReadVirtualUInt16();
                if (subBusinessType != JT809SubBusinessType.车辆注册信息应答消息.ToUInt16Value())
                {
                    value.VehicleNo = reader.ReadString(21);
                    value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
                }
            }
            else
            {
                value.VehicleNo = reader.ReadString(21);
                value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
            }
            value.SubBusinessType = reader.ReadUInt16();
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

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200 value, IJT809Config config)
        {
            //1078qq群808432702:大兄弟提供的 
            //由于车辆注册信息应答消息0x9201子业务不存在车牌号和颜色需要跳过
            if (config.Version == JT809Version.JTT2019)
            {
                if (value.SubBusinessType != JT809SubBusinessType.车辆注册信息应答消息.ToUInt16Value())
                {
                    writer.WriteStringPadRight(value.VehicleNo, 21);
                    writer.WriteByte((byte)value.VehicleColor);
                }
            }
            else
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
