using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;
using System;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 平台查岗请求
    /// <para>子业务类型标识:DOWN_PLATFORM-MSG_POST_QUERY_REQ</para>
    /// <para>描述:上级平台不定期向下级平台发送平台查岗信息</para>
    /// </summary>
    public class JT809_0x9300_0x9301 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9300_0x9301>, IJT809Analyze, IJT809_2019_Version
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
        /// 查岗应答时限
        /// </summary>
        public byte AnswerTime { get; set; }
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
            JT809_0x9300_0x9301 value = new JT809_0x9300_0x9301();
            ReadOnlySpan<byte> virtualHex;
            if (config.Version == JT809Version.JTT2019)
            {
                value.ObjectType = (JT809_0x9301_ObjectType)reader.ReadByte();
                writer.WriteString($"[{value.ObjectType.ToByteValue()}]查岗对象的类型", value.ObjectType.ToString());
                virtualHex = reader.ReadVirtualArray(20);
                value.ObjectID = reader.ReadString(20);
                writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]查岗对象的ID", value.ObjectID);
                writer.WriteNumber($"[{value.AnswerTime.ReadNumber()}]查岗应答时限", value.AnswerTime);
            }
            value.InfoID = reader.ReadUInt32();
            writer.WriteNumber($"[{value.InfoID.ReadNumber() }]信息ID", value.InfoID);
            value.InfoLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.InfoLength.ReadNumber() }]数据长度", value.InfoLength);
            virtualHex = reader.ReadVirtualArray((int)value.InfoLength);
            value.InfoContent = reader.ReadString((int)value.InfoLength);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]应答内容", value.InfoContent);
        }

        public JT809_0x9300_0x9301 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9300_0x9301 value = new JT809_0x9300_0x9301();
            if (config.Version == JT809Version.JTT2019)
            {
                value.ObjectType = (JT809_0x9301_ObjectType)reader.ReadByte();
                value.ObjectID = reader.ReadString(20);
                value.AnswerTime = reader.ReadByte();
            }
            value.InfoID = reader.ReadUInt32();
            value.InfoLength = reader.ReadUInt32();
            value.InfoContent = reader.ReadString((int)value.InfoLength);
            return value;
        }


        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9300_0x9301 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteByte((byte)value.ObjectType);
                writer.WriteStringPadRight(value.ObjectID, 20);
                writer.WriteByte(value.AnswerTime);
            }
            writer.WriteUInt32(value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.InfoContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
