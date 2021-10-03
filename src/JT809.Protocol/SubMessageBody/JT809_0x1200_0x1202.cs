using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 实时上传车辆定位信息消息
    /// <para>子业务类型标识:UP_EXG_MSG_REAL_LOCATION</para>
    /// <para>车辆的实时定位信息</para>
    /// <para>无需应答</para>
    /// </summary>
    public class JT809_0x1200_0x1202 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1202>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.实时上传车辆定位信息.ToUInt16Value();

        public override string Description => "实时上传车辆定位信息";
        /// <summary>
        /// 车辆定位信息
        /// </summary>
        public VehiclePositionPropertieBase VehiclePosition { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x1200_0x1202 value = new JT809_0x1200_0x1202();
            writer.WriteStartObject("车辆定位信息");
            VehiclePositionPropertieBase.Analyze(ref reader, writer, config);
            writer.WriteEndObject();
        }

        public JT809_0x1200_0x1202 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1202 value = new JT809_0x1200_0x1202();
            value.VehiclePosition = VehiclePositionPropertieBase.Deserialize(ref reader, config);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1202 value, IJT809Config config)
        {
            VehiclePositionPropertieBase.Serialize(ref writer, value.VehiclePosition, config);
        }
    }
}
