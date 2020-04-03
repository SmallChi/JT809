using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 报警督办应答消息
    /// <para>子业务类型标识:UP_WARN_MSG_URGE_TODO_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的报警督办请求消息，向上.级平台上报车辆的报瞥处理结果</para>
    /// </summary>
    public class JT809_0x1400_0x1401:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1401>
    {
        /// <summary>
        /// 报警督办 ID
        /// </summary>
        public uint SupervisionID { get; set; }
        /// <summary>
        /// 报警处理结果
        /// </summary>
        public JT809_0x1401_Result Result { get; set; }
        public JT809_0x1400_0x1401 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400_0x1401 jT809_0X1400_0X1401 = new JT809_0x1400_0x1401();
            jT809_0X1400_0X1401.SupervisionID = reader.ReadUInt32();
            jT809_0X1400_0X1401.Result = (JT809_0x1401_Result)reader.ReadByte();
            return jT809_0X1400_0X1401;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1401 value, IJT809Config config)
        {
            writer.WriteUInt32(value.SupervisionID);
            writer.WriteByte((byte)value.Result);
        }
    }
}
