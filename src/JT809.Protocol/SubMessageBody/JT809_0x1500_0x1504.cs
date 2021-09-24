using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆行驶记录应答消息
    /// <para>子业务类型标识:UP_CTRL_MSG_TAKE_TRAVEL_ACK</para>
    /// <para>描述:下级平台应答上级平台下发的"上报车辆行驶记录请求"消息，将车辆行驶记录数据上传至上级平台</para>
    /// </summary>
    public class JT809_0x1500_0x1504 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1504>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆行驶记录应答消息.ToUInt16Value();

        public override string Description => "上报车辆行驶记录应答消息";
        /// <summary>
        /// 对应上报车辆行驶记录请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应上报车辆行驶记录请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 命令字
        /// </summary>
        public JT809CommandType CommandType { get; set; }
        /// <summary>
        /// 车辆行驶记录数据体长度
        /// </summary>
        public uint TraveldataLength { get; set; }
        /// <summary>
        /// 车辆行驶记录信息
        /// <para>19056应答帧元数据</para>
        /// </summary>
        public byte[] TraveldataInfo { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1500_0x1504 value = new JT809_0x1500_0x1504();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSn = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
                value.CommandType = (JT809CommandType)reader.ReadByte();
                writer.WriteString($"[{value.CommandType.ToByteValue()}]命令字", value.CommandType.ToString());
            }
            value.TraveldataLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.TraveldataLength.ReadNumber()}]车辆行驶记录数据体长度", value.TraveldataLength);
            var virtualHex = reader.ReadVirtualArray((int)value.TraveldataLength);
            value.TraveldataInfo = reader.ReadArray((int)value.TraveldataLength).ToArray();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]车辆行驶记录信息", value.TraveldataInfo.ToHexString());
        }

        public JT809_0x1500_0x1504 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1504 value = new JT809_0x1500_0x1504();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
                value.CommandType = (JT809CommandType)reader.ReadByte();
            }
            value.TraveldataLength = reader.ReadUInt32();
            value.TraveldataInfo = reader.ReadArray((int)value.TraveldataLength).ToArray();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1504 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
                writer.WriteByte((byte)value.CommandType);
            }
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteArray(value.TraveldataInfo);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
