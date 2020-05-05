using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 下发平台间报文请求
    /// <para>子业务类型标识:DOWN_PLATFORM_MSG_INFO_REQ</para>
    /// <para>描述:上级平台不定期向下级平台下发平台间报文</para>
    /// </summary>
    public class JT809_0x9300_0x9302:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9300_0x9302>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.下发平台间报文请求.ToUInt16Value();

        public override string Description => "下发平台间报文请求";
        /// <summary>
        /// 查岗对象的类型
        /// </summary>
        public JT809_0x9302_ObjectType ObjectType { get; set; }
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

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9300_0x9302 value = new JT809_0x9300_0x9302();
            value.ObjectType = (JT809_0x9302_ObjectType)reader.ReadByte();
            writer.WriteString($"[{value.ObjectType.ToByteValue()}]查岗对象的类型", value.ObjectType.ToString());
            var virtualHex = reader.ReadVirtualArray(12);
            value.ObjectID = reader.ReadString(12);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]查岗对象的ID", value.ObjectID);
            value.InfoID = reader.ReadUInt32();
            writer.WriteNumber($"[{value.InfoID.ReadNumber() }]信息ID", value.InfoID);
            value.InfoLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.InfoLength.ReadNumber() }]数据长度", value.InfoLength);
            virtualHex = reader.ReadVirtualArray((int)value.InfoLength);
            value.InfoContent = reader.ReadString((int)value.InfoLength);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]应答内容", value.InfoContent);
        }

        public JT809_0x9300_0x9302 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9300_0x9302 value = new JT809_0x9300_0x9302();
            value.ObjectType = (JT809_0x9302_ObjectType)reader.ReadByte();
            value.ObjectID = reader.ReadString(12);
            value.InfoID = reader.ReadUInt32();
            value.InfoLength = reader.ReadUInt32();
            value.InfoContent = reader.ReadString((int)value.InfoLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9300_0x9302 value, IJT809Config config)
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
