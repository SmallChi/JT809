using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    ///  平台链路连接情况与车辆定位消息传输情况上报应答消息
    /// <para>链路类型：主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务类型标识:UP_MANAGE_MSG_RSP</para>
    /// <para>下级平台收到上级平台下发的“平台链路连接情况与车辆定位消息传输情况上报请求消息”后，上报指定平台，指定时间段内的平台链路连接情况与车辆定位消息传输情况</para>
    /// </summary>
    public class JT809_0x1102 : JT809ExchangeMessageBodies, IJT809MessagePackFormatter<JT809_0x1102>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort MsgId => JT809BusinessType.平台链路连接情况与车辆定位消息传输情况上报应答消息_2019.ToUInt16Value();
        public override string Description => "平台链路连接情况与车辆定位消息传输情况上报应答消息";
        public override JT809_LinkType LinkType => JT809_LinkType.main;

        public override JT809Version Version => JT809Version.JTT2019;

        /// <summary>
        /// 平台唯一编码
        /// </summary>
        public string PlateformId { get; set; }
        /// <summary>
        /// 开始时间，用 UTC 时间表示
        /// 注：采用 UTC 时间表示，如 2010-1-10 9:7:54 的 UTC 值为 1263085674，其在协议中表示为0x000000004B49286A.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间，用 UTC 时间表示
        /// 注：采用 UTC 时间表示，如 2010-1-10 9:7:54 的 UTC 值为 1263085674，其在协议中表示为0x000000004B49286A.
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// START_TIME~END_TIME期间下级平台丢失得车辆定位消息总数
        /// </summary>
        public uint LoseDymamicSum { get; set; }
        /// <summary>
        /// START_TIME~END_TIME期间下级监控平台链路断开次数
        /// </summary>
        public byte DisconnectNum { get; set; }
        /// <summary>
        /// START_TIME~END_TIME期间下级监控平台链路断开总时长，用秒表示
        /// </summary>
        public uint DisconnectTime { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1102 value = new JT809_0x1102();
            value.SubBusinessType = reader.ReadUInt16();
            writer.WriteNumber($"[{value.SubBusinessType.ReadNumber()}]子业务类型标识", value.SubBusinessType);
            value.DataLength = reader.ReadUInt32();
            writer.WriteNumber($"[{value.DataLength.ReadNumber()}]后续数据长度", value.DataLength);
            var virtualHex = reader.ReadVirtualArray(11);
            value.PlateformId = reader.ReadString(11);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]平台唯一编码", value.PlateformId);
            virtualHex = reader.ReadVirtualArray(8);
            value.StartTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]开始时间", value.StartTime);
            virtualHex = reader.ReadVirtualArray(8);
            value.EndTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]结束时间", value.EndTime);
            value.LoseDymamicSum = reader.ReadUInt32();
            writer.WriteNumber($"[{value.LoseDymamicSum.ReadNumber()}]START_TIME~END_TIME期间下级平台丢失得车辆定位消息总数", value.LoseDymamicSum);
            value.DisconnectNum = reader.ReadByte();
            writer.WriteNumber($"[{value.DisconnectNum.ReadNumber()}]START_TIME~END_TIME期间下级监控平台链路断开次数", value.DisconnectNum);
            value.DisconnectTime = reader.ReadUInt32();
            writer.WriteNumber($"[{value.DisconnectTime.ReadNumber()}]START_TIME~END_TIME期间下级监控平台链路断开总时长，用秒表示", value.DisconnectTime);
        }

        public JT809_0x1102 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1102 value = new JT809_0x1102();
            value.SubBusinessType = reader.ReadUInt16();
            value.DataLength = reader.ReadUInt32();
            value.PlateformId = reader.ReadString(11);
            value.StartTime = reader.ReadUTCDateTime();
            value.EndTime = reader.ReadUTCDateTime();
            value.LoseDymamicSum = reader.ReadUInt32();
            value.DisconnectNum = reader.ReadByte();
            value.DisconnectTime = reader.ReadUInt32();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1102 value, IJT809Config config)
        {
            writer.WriteUInt16(value.SubBusinessType);
            writer.Skip(4, out int subContentLengthPosition);
            writer.WriteStringPadRight(value.PlateformId, 11);
            writer.WriteUTCDateTime(value.StartTime);
            writer.WriteUTCDateTime(value.EndTime);
            writer.WriteUInt32(value.LoseDymamicSum);
            writer.WriteByte(value.DisconnectNum);
            writer.WriteUInt32(value.DisconnectTime);
            writer.WriteInt32Return(writer.GetCurrentPosition() - subContentLengthPosition - 4, subContentLengthPosition);
        }
    }
}
