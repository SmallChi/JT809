using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using System;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报报警信息消息
    /// <para>子业务类型标识:UP_WARN_MSG_ADPT_INFO</para>
    /// <para>描述:下级平台向上级平台上报某车辆的报警信息</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1402:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1402>
    {
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public JT809WarnType WarnType { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint InfoLength { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public string InfoContent { get; set; }
        public JT809_0x1400_0x1402 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1400_0x1402 jT809_0X1400_0X1402 = new JT809_0x1400_0x1402();
            jT809_0X1400_0X1402.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            jT809_0X1400_0X1402.WarnType = (JT809WarnType)reader.ReadUInt16();
            jT809_0X1400_0X1402.WarnTime = reader.ReadUTCDateTime();
            jT809_0X1400_0X1402.InfoID = reader.ReadUInt32();
            jT809_0X1400_0X1402.InfoLength = reader.ReadUInt32();
            jT809_0X1400_0X1402.InfoContent = reader.ReadString((int)jT809_0X1400_0X1402.InfoLength);
            return jT809_0X1400_0X1402;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1402 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.WarnSrc);
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteUInt32(value.InfoID);
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.InfoContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
