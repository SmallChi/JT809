using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补报车辆行驶路线信息应答消息
    /// <para>子业务类型标识:UP_BASE_MSG_VEHICLE_ADDED_ACK</para>
    /// <para>描述:下级平台向上级平台补报车辆行驶路线信息</para>
    /// </summary>
    public class JT809_0x1600_0x1602:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1600_0x1602>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.补报车辆行驶路线信息应答消息.ToUInt16Value();

        public override string Description => "补报车辆行驶路线信息应答消息";
        /// <summary>
        /// 路线信息，808-2019中0x8606规定的报文格式
        /// </summary>
        public byte[] DRVLine { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x1600_0x1602();
            value.DRVLine = reader.ReadArray(reader.ReadCurrentRemainContentLength()).ToArray();
            writer.WriteString($"[{value.DRVLine.ToHexString()}]路线信息", value.DRVLine.ToHexString());
        }

        public JT809_0x1600_0x1602 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1600_0x1602();
            value.DRVLine = reader.ReadArray(reader.ReadCurrentRemainContentLength()).ToArray();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1600_0x1602 value, IJT809Config config)
        {
            writer.WriteArray(value.DRVLine);
        }
    }
}
