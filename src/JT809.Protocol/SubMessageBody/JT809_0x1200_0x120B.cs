using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆电子运单应答消息
    /// <para>子业务类型标识:UP_CXG_MSG_TAKE_EWAYBILL_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的上报车辆电子运单请求消息，向上级平台上传车辆当前电子运单</para>
    /// </summary>
    public class JT809_0x1200_0x120B:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120B>
    {
        /// <summary>
        /// 电子运单数据体长度
        /// </summary>
        public uint EwaybillLength { get; set; }
        /// <summary>
        /// 电子运单数据内容
        /// </summary>
        public string EwaybillInfo { get; set; }
        public JT809_0x1200_0x120B Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x120B jT809_0X1200_0X120B = new JT809_0x1200_0x120B();
            jT809_0X1200_0X120B.EwaybillLength = reader.ReadUInt32();
            jT809_0X1200_0X120B.EwaybillInfo = reader.ReadString((int)jT809_0X1200_0X120B.EwaybillLength);
            return jT809_0X1200_0X120B;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120B value, IJT809Config config)
        {
            writer.WriteUInt32((uint)value.EwaybillInfo.Length);
            writer.WriteString(value.EwaybillInfo);
        }
    }
}
