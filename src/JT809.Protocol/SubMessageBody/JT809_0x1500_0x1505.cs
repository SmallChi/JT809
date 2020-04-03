using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆应急接入监管平台应答消息
    /// <para>子业务类型标识: UP_CTRL_MSG_EMERGENCY_MONITORING_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的车辆应急接入监管平台请求消息应答</para>
    /// </summary>
    public class JT809_0x1500_0x1505:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1505>
    {
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1505_Result Result { get; set; }
        public JT809_0x1500_0x1505 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1505 jT809_0X1500_0X1505 = new JT809_0x1500_0x1505();
            jT809_0X1500_0X1505.Result = (JT809_0x1505_Result)reader.ReadByte();
            return jT809_0X1500_0X1505;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1505 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
