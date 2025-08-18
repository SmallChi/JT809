using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆单向监听应答
    /// <para>子业务类型标识:UP_CTRL_MSG_MONITOR_VEHTCLE_ACK</para>
    /// <para>描述:下级平台向上级平台上传车辆单向监听请求消息的应答</para>
    /// </summary>
    public class JT809_0x1500_0x1501:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1501>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆单向监听应答.ToUInt16Value();

        public override string Description => "车辆单向监听应答";
        /// <summary>
        /// 对应车辆单向监听请求消息源子业务类型标识
        /// 809 2019
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        /// 对应车辆单向监听请求消息源报文序列号
        /// 809 2019
        /// </summary>
        public uint SourceMsgSN { get; set; }
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1501_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1500_0x1501 value = new JT809_0x1500_0x1501();
            if(config.Version== JT809Version.JTT2011)
            {
                value.Result = (JT809_0x1501_Result)reader.ReadByte();
                writer.WriteString($"[{value.Result.ToByteValue()}]应答结果", value.Result.ToString());
            }
            else if(config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteNumber($"[{value.SourceDataType.ReadNumber()}]对应车辆单向监听请求消息源子业务类型标识", value.SourceDataType);
                value.SourceMsgSN = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSN.ReadNumber()}]对应车辆单向监听请求消息源报文序列号", value.SourceMsgSN);
                value.Result = (JT809_0x1501_Result)reader.ReadByte();
                writer.WriteString($"[{value.Result.ToByteValue()}]应答结果", value.Result.ToString());
            }
        }

        public JT809_0x1500_0x1501 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1501 value = new JT809_0x1500_0x1501();
            if (config.Version == JT809Version.JTT2011)
            {
                value.Result = (JT809_0x1501_Result)reader.ReadByte();
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSN = reader.ReadUInt32();
                value.Result = (JT809_0x1501_Result)reader.ReadByte();
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1501 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
                writer.WriteByte((byte)value.Result);
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUInt16(value.SourceDataType);
                writer.WriteUInt32(value.SourceMsgSN);
                writer.WriteByte((byte)value.Result);
            }
        }
    }
}
