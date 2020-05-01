using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    /// 从链路连接应答信息
    /// <para>链路类型:从链路</para>
    /// <para>消息方问:下级平台往上级平台</para>
    /// <para>业务数据类型标识:DOWN_CONNNECT_RSP</para>
    /// <para>描述：下级平台作为服务器端向上级平台客户端返回从链路连接应答消息，上级平台在接收到该应答消息结果后</para>
    /// </summary>
    public class JT809_0x9002:JT809Bodies, IJT809MessagePackFormatter<JT809_0x9002>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.从链路连接应答信息.ToUInt16Value();
        public override string Description => "从链路连接应答信息";
        public override JT809_LinkType LinkType => JT809_LinkType.subordinate;
        /// <summary>
        /// 验证结果
        /// </summary>
        public JT809_0x9002_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9002 value = new JT809_0x9002();
            value.Result = (JT809_0x9002_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}验证结果]", value.Result.ToString());
        }

        public JT809_0x9002 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9002 value = new JT809_0x9002();
            value.Result = (JT809_0x9002_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9002 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
