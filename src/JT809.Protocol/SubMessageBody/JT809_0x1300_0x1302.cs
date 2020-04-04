using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发平台间报文应答消息
    /// <para>子业务类型标识:UP_PLATFORM_MSG_INFO_ACK</para>
    /// <para>描述:下级平台收到上级平台发送的下发平台间报文请求消息后，发送应答消息</para>
    /// </summary>
    public class JT809_0x1300_0x1302:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1300_0x1302>
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发平台间报文应答消息.ToUInt16Value();

        public override string Description => "下发平台间报文应答消息";
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
        public JT809_0x1300_0x1302 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1300_0x1302 jT809_0X1200_0X1302 = new JT809_0x1300_0x1302();
            jT809_0X1200_0X1302.InfoID = reader.ReadUInt32();
            return jT809_0X1200_0X1302;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1300_0x1302 value, IJT809Config config)
        {
            writer.WriteUInt32(value.InfoID);
        }
    }
}
