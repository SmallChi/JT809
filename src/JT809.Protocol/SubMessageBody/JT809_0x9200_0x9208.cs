using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 取消交换指定车辆定位信息应答or取消申请交换指定车辆定位信息应答消息
    /// <para>子业务类型标识:DOWN_EXG_MSG_APPLY_FOR_MONITOR_END_ACK</para>
    /// <para>应答下级平台“取消申请交换指定车辆定位信息”</para>
    /// </summary>
    public class JT809_0x9200_0x9208:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9208>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.取消交换指定车辆定位信息应答or取消申请交换指定车辆定位信息应答消息.ToUInt16Value();

        public override string Description => "取消交换指定车辆定位信息应答or取消申请交换指定车辆定位信息应答消息";
        /// <summary>
        /// 对应取消申请交换指定车辆定位信息请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        ///  对应取消申请交换指定车辆定位信息请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public JT809_0x9208_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x9200_0x9208();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
                value.SourceMsgSn = reader.ReadUInt32();
                writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
            }
            value.Result = (JT809_0x9208_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]返回结果", value.Result.ToString());
        }

        public JT809_0x9200_0x9208 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9200_0x9208();
            if (config.Version == JT809Version.JTT2019)
            {
                value.SourceDataType = reader.ReadUInt16();
                value.SourceMsgSn = reader.ReadUInt32();
            }
            value.Result = (JT809_0x9208_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9208 value, IJT809Config config)
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
