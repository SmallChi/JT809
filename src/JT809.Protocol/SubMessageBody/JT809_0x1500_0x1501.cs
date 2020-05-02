using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆单向监听应答
    /// <para>子业务类型标识:UP_CTRL_MSG_MONITOR_VEHTCLE_ACK</para>
    /// <para>描述:下级平台向上级平台上传车辆单向监听请求消息的应答</para>
    /// </summary>
    public class JT809_0x1500_0x1501:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1500_0x1501>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆单向监听应答.ToUInt16Value();

        public override string Description => "车辆单向监听应答";
        /// <summary>
        /// 应答结果
        /// </summary>
        public JT809_0x1501_Result Result { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1500_0x1501 value = new JT809_0x1500_0x1501();
            value.Result = (JT809_0x1501_Result)reader.ReadByte();
            writer.WriteString($"[{value.Result.ToByteValue()}]应答结果", value.Result.ToString());
        }

        public JT809_0x1500_0x1501 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1500_0x1501 value = new JT809_0x1500_0x1501();
            value.Result = (JT809_0x1501_Result)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1500_0x1501 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.Result);
        }
    }
}
