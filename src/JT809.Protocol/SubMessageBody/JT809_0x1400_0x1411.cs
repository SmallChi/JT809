using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报报警督办应答消息
    /// <para>子业务类型标识:UP_WARN_MSG_URGE_TODO_ACK_INFO</para>
    /// <para>描述:下级平台向上级平台上报某车辆的报警信息</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1411 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1411>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报报警督办应答消息.ToUInt16Value();

        public override string Description => "上报报警督办应答消息";
        /// <summary>
        /// 对应报警督办请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
        /// <summary>
        /// 对应报警督办请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 报警处理结果
        /// </summary>
        public JT809_0x1411_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1411();
            value.SourceDataType = reader.ReadUInt16();
            writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
            value.SourceMsgSn = reader.ReadUInt32();
            writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
            value.Result = (JT809_0x1411_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]报警处理结果", value.Result.ToString());
        }

        public JT809_0x1400_0x1411 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1411();
            value.SourceDataType = reader.ReadUInt16();
            value.SourceMsgSn = reader.ReadUInt32();
            value.Result = (JT809_0x1411_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1411 value, IJT809Config config)
        {
            writer.WriteUInt16(value.SourceDataType);
            writer.WriteUInt32(value.SourceMsgSn);
            writer.WriteByte((byte)value.Result);
        }
    }
}
