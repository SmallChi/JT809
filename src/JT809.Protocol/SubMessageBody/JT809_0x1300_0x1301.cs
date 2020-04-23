using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 平台查岗应答消息
    /// <para>子业务类型标识:UP_PLATFORM_MSG_POST_QUERY_ACK</para>
    /// <para>描述:下级平台应答上级平台发送的不定期平台查岗消息</para>
    /// </summary>
    public class JT809_0x1300_0x1301:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1300_0x1301>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.平台查岗应答消息.ToUInt16Value();

        public override string Description => "平台查岗应答消息";
        /// <summary>
        /// 查岗对象的类型
        /// </summary>
        public JT809_0x1301_ObjectType ObjectType { get; set; }
        /// <summary>
        /// 查岗应答人姓名
        /// </summary>
        public string Responder { get; set; }
        /// <summary>
        /// 查岗应答人联系电话
        /// </summary>
        public string ResponderTel { get; set; }
        /// <summary>
        /// 查岗对象的ID
        /// 2013:12位
        /// 2019:20位
        /// </summary>
        public string ObjectID { get; set; }
        /// <summary>
        /// 对应平台查岗请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        /// 对应平台查岗请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
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
            var value = new JT809_0x1300_0x1301();
            value.ObjectType = (JT809_0x1301_ObjectType)reader.ReadByte();
            if (config.Version == JT809Version.JTT2013)
            {
                value.ObjectID = reader.ReadString(12);
                value.InfoID = reader.ReadUInt32();
            }
            else {
                value.Responder = reader.ReadString(16);
                value.ResponderTel = reader.ReadString(20);
                value.ObjectID = reader.ReadString(20);
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            value.InfoLength = reader.ReadUInt32();
            value.InfoContent = reader.ReadString((int)value.InfoLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1300_0x1301 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ObjectType);
            if (config.Version == JT809Version.JTT2013)
            {
                writer.WriteStringPadRight(value.ObjectID, 12);
                writer.WriteUInt32(value.InfoID);
            }
            else {
                writer.WriteStringPadRight(value.Responder, 16);
                writer.WriteStringPadRight(value.ResponderTel, 20);
                writer.WriteStringPadRight(value.ObjectID, 20);
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.InfoContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
