using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 主动上报报警处理结果信息(2013)
    /// 上报报警预警信息（2019）
    /// <para>子业务类型标识:UP_WARN_MSG_ADPT_TODO_INFO_2013</para>
    /// <para>子业务类型标识:UP_WARN_MSG_INFORM_TIPS_2019</para>
    /// <para>描述:下级平台向上级平台上报报警处理结果2013</para>
    /// <para>描述：用于下级平台向上级平台上报相关报警预警或运行提示信息2019</para>
    /// <para>本条消息上级平台无需应答</para>
    /// </summary>
    public class JT809_0x1400_0x1403:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x1400_0x1403>, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.主动上报报警处理结果信息2013_上报报警预警信息2019.ToUInt16Value();

        public override string Description => "主动上报报警处理结果信息2013_上报报警预警信息2019";
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
        public uint InfoLength { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public string InfoContent { get; set; }
        /// <summary>
        /// 报警信息ID
        /// </summary>
        public uint InfoID { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public JT809_0x1403_Result Result { get; set; }
        public JT809_0x1400_0x1403 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x1400_0x1403();
            if (config.Version == JT809Version.JTT2013)
            {
                value.InfoID = reader.ReadUInt32();
                value.Result = (JT809_0x1403_Result)reader.ReadByte();
            }
            else {
                value.SourcePlatformId = reader.ReadArray(11).ToArray();
                value.WarnType = (JT809WarnType)reader.ReadUInt16();
                value.WarnTime = reader.ReadUTCDateTime();
                value.StartTime = reader.ReadUTCDateTime();
                value.EndTime = reader.ReadUTCDateTime();
#warning 此处车牌号文档长度有误，使用旧版长度21
                value.VehicleNo = reader.ReadString(21);
                value.VehicleColor = (JT809VehicleColorType)reader.ReadByte();
                value.DestinationPlatformId = reader.ReadArray(11).ToArray();
                value.DRVLineId = reader.ReadUInt32();
                value.InfoLength = reader.ReadUInt32();
                value.InfoContent = reader.ReadString((int)value.InfoLength);
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x1400_0x1403 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2013)
            {
                writer.WriteUInt32(value.InfoID);
                writer.WriteByte((byte)value.Result);
            }
            else {
                writer.WriteArray(value.SourcePlatformId);
                writer.WriteUInt16((ushort)value.WarnType);
                writer.WriteUTCDateTime(value.WarnTime);
                writer.WriteUTCDateTime(value.StartTime);
                writer.WriteUTCDateTime(value.EndTime);
                writer.WriteStringPadRight(value.VehicleNo, 21);
                writer.WriteByte((byte)value.VehicleColor);
                writer.WriteArray(value.DestinationPlatformId);
                writer.WriteUInt32(value.DRVLineId);
                // 先计算内容长度（汉字为两个字节）
                writer.Skip(4, out int lengthPosition);
                writer.WriteString(value.InfoContent);
                writer.WriteInt32Return(writer.GetCurrentPosition() - lengthPosition - 4, lengthPosition);

            }
        }
    }
}
