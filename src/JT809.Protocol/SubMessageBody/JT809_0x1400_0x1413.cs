using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报报警督办请求消息
    /// <para>子业务类型标识:UP_WARN_MSG_URGE_TODO_REQ_INFO</para>
    /// <para>描述:下级平台告知上级平台已对报警情况进行催办</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1413 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1413>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报报警处理结果消息.ToUInt16Value();

        public override string Description => "上报报警督办请求消息";
        /// <summary>
        /// 发起报警平台唯一编码，由平台所在地行政区划大码和平台编号组成
        /// </summary>
        public byte[] SourcePlatformId { get; set; }
        /// <summary>
        /// 报警时间 utc
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 对应报警督办请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDateType { get; set; }
        /// <summary>
        /// 对应报警督办请求消息源报文序列号
        /// </summary>
        public uint SourceMsgSn { get; set; }
        /// <summary>
        /// 督办截止时间 utc
        /// </summary>
        public DateTime SupervisionEndTime { get; set; }
        /// <summary>
        /// 督办级别
        /// </summary>
        public JT809_0x1413_SupervisionLevel SupervisionLevel { get; set; }
        /// <summary>
        /// 督办人
        /// </summary>
        public string Supervisor { get; set; }
        /// <summary>
        /// 督办人联系电话
        /// </summary>
        public string SupervisorTel { get; set; }
        /// <summary>
        /// 督办人联系电子邮件
        /// </summary>
        public string SupervisorEmail { get; set; }
        public JT809_0x1400_0x1413 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1413();
            value.SourcePlatformId = reader.ReadArray(11).ToArray();
            value.WarnTime = reader.ReadUTCDateTime();
            value.SourceDateType = reader.ReadUInt16();
            value.SourceMsgSn = reader.ReadUInt32();
            value.SupervisionEndTime = reader.ReadUTCDateTime();
            value.SupervisionLevel=(JT809_0x1413_SupervisionLevel)reader.ReadByte();
            value.Supervisor = reader.ReadString(16);
            value.SupervisorTel = reader.ReadString(20);
            value.SupervisorEmail = reader.ReadString(32);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1413 value, IJT809Config config)
        {
            writer.WriteArray(value.SourcePlatformId);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteUInt16(value.SourceDateType);
            writer.WriteUInt32(value.SourceMsgSn);
            writer.WriteUTCDateTime(value.SupervisionEndTime);
            writer.WriteByte((byte)value.SupervisionLevel);
            writer.WriteStringPadRight(value.Supervisor, 16);
            writer.WriteStringPadRight(value.SupervisorTel, 20);
            writer.WriteStringPadRight(value.SupervisorEmail, 32);
        }
    }
}
