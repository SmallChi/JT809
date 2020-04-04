using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 申请交换指定车辆定位信息请求消息
    /// <para>子业务类型标识:UP_EXG_MSG_APPLY-FOR_MONITOR_STARTUP</para>
    /// <para>描述:当下级平台需要在特定时问段内监控特殊车辆时，可上传此命令到上级平台申请对该车辆定位数据交换到下级平台，申请成功后，此车辆定位数据将在指定时间内交换到该平台(即使该车没有进入该平台所属区域也会交换)</para>
    /// </summary>
    public class JT809_0x1200_0x1207:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1200_0x1207>
    {
        public override ushort SubMsgId => JT809SubBusinessType.申请交换指定车辆定位信息请求消息.ToUInt16Value();

        public override string Description => "申请交换指定车辆定位信息请求消息";

        /// <summary>
        /// 开始时间，用 UTC 时间表示
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间，用 UTC 时间表示
        /// </summary>
        public DateTime EndTime { get; set; }


        public JT809_0x1200_0x1207 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x1200_0x1207 jT809_0X1200_0X1207 = new JT809_0x1200_0x1207();
            jT809_0X1200_0X1207.StartTime = reader.ReadUTCDateTime();
            jT809_0X1200_0X1207.EndTime = reader.ReadUTCDateTime();
            return jT809_0X1200_0X1207;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1200_0x1207 value, IJT809Config config)
        {
            writer.WriteUTCDateTime(value.StartTime);
            writer.WriteUTCDateTime(value.EndTime);
        }
    }
}
