using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    ///  交换车辆静态信息消息
    ///  <para>子业务类型标识:DOWN_EXG_MSG_CAR_INFO</para>
    ///  <para>描述:在首次启动跨域车辆定位信息交换，或者以后交换过程中车辆静态信息有更新时，由上级平台向下级平台下发一次车辆静态信息。下.级平台接收后自行更新该车辆静态信息</para>
    /// </summary>
    public class JT809_0x9200_0x9204:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9204>
    {
        public override ushort SubMsgId => JT809SubBusinessType.交换车辆静态信息消息.ToUInt16Value();

        public override string Description => "交换车辆静态信息消息";
        /// <summary>
        /// 车辆信息
        /// </summary>
        public string CarInfo { get; set; }

        public JT809_0x9200_0x9204 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9204 jT809_0X1200_0x9204 = new JT809_0x9200_0x9204();
            jT809_0X1200_0x9204.CarInfo = reader.ReadRemainStringContent();
            return jT809_0X1200_0x9204;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9204 value, IJT809Config config)
        {
            writer.WriteString(value.CarInfo);
        }
    }
}
