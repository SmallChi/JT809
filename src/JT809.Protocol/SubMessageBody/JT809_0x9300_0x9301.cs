using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 平台查岗请求
    /// <para>子业务类型标识:DOWN_PLATFORM-MSG_POST_QUERY_REQ</para>
    /// <para>描述:上级平台不定期向下级平台发送平台查岗信息</para>
    /// </summary>
    public class JT809_0x9300_0x9301:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9300_0x9301>
    {
        public override ushort SubMsgId => JT809SubBusinessType.平台查岗请求.ToUInt16Value();

        public override string Description => "平台查岗请求";
        /// <summary>
        /// 查岗对象的类型
        /// </summary>
        public JT809_0x9301_ObjectType ObjectType { get; set; }
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
        public JT809_0x9300_0x9301 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9300_0x9301 jT809_0X9300_0X9301 = new JT809_0x9300_0x9301();
            jT809_0X9300_0X9301.ObjectType = (JT809_0x9301_ObjectType)reader.ReadByte();
            jT809_0X9300_0X9301.ObjectID = reader.ReadString(12);
            jT809_0X9300_0X9301.InfoID = reader.ReadUInt32();
            jT809_0X9300_0X9301.InfoLength = reader.ReadUInt32();
            jT809_0X9300_0X9301.InfoContent = reader.ReadString((int)jT809_0X9300_0X9301.InfoLength);
            return jT809_0X9300_0X9301;
        }


        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9300_0x9301 value, IJT809Config config)
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
