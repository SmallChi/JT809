using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发车辆报文应答消息
    /// <para>子业务类型标识:UP_CTRL_MSG_TEXT_INFO_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的报文是否成功到达指定车辆</para>
    /// </summary>
    public class JT809_0x1500_0x1503:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1503>
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发车辆报文应答消息.ToUInt16Value();

        public override string Description => "下发车辆报文应答消息";
        /// <summary>
        /// 消息ID
        /// 对应“下发车辆报文请求消息”中的MSG_ID
        /// </summary>
        public uint MsgID { get; set; }
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1503_Result Result { get; set; }
        public JT809_0x1500_0x1503 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1503 jT809_0X1500_0X1503 = new JT809_0x1500_0x1503();
            jT809_0X1500_0X1503.MsgID = reader.ReadUInt32();
            jT809_0X1500_0X1503.Result = (JT809_0x1503_Result)reader.ReadByte();
            return jT809_0X1500_0X1503;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1503 value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgID);
            writer.WriteByte((byte)value.Result);
        }
    }
}
