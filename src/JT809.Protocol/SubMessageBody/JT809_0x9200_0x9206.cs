using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 结束车辆定位信息交换请求
    /// <para>子业务类型标识:DOWN_EXG_MSG_RETURN_END</para>
    /// <para>描述:在进入非归属地区地理区域的车辆离开该地理区域、人上取消指定车辆定位信息交换和应急状态结束时，上级平台向下级平台发出结束车辆定位信息交换请求消息。下级平台收到该命令后应回复结束车辆定位信息交换应答消息，即 UP_EXG_MSG_RE_TURN_END_ACK</para>
    /// </summary>
    public class JT809_0x9200_0x9206:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9206>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.结束车辆定位信息交换请求.ToUInt16Value();

        public override string Description => "结束车辆定位信息交换请求";
        /// <summary>
        /// 结束车辆定位信息交换请求原因
        /// </summary>
        public JT809_0x9206_ReasonCode ReasonCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9200_0x9206 value = new JT809_0x9200_0x9206();
            value.ReasonCode = (JT809_0x9206_ReasonCode)reader.ReadByte();
            writer.WriteString($"[{value.ReasonCode.ToByteValue()}]结束车辆定位信息交换请求原因", value.ReasonCode.ToString());
        }

        public JT809_0x9200_0x9206 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9206 value = new JT809_0x9200_0x9206();
            value.ReasonCode = (JT809_0x9206_ReasonCode)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9206 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
