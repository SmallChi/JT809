using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessagePack;
using System;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补发车辆定位信息请求
    /// <para>子业务类型标识:UP_EXG_MSG_APPLY_HISGNSSDATA_REQ</para>
    /// <para>描述:在平台间传输链路中断并重新建立连接后，下级平台向上级平台请求中断期间内上级平台需交换至下级平台的车辆定位信息时，向上级平台发出补发车辆定位信息请求，上级平台对请求应答后进行“补发车辆定位信息”</para>
    /// </summary>
    public class JT809_0x1200_0x1209:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1209>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.补发车辆定位信息请求.ToUInt16Value();

        public override string Description => "补发车辆定位信息请求";
        /// <summary>
        /// 开始时间，用 UTC 时间表示
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间，用 UTC 时间表示
        /// </summary>
        public DateTime EndTime { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1200_0x1209 value = new JT809_0x1200_0x1209();
            var virtualHex = reader.ReadVirtualArray(8);
            value.StartTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]开始时间", value.StartTime);
            virtualHex = reader.ReadVirtualArray(8);
            value.EndTime = reader.ReadUTCDateTime();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]结束时间", value.StartTime);
        }

        public JT809_0x1200_0x1209 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1209 value = new JT809_0x1200_0x1209();
            value.StartTime = reader.ReadUTCDateTime();
            value.EndTime = reader.ReadUTCDateTime();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1209 value, IJT809Config config)
        {
            writer.WriteUTCDateTime(value.StartTime);
            writer.WriteUTCDateTime(value.EndTime);
        }
    }
}
