using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆单向监听请求消息
    /// <para>子业务类型标识:DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ</para>
    /// <para>描述:上级平台向下级平台下发车辆单向监听清求消息</para>
    /// </summary>
    public class JT809_0x9500_0x9501:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9501>
    {
        /// <summary>
        /// 回拨电话号码
        /// </summary>
        public string MonitorTel { get; set; }
        public JT809_0x9500_0x9501 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9501 jT809_0X9500_0X9501 = new JT809_0x9500_0x9501();
            jT809_0X9500_0X9501.MonitorTel = reader.ReadString(20);
            return jT809_0X9500_0X9501;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9501 value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.MonitorTel, 20);
        }
    }
}
