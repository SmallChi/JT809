using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发车辆报文请求
    /// <para>子业务类型标识:DOWN_CTRL_MSG_TEXT_INFO</para>
    /// <para>描述:用于上级平台向下级平台下发报文到某指定车辆</para>
    /// </summary>
    public class JT809_0x9500_0x9503:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9503>
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
        public byte MsgPriority { get; set; }
        /// <summary>
        /// 报文信息长度
        /// </summary>
        public uint MsgLength { get; set; }
        /// <summary>
        /// 报文信息内容
        /// </summary>
        public string MsgContent { get; set; }
        public JT809_0x9500_0x9503 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9503 jT809_0X9500_0X9503 = new JT809_0x9500_0x9503();
            jT809_0X9500_0X9503.MsgSequence = reader.ReadUInt32();
            jT809_0X9500_0X9503.MsgPriority = reader.ReadByte();
            jT809_0X9500_0X9503.MsgLength = reader.ReadUInt32();
            jT809_0X9500_0X9503.MsgContent = reader.ReadString((int)jT809_0X9500_0X9503.MsgLength);
            return jT809_0X9500_0X9503;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9503 value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgSequence);
            writer.WriteByte(value.MsgPriority);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.MsgContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
