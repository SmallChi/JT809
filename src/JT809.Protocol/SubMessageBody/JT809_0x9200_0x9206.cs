using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 结束车辆定位信息交换请求
    /// <para>子业务类型标识:DOWN_EXG_MSG_RETURN_END</para>
    /// <para>描述:在进入非归属地区地理区域的车辆离开该地理区域、人上取消指定车辆定位信息交换和应急状态结束时，上级平台向下级平台发出结束车辆定位信息交换请求消息。下级平台收到该命令后应回复结束车辆定位信息交换应答消息，即 UP_EXG_MSG_RE_TURN_END_ACK</para>
    /// </summary>
    public class JT809_0x9200_0x9206:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9206>
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public JT809_0x9206_ReasonCode ReasonCode { get; set; }

        public JT809_0x9200_0x9206 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9206 jT809_0X1200_0x9206 = new JT809_0x9200_0x9206();
            jT809_0X1200_0x9206.ReasonCode = (JT809_0x9206_ReasonCode)reader.ReadByte();
            return jT809_0X1200_0x9206;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9206 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
