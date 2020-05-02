using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.MessageBody
{
    /// <summary>
    ///  发送车辆定位信息数据量通知消息
    /// <para>链路类型：主链路</para>
    /// <para>消息方向:下级平台往上级平台</para>
    /// <para>业务类型标识: DOWN_TOTAL_RECV_BACK_MSG</para>
    /// <para>描述:下级平台向上级平台定量通知已经上传的车辆定位信息数量(如:每收到10,000 条车辆定位信息通知一次)</para>
    /// <para>本条消息不需下级平台应答。</para>
    /// </summary>
    public class JT809_2019_0x9101 : JT809Bodies, IJT809MessagePackFormatter<JT809_2019_0x9101>, IJT809Analyze
    {
        public override ushort MsgId => JT809BusinessType.发送车辆定位信息数据量通知消息_2019.ToUInt16Value();
        public override string Description => "发送车辆定位信息数据量通知消息_2019";
        public override JT809_LinkType LinkType => JT809_LinkType.main;
        public override JT809Version Version => JT809Version.JTT2019;

        /// <summary>
        /// START_TIME_END_TIME共收到的车辆定位信息数量
        /// </summary>
        public uint DynamicInfoTotal { get; set; }
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

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_2019_0x9101 value = new JT809_2019_0x9101();
            value.DynamicInfoTotal = reader.ReadUInt32();
            writer.WriteNumber($"[{value.DynamicInfoTotal.ReadNumber()}START_TIME_END_TIME共收到的车辆定位信息数量]", value.DynamicInfoTotal);
            var virtualHex = reader.ReadVirtualArray(8);
            value.StartTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}开始时间]", value.StartTime);
            virtualHex = reader.ReadVirtualArray(8);
            value.EndTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}结束时间]", value.EndTime);
        }

        public JT809_2019_0x9101 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_2019_0x9101 value = new JT809_2019_0x9101();
            value.DynamicInfoTotal = reader.ReadUInt32();
            value.StartTime = reader.ReadUTCDateTime();
            value.EndTime = reader.ReadUTCDateTime();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_2019_0x9101 value, IJT809Config config)
        {
            writer.WriteUInt32(value.DynamicInfoTotal);
            writer.WriteUTCDateTime(value.StartTime);
            writer.WriteUTCDateTime(value.EndTime);
        }
    }
}
