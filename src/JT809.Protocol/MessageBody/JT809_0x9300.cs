using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using System;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路平台间信息交互业务
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:上级平台往下级平台</para>
    /// <para>业务数据类型标识:DOWN_PLATFORM_MSG</para>
    /// <para>描述:上级平台向下级平台发送平台问交互信息</para>
    /// </summary>
    public class JT809_0x9300: JT809ExchangeMessageBodies, IJT809MessagePackFormatter<JT809_0x9300>
    {
        public override ushort MsgId => JT809BusinessType.从链路平台间信息交互业务.ToUInt16Value();
        public override string Description => "从链路平台间信息交互业务";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        public JT809_0x9300 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9300 jT809_0X9300 = new JT809_0x9300();
            jT809_0X9300.SubBusinessType = reader.ReadUInt16();
            jT809_0X9300.DataLength = reader.ReadUInt32();
            //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
            try
            {
                Type jT809SubBodiesImplType = config.SubBusinessTypeFactory.GetSubBodiesImplTypeBySubBusinessType(jT809_0X9300.SubBusinessType);
                if (jT809SubBodiesImplType != null)
                    jT809_0X9300.SubBodies = JT809MessagePackFormatterResolverExtensions.JT809DynamicDeserialize(
                                 config.GetMessagePackFormatterByType(jT809SubBodiesImplType),
                                 ref reader, config);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{jT809_0X9300.SubBusinessType.ToString()}");
            }
            return jT809_0X9300;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9300 value, IJT809Config config)
        {
            writer.WriteUInt16(value.SubBusinessType);
            //JT809.Protocol.Enums.JT809BusinessType 映射对应消息特性
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
                writer.WriteInt32Return(writer.GetCurrentPosition() - subContentLengthPosition - 4, subContentLengthPosition);
            }
            catch
            {
                throw new JT809Exception(JT809ErrorCode.SubBodiesParseError, $"SubBusinessType>{value.SubBusinessType.ToString()}");
            }
        }
    }
}
