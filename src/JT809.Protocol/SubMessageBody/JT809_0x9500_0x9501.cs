using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 车辆单向监听请求消息
    /// <para>子业务类型标识:DOWN_CTRL_MSG_MONITOR_VEHICLE_REQ</para>
    /// <para>描述:上级平台向下级平台下发车辆单向监听清求消息</para>
    /// </summary>
    public class JT809_0x9500_0x9501:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9501>, IJT809Analyze
    {
        public override ushort SubMsgId => JT809SubBusinessType.车辆单向监听请求消息.ToUInt16Value();

        public override string Description => "车辆单向监听请求消息";
        /// <summary>
        /// 回拨电话号码
        /// </summary>
        public string MonitorTel { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            JT809_0x9500_0x9501 value = new JT809_0x9500_0x9501();
            var virtualHex = reader.ReadVirtualArray(20);
            value.MonitorTel = reader.ReadString(20);
            writer.WriteString($"[{virtualHex.ToArray().ToHexString()}]回拨电话号码", value.MonitorTel);
        }

        public JT809_0x9500_0x9501 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9501 value = new JT809_0x9500_0x9501();
            value.MonitorTel = reader.ReadString(20);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9501 value, IJT809Config config)
        {
            writer.WriteStringPadRight(value.MonitorTel, 20);
        }
    }
}
