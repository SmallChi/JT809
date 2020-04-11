using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报报警处理结果消息
    /// <para>子业务类型标识:UP_WARN_MSG_ADPT_TODO_INFO</para>
    /// <para>描述:下级平台主动向上级平台上报报警处理结果</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1412 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1412>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报报警处理结果消息.ToUInt16Value();

        public override string Description => "主动上报报警处理结果消息";
        /// <summary>
        /// 对应报警督办请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDateType { get; set; }
        /// <summary>
        /// 对应报警督办请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 报警处理结果
        /// </summary>
        public JT809_0x1412_Result Result { get; set; }
        public JT809_0x1400_0x1412 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1412();
            value.SourceDateType = reader.ReadUInt16();
            value.SourceMsgSn = reader.ReadUInt32();
            value.Result = (JT809_0x1412_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1412 value, IJT809Config config)
        {
            writer.WriteUInt16(value.SourceDateType);
            writer.WriteUInt32(value.SourceMsgSn);
            writer.WriteByte((byte)value.Result);
        }
    }
}
