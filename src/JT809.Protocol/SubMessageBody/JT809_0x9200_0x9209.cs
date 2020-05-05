using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补发车辆定位信息应答
    /// <para>子业务类型标识:DOWN_EXG_MSG_APPLY_HISGNSSDATA_ACK</para>
    /// <para>本条消息是上级平台应答下级平台发送的“补发车辆定位信息请求”消息，即 UP_EXG_MSG_APPLY_HISGNSSDATA_REQ</para>
    /// </summary>
    public class JT809_0x9200_0x9209: JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9209>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.补发车辆定位信息应答.ToUInt16Value();

        public override string Description => "补发车辆定位信息应答";
        /// <summary>
        /// 对应补发车辆定位信息请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应补发车辆定位信息请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public JT809_0x9209_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x9200_0x9209();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSn = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
            }
            value.Result = (JT809_0x9209_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]返回结果", value.Result.ToString());
        }

        public JT809_0x9200_0x9209 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9200_0x9209();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            value.Result = (JT809_0x9209_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9209 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSn);
            }
            writer.WriteByte((byte)value.Result);
        }
    }
}
