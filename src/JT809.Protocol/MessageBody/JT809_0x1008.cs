using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 下级平台主动关闭主从链路通知消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_CLOSELINIC INFORM</para>
    /// <para>描述:下级平台作为服务端，发现从链路出现异常时，下级平台通过从链路向上级平台发送本消息，通知上级平台下级平台即将关闭主从链路</para>
    /// </summary>
    public class JT809_0x1008:JT809Bodies, IJT809MessagePackFormatter<JT809_0x1008>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.下级平台主动关闭主从链路通知消息.ToUInt16Value();
        public override string Description => "下级平台主动关闭主从链路通知消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        /// <summary>
        /// 链路关闭原因
        /// </summary>
        public JT809_0x1008_ReasonCode ReasonCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1008 value = new JT809_0x1008();
            value.ReasonCode = (JT809_0x1008_ReasonCode)reader.ReadByte();
            writer.WriteString($"[{value.ReasonCode.ToByteValue()}]链路关闭原因", value.ReasonCode.ToString());
        }

        public JT809_0x1008 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1008 value = new JT809_0x1008();
            value.ReasonCode = (JT809_0x1008_ReasonCode)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1008 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
