using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 取消交换指定车辆定位信息应答
    /// <para>子业务类型标识:DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK</para>
    /// </summary>
    public class JT809_0x9200_0x9209: JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9209>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public JT809_0x9209_Result Result { get; set; }

        public JT809_0x9200_0x9209 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9209 jT809_0X1200_0x9209 = new JT809_0x9200_0x9209();
            jT809_0X1200_0x9209.Result = (JT809_0x9209_Result)reader.ReadByte();
            return jT809_0X1200_0x9209;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9209 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
