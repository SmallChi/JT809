using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 平台查岗应答消息
    /// <para>子业务类型标识:UP_PLATFORM_MSG_POST_QUERY_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的不定期平台查岗消息</para>
    /// </summary>
    public class JT809_0x1300_0x1301:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1300_0x1301>
    {
        /// <summary>
        /// 查岗对象的类型
        /// </summary>
        public JT809_0x1301_ObjectType ObjectType { get; set; }
        /// <summary>
        /// 查岗对象的ID
        /// </summary>
        public string ObjectID { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint InfoLength { get; set; }
        /// <summary>
        /// 应答内容
        /// </summary>
        public string InfoContent { get; set; }
        public JT809_0x1300_0x1301 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1300_0x1301 jT809_0X1200_0X1301 = new JT809_0x1300_0x1301();
            jT809_0X1200_0X1301.ObjectType = (JT809_0x1301_ObjectType)reader.ReadByte();
            jT809_0X1200_0X1301.ObjectID = reader.ReadString(12);
            jT809_0X1200_0X1301.InfoID = reader.ReadUInt32();
            jT809_0X1200_0X1301.InfoLength = reader.ReadUInt32();
            jT809_0X1200_0X1301.InfoContent = reader.ReadString((int)jT809_0X1200_0X1301.InfoLength);
            return jT809_0X1200_0X1301;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1300_0x1301 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ObjectType);
            writer.WriteStringPadRight(value.ObjectID, 12);
            writer.WriteUInt32(value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.InfoContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
