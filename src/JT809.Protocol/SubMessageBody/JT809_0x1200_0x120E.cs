using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报车辆行驶路线信息
    /// <para>子业务类型标识:UP_BASE_MSG_DRVLINE_INFO</para>
    /// </summary>
    public class JT809_0x1200_0x120E:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x120E>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报车辆行驶路线信息.ToUInt16Value();

        public override string Description => "主动上报车辆行驶路线信息";
        /// <summary>
        /// 路线信息 按照808-2019中8606规定的报文格式
        /// </summary>
        public byte[] DRVLine { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x1200_0x120E();
            var virtualHex = reader.ReadVirtualArray(reader.ReadCurrentRemainContentLength());
            value.DRVLine = reader.ReadArray(reader.ReadCurrentRemainContentLength()).ToArray();
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]路线信息", value.DRVLine);
        }

        public JT809_0x1200_0x120E Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1200_0x120E();
            value.DRVLine = reader.ReadArray(reader.ReadCurrentRemainContentLength()).ToArray();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x120E value, IJT809Config config)
        {
            writer.WriteArray(value.DRVLine);
        }
    }
}
