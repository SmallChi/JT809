using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报报警处理结果信息
    /// <para>子业务类型标识:UP_WARN_MSG_ADPT_TODO_INFO</para>
    /// <para>描述:下级平台向上级平台上报报警处理结果</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1403:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1403>
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报报警处理结果信息.ToUInt16Value();

        public override string Description => "主动上报报警处理结果信息";
        /// <summary>
        /// 报警信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public JT809_0x1403_Result Result { get; set; }
        public JT809_0x1400_0x1403 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400_0x1403 jT809_0X1400_0X1403 = new JT809_0x1400_0x1403();
            jT809_0X1400_0X1403.InfoID = reader.ReadUInt32();
            jT809_0X1400_0X1403.Result = (JT809_0x1403_Result)reader.ReadByte();
            return jT809_0X1400_0X1403;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1403 value, IJT809Config config)
        {
            writer.WriteUInt32(value.InfoID);
            writer.WriteByte((byte)value.Result);
        }
    }
}
