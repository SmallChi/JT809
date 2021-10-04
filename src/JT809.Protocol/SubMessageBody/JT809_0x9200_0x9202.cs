using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Metadata;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
#warning   8.3.3.2.5 交换车辆行驶路线信息消息  无指定消息子类型，暂未对接
    /// <summary>
    /// 交换车辆定位信息消息
    /// <para>子业务类型标识:DOWN_EXG_MSG_CAR_LOCATION</para>
    /// <para>2011 描述:上级平台通过该消息不间断地向车辆驶入区域所属的下级平台发送车辆定位信息，直到该车驶离该区域</para>
    /// <para>2019 描述：上级平台在以下四种情况下通过该消息不间断地向车辆进入区域所属的下级平台发送车辆定位信息，直到该车辆离开该区域
    /// 1.车辆跨域时，上级平台通过该消息不间断地向车辆进入区域所属的下级平台发送车辆定位信息，直到该车辆离开该区域
    /// 2.人工指定车辆定位信息交换时，上级平台通过该消息不间断地向指定交换对象下级平台发送车辆定位信息，直到人工指定“交换车辆定位信息”结束
    /// 3.下级平台向上级平台“申请交换指定车辆定位信息”成功后，上级平台通过该消息不间断地向交换对象下级平台发送车辆定位信息，直到“申请交换指定车辆定位信息”结束
    /// 4.应急状态监控车辆时，上级平台向车辆归属下级平台通过该消息不间断地发送车辆定位信息，实现车辆定位信息回传
    /// </para>
    /// </summary>
    public class JT809_0x9200_0x9202 : JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9200_0x9202>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.交换车辆定位信息消息.ToUInt16Value();

        public override string Description => "交换车辆定位信息消息";
        /// <summary>
        /// 车辆定位信息 2011版本
        /// </summary>
        public JT809VehiclePositionProperties VehiclePosition { get; set; }
        /// <summary>
        /// 车辆定位信息 2019版本
        /// </summary>
        public JT809VehiclePositionProperties_2019 VehiclePosition_2019 { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
                config.GetMessagePackFormatter<JT809VehiclePositionProperties>().Analyze(ref reader, writer, config);
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                config.GetMessagePackFormatter<JT809VehiclePositionProperties_2019>().Analyze(ref reader, writer, config);
            }
        }

        public JT809_0x9200_0x9202 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9200_0x9202 value = new JT809_0x9200_0x9202();
            if (config.Version == JT809Version.JTT2011)
            {
                value.VehiclePosition = config.GetMessagePackFormatter<JT809VehiclePositionProperties>().Deserialize(ref reader, config);
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                value.VehiclePosition_2019 = config.GetMessagePackFormatter<JT809VehiclePositionProperties_2019>().Deserialize(ref reader, config);
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9200_0x9202 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
                if (value.VehiclePosition != null)
                {
                    config.GetMessagePackFormatter<JT809VehiclePositionProperties>().Serialize(ref writer, value.VehiclePosition, config);
                }
            }
            else if (config.Version == JT809Version.JTT2019)
            {
                if (value.VehiclePosition_2019 != null)
                {
                    config.GetMessagePackFormatter<JT809VehiclePositionProperties_2019>().Serialize(ref writer, value.VehiclePosition_2019, config);
                }
            }
        }
    }
}
