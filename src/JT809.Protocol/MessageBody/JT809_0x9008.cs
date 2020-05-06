using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 上级平台主动关闭链路通知消息
    /// <para>业务数据类型标识:DOWN_CLOSELINK_INFORM</para>
    /// </summary>
    public class JT809_0x9008:JT809Bodies, IJT809MessagePackFormatter<JT809_0x9008>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.上级平台主动关闭链路通知消息.ToUInt16Value();
        public override string Description => "上级平台主动关闭链路通知消息";

        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        /// <summary>
        /// 链路关闭原因
        /// </summary>
        public JT809_0x9008_ReasonCode ReasonCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9008 value = new JT809_0x9008();
            value.ReasonCode = (JT809_0x9008_ReasonCode)reader.ReadByte();
            writer.WriteString($"[{value.ReasonCode.ToByteValue()}]链路关闭原因", value.ReasonCode.ToString());
        }

        public JT809_0x9008 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9008 value = new JT809_0x9008();
            value.ReasonCode = (JT809_0x9008_ReasonCode)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9008 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
