using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 启动车辆定位信息交换请求消息
    /// <para>子业务类型标识:DOWN_EXG_MSG_RETURN_STARTUP</para>
    /// <para>描述:在有车辆进入非归属地区地理区域、人工指定车辆定位信息交换和应急状态监控车辆时，上级平台向下级平台发出启动车辆定位信息交换清求消息。下级平台收到此命令后需要回复启动车辆定位信息交换应答消息给上级平台，即UP_EXG_MSG-RETURN-STARTUP_ ACK</para>
    /// </summary>
    public class JT809_0x9200_0x9205:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9205>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.启动车辆定位信息交换请求消息.ToUInt16Value();

        public override string Description => "启动车辆定位信息交换请求消息";
        /// <summary>
        /// 启动车辆定位信息交换请求原因
        /// </summary>
        public JT809_0x9205_ReasonCode ReasonCode { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9200_0x9205 value = new JT809_0x9200_0x9205();
            value.ReasonCode = (JT809_0x9205_ReasonCode)reader.ReadByte();
            writer.WriteString($"[{value.ReasonCode.ToByteValue()}]启动车辆定位信息交换请求原因", value.ReasonCode.ToString());
        }

        public JT809_0x9200_0x9205 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9205 value = new JT809_0x9200_0x9205();
            value.ReasonCode = (JT809_0x9205_ReasonCode)reader.ReadByte();
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9205 value, IJT809Config config)
        {
            writer.WriteByte((byte)value.ReasonCode);
        }
    }
}
