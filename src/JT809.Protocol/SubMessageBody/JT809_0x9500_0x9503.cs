using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发车辆报文请求
    /// <para>子业务类型标识:DOWN_CTRL_MSG_TEXT_INFO</para>
    /// <para>描述:用于上级平台向下级平台下发报文到某指定车辆</para>
    /// </summary>
    public class JT809_0x9500_0x9503:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9503>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发车辆报文请求.ToUInt16Value();

        public override string Description => "下发车辆报文请求";
        /// <summary>
        /// 消息ID序号
        /// </summary>
        public uint MsgSequence { get; set; }
        /// <summary>
        /// 报文优先级
        /// </summary>
        public JT809_0x9503_MsgPriority MsgPriority { get; set; }
        /// <summary>
        /// 报文信息长度
        /// </summary>
        public uint MsgLength { get; set; }
        /// <summary>
        /// 报文信息内容
        /// </summary>
        public string MsgContent { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9500_0x9503 value = new JT809_0x9500_0x9503();
            value.MsgSequence = reader.ReadUInt32();
            writer.WriteNumber($"[{value.MsgSequence.ReadNumber()}]消息ID序号", value.MsgSequence);
            value.MsgPriority = (JT809_0x9503_MsgPriority)reader.ReadByte();
            writer.WriteString($"[{value.MsgPriority.ToByteValue()}]报文优先级", value.MsgPriority.ToString());
            value.MsgLength = reader.ReadUInt32();
            writer.WriteNumber($"[{ value.MsgLength.ReadNumber()}]报文信息长度", value.MsgLength);
            var virtualHex = reader.ReadVirtualArray((int)value.MsgLength);
            value.MsgContent = reader.ReadString((int)value.MsgLength);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]报文信息内容", value.MsgContent);
        }

        public JT809_0x9500_0x9503 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9503 value = new JT809_0x9500_0x9503();
            value.MsgSequence = reader.ReadUInt32();
            value.MsgPriority = (JT809_0x9503_MsgPriority)reader.ReadByte();
            value.MsgLength = reader.ReadUInt32();
            value.MsgContent = reader.ReadString((int)value.MsgLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9503 value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgSequence);
            writer.WriteByte(value.MsgPriority.ToByteValue());
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.MsgContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
