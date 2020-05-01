using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 主链路断开通知消息
    /// <para>链路类型:从链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务数据类型标识:UP_DISCONNECT_INFORM</para>
    /// <para>描述:'当主链路中断后，下级平台可通过从链路向上级平台发送本消息通知上级平台主链路中断</para>
    /// <para>主链路连接保持应答消息,数据体为空</para>
    /// <para>本条消息无需被通知方应答</para>
    /// </summary>
    public class JT809_0x1007:JT809Bodies, IJT809MessagePackFormatter<JT809_0x1007>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.主链路断开通知消息.ToUInt16Value();
        public override string Description => "主链路断开通知消息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x1007_ErrorCode ErrorCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1007 value = new JT809_0x1007();
            value.ErrorCode = (JT809_0x1007_ErrorCode)reader.ReadByte();
            writer.WriteString($"[{value.ErrorCode.ToByteValue()}]错误代码", value.ErrorCode.ToString());
        }

        public JT809_0x1007 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1007 value = new JT809_0x1007();
            value.ErrorCode = (JT809_0x1007_ErrorCode)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1007 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ErrorCode);
        }
    }
}
