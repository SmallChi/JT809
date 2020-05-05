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
    /// 报警督办请求消息
    /// <para>子业务类型标识:DOWN_WARN_MSG_URGE_TODO_REQ</para>
    /// <para>描述:上级平台向车辆归属下级平台下发本消息，催促其及时处理相关车辆的报警信息</para>
    /// </summary>
    public class JT809_0x9400_0x9401:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9400_0x9401>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.报警督办请求消息.ToUInt16Value();

        public override string Description => "报警督办请求消息";
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public ushort WarnType { get; set; }
        /// <summary>
        /// 报警时间UTCDateTime
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 报警督办ID HexString
        /// </summary>
        public string SupervisionID { get; set; }
        /// <summary>
        /// 督办截止时间
        /// </summary>
        public DateTime SupervisionEndTime { get; set; }
        /// <summary>
        /// 督办级别
        /// </summary>
        public JT809_9401_SupervisionLevel SupervisionLevel { get; set; }
        /// <summary>
        /// 督办人
        /// </summary>
        public string Supervisor { get; set; }
        /// <summary>
        /// 督办联系电话
        /// </summary>
        public string SupervisorTel { get; set; }
        /// <summary>
        /// 督办联系电子邮件
        /// </summary>
        public string SupervisorEmail { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9400_0x9401 value = new JT809_0x9400_0x9401();
            value.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            writer.WriteString($"[{value.WarnSrc.ToByteValue()}]报警信息来源", value.WarnSrc.ToString());
            value.WarnType = reader.ReadUInt16();
            writer.WriteNumber($"[{value.WarnType.ReadNumber()}]报警类型", value.WarnType);
            var virtualHex = reader.ReadVirtualArray(8);
            value.WarnTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]报警时间", value.WarnTime);
            virtualHex = reader.ReadVirtualArray(4);
            value.SupervisionID = reader.ReadHex(4);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]报警督办ID", value.SupervisionID);
            virtualHex = reader.ReadVirtualArray(8);
            value.SupervisionEndTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办截止时间", value.SupervisionEndTime);
            value.SupervisionLevel = (JT809_9401_SupervisionLevel)reader.ReadByte();
            writer.WriteString($"[{value.SupervisionLevel.ToByteValue()}]督办级别", value.SupervisionLevel.ToString());
            virtualHex = reader.ReadVirtualArray(16);
            value.Supervisor = reader.ReadString(16);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办人", value.Supervisor);
            virtualHex = reader.ReadVirtualArray(20);
            value.SupervisorTel = reader.ReadString(20);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办联系电话", value.SupervisorTel);
            virtualHex = reader.ReadVirtualArray(32);
            value.SupervisorEmail = reader.ReadString(32);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办联系电子邮件", value.SupervisorEmail);
        }

        public JT809_0x9400_0x9401 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9400_0x9401 value = new JT809_0x9400_0x9401();
            value.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            value.WarnType = reader.ReadUInt16();
            value.WarnTime = reader.ReadUTCDateTime();
            value.SupervisionID = reader.ReadHex(4);
            value.SupervisionEndTime = reader.ReadUTCDateTime();
            value.SupervisionLevel = (JT809_9401_SupervisionLevel)reader.ReadByte();
            value.Supervisor = reader.ReadString(16);
            value.SupervisorTel = reader.ReadString(20);
            value.SupervisorEmail = reader.ReadString(32);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9400_0x9401 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.WarnSrc);
            writer.WriteUInt16(value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteHex(value.SupervisionID, 4);
            writer.WriteUTCDateTime(value.SupervisionEndTime);
            writer.WriteByte(value.SupervisionLevel.ToByteValue());
            writer.WriteStringPadRight(value.Supervisor, 16);
            writer.WriteStringPadRight(value.SupervisorTel, 20);
            writer.WriteStringPadRight(value.SupervisorEmail, 32);
        }
    }
}
