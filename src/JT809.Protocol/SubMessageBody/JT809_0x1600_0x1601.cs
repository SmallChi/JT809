using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补报车辆静态信息应答
    /// <para>子业务类型标识:UP_BASE_MSG_VEHICLE_ADDED_ACK</para>
    /// <para>描述:上级平台应答下级平台发送的补报车辆静态信息清求消息</para>
    /// </summary>
    public class JT809_0x1600_0x1601:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1600_0x1601>
    {
        public override ushort SubMsgId => JT809SubBusinessType.补报车辆静态信息应答.ToUInt16Value();

        public override string Description => "补报车辆静态信息应答";
        /// <summary>
        /// 车辆信息
        /// </summary>
        public string CarInfo { get; set; }
        public JT809_0x1600_0x1601 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1600_0x1601 jT809_0X9600_0X1601 = new JT809_0x1600_0x1601();
            jT809_0X9600_0X1601.CarInfo = reader.ReadRemainStringContent();
            return jT809_0X9600_0X1601;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1600_0x1601 value, IJT809Config config)
        {
            writer.WriteString(value.CarInfo);
        }
    }
}
