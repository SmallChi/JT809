using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  车辆注册信息应答消息
    ///  <para>子业务类型标识:DOWN_EXG_MSG_REGISTER_ACK</para>
    ///  <para>描述:上级平台在收到下级平台上报的车辆注册信息后，向下级平台发送车辆注册应答消息</para>
    /// </summary>
    public class JT809_0x9200_0x9201:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9201>,IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆注册信息应答消息.ToUInt16Value();

        public override string Description => "车辆注册信息应答消息";
        /// <summary>
        /// 车辆注册信息消息源报文序号
        /// </summary>
        public uint MsgSn { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public JT809_0x9201_Result Result { get; set; }

        public JT809_0x9200_0x9201 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9200_0x9201();
            value.MsgSn = reader.ReadUInt32();
            value.Result = (JT809_0x9201_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9201 value, IJT809Config config)
        {
            writer.WriteUInt32(value.MsgSn);
            writer.WriteByte((byte)value.Result);
        }
    }
}
