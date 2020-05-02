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
    /// 上报报警督办请求消息
    /// <para>子业务类型标识:UP_WARN_MSG_URGE_TODO_REQ_INFO</para>
    /// <para>描述:下级平台告知上级平台已对报警情况进行催办</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1413 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1413>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报报警督办请求消息.ToUInt16Value();

        public override string Description => "上报报警督办请求消息";
        /// <summary>
        /// 发起报警平台唯一编码，由平台所在地行政区划大码和平台编号组成
        /// </summary>
        public string SourcePlatformId { get; set; }
        /// <summary>
        /// 报警时间 utc
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 对应报警督办请求消息源子业务类型标识
        /// </summary>
        public ushort SourceDataType { get; set; }
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

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1413();
            var virtualHex = reader.ReadVirtualArray(11);
            value.SourcePlatformId = reader.ReadBigNumber(11);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]发起报警平台唯一编码", value.SourcePlatformId);
            virtualHex = reader.ReadVirtualArray(8);
            value.WarnTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]报警时间", value.WarnTime);
            value.SourceDataType = reader.ReadUInt16();
            writer.WriteString($"[{value.SourceDataType.ReadNumber()}]对应启动车辆定位信息交换请求消息源子业务类型标识", ((JT809SubBusinessType)value.SourceDataType).ToString());
            value.SourceMsgSn = reader.ReadUInt32();
            writer.WriteNumber($"[{value.SourceMsgSn.ReadNumber()}对应启动车辆定位信息交换请求消息源报文序列号]", value.SourceMsgSn);
            virtualHex = reader.ReadVirtualArray(8);
            value.SupervisionEndTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办截止时间", value.SupervisionEndTime);
            value.SupervisionLevel = (JT809_0x1413_SupervisionLevel)reader.ReadByte();
            writer.WriteString($"[{value.SupervisionLevel.ToByteValue()}]督办级别", value.SupervisionLevel.ToString());
            virtualHex = reader.ReadVirtualArray(16);
            value.Supervisor = reader.ReadString(16);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办人", value.Supervisor);
            virtualHex = reader.ReadVirtualArray(20);
            value.SupervisorTel = reader.ReadString(20);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办人联系电话", value.SupervisorTel);
            virtualHex = reader.ReadVirtualArray(32);
            value.SupervisorEmail = reader.ReadString(32);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]督办人联系电子邮件", value.SupervisorTel);
        }

        public JT809_0x1400_0x1413 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1413();
            value.SourcePlatformId = reader.ReadBigNumber(11);
            value.WarnTime = reader.ReadUTCDateTime();
            value.SourceDataType = reader.ReadUInt16();
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
            writer.WriteBigNumber(value.SourcePlatformId,11);
            writer.WriteUTCDateTime(value.WarnTime);
            writer.WriteUInt16(value.SourceDataType);
            writer.WriteUInt32(value.SourceMsgSn);
            writer.WriteUTCDateTime(value.SupervisionEndTime);
            writer.WriteByte((byte)value.SupervisionLevel);
            writer.WriteStringPadRight(value.Supervisor, 16);
            writer.WriteStringPadRight(value.SupervisorTel, 20);
            writer.WriteStringPadRight(value.SupervisorEmail, 32);
        }
    }
}
