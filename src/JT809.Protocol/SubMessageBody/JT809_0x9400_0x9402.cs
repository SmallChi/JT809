using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 报警预警2013
    /// 下发报警预警消息2019
    /// <para>子业务类型标识:DOWN_WARN_MSG_INFORM_TIPS</para>
    /// <para>描述:用于上级平台向车辆归属或车辆跨域下级平台下发相关车辆的报警顶警或运行提示信息</para>
    /// <para>本条消息下级平台无需应答</para>
    /// </summary>
    public class JT809_0x9400_0x9402:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9400_0x9402>,IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.报警预警2013_下发报警预警消息2019.ToUInt16Value();

        public override string Description => "报警预警2013_下发报警预警消息2019";
        /// <summary>
        /// 报警信息来源
        /// </summary>
        public JT809WarnSrc WarnSrc { get; set; }
        /// <summary>
        /// 发起报警平台唯一编码，由平台所在地行政区域代码和平台编号组成
        /// </summary>
        public byte[] SourcePlatformId { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public JT809WarnType WarnType { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime WarnTime { get; set; }
        /// <summary>
        /// 事件开始时间 utc
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 事件结束时间 utc
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 车牌号码 非车辆相关报警全填0
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 车牌颜色  非车辆相关报警全填0
        /// </summary>
        public JT809VehicleColorType VehicleColor { get; set; }
        /// <summary>
        /// 被报警平台唯一编码，由平台所在地行政区划代码和平台编号组成。非平台相关报警全填0
        /// </summary>
        public byte[] DestinationPlatformId { get; set; }
        /// <summary>
        /// 线路ID 808-2019中0x8606规定的报文中的线路ＩＤ
        /// </summary>
        public uint DRVLineId { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint WarnLength { get; set; }
        /// <summary>
        /// 报警描述
        /// </summary>
        public string WarnContent { get; set; }

        public JT809_0x9400_0x9402 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9400_0x9402();
            if (config.Version == JT809Version.JTT2011)
            {
                value.WarnSrc = (JT809WarnSrc)reader.ReadByte();
            }
            else 
            {
                value.SourcePlatformId = reader.ReadArray(11).ToArray();
            }
            value.WarnType = (JT809WarnType)reader.ReadUInt16();
            value.WarnTime = reader.ReadUTCDateTime();
            if (config.Version == JT809Version.JTT2019) {
                value.StartTime = reader.ReadUTCDateTime();
                value.EndTime = reader.ReadUTCDateTime();
#warning 此处车牌号文档长度有误，使用旧版长度21
                value.VehicleNo = reader.ReadString(21);
                value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
                value.DestinationPlatformId = reader.ReadArray(11).ToArray();
                value.DRVLineId = reader.ReadUInt32();
            }
            value.WarnLength = reader.ReadUInt32();
            value.WarnContent = reader.ReadString((int)value.WarnLength);
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9400_0x9402 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2011)
            {
                writer.WriteByte((byte)value.WarnSrc);
            }
            else 
            {
                writer.WriteArray(value.SourcePlatformId);
            }
            writer.WriteUInt16((ushort)value.WarnType);
            writer.WriteUTCDateTime(value.WarnTime);
            if (config.Version == JT809Version.JTT2019) {
                writer.WriteUTCDateTime(value.StartTime);
                writer.WriteUTCDateTime(value.EndTime);
                writer.WriteStringPadRight(value.VehicleNo, 21);
                writer.WriteByte((byte)value.VehicleColor);
                writer.WriteArray(value.DestinationPlatformId);
                writer.WriteUInt32(value.DRVLineId);
            }
            // 先计算内容长度（汉字为两个字节）
            writer.Skip(4, out int lengthPosition);
            writer.WriteString(value.WarnContent);
            writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);
        }
    }
}
