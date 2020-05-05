using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using JT809.Protocol.Interfaces;
using System.Text.Json;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆行驶记录请求消息
    /// <para>子业务类型标识:DOVJN_CTRL_MSG_TAKE_TRAVEL_REQ</para>
    /// <para>描述:上级平台向下级平台下发上报车辆行驶记录请求消息</para>
    /// </summary>
    public class JT809_0x9500_0x9504:JT809SubBodies, IJT809MessagePackFormatter<JT809_0x9500_0x9504>, IJT809Analyze, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆行驶记录请求消息.ToUInt16Value();

        public override string Description => "上报车辆行驶记录请求消息";
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 命令字ID
        /// </summary>
        public JT809CommandType Command { get; set; }
        /// <summary>
        /// 最大数据数
        /// </summary>
        public ushort Max { get; set; }

        public void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            var value = new JT809_0x9500_0x9504();
            if (config.Version == JT809Version.JTT2019)
            {
                var hex = reader.ReadVirtualArray(8);
                value.StartTime = reader.ReadUTCDateTime();
                writer.WriteString($"[{hex.ToArray().ToHexString()}]开始时间", value.StartTime);
                hex = reader.ReadVirtualArray(8);
                value.EndTime = reader.ReadUTCDateTime();
                writer.WriteString($"[{hex.ToArray().ToHexString()}]结束时间", value.EndTime);
                value.Command = (JT809CommandType)reader.ReadByte();
                writer.WriteString($"[{value.Command.ToByteValue()}]命令字ID", value.Command.ToString());
            }
            else
            {
                value.Command = (JT809CommandType)reader.ReadByte();
                writer.WriteString($"[{value.Command.ToByteValue()}]命令字ID", value.Command.ToString());
                switch (value.Command)
                {
                    case JT809CommandType.记录仪标准版本:
                    case JT809CommandType.当前驾驶人信息:
                    case JT809CommandType.记录仪时间:
                    case JT809CommandType.记录仪累计行驶里程:
                    case JT809CommandType.记录仪脉冲系数:
                    case JT809CommandType.车辆信息:
                    case JT809CommandType.记录仪状态信号配置信息:
                    case JT809CommandType.记录仪唯一性编号:
                        break;
                    case JT809CommandType.采集记录仪行驶记录:
                    case JT809CommandType.采集记录仪位置信息记录:
                    case JT809CommandType.采集记录仪事故疑点记录:
                    case JT809CommandType.采集记录仪超时驾驶记录:
                    case JT809CommandType.采集记录仪驾驶人身份记录:
                    case JT809CommandType.采集记录仪外部供电记录:
                    case JT809CommandType.采集记录仪参数修改记录:
                    case JT809CommandType.采集记录仪速度状态日志:
                        var hex = reader.ReadVirtualArray(6);
                        value.StartTime = reader.ReadDateTime6();
                        writer.WriteString($"[{hex.ToArray().ToHexString()}]开始时间", value.StartTime);
                        hex = reader.ReadVirtualArray(6);
                        value.EndTime = reader.ReadDateTime6();
                        writer.WriteString($"[{hex.ToArray().ToHexString()}]结束时间", value.EndTime);
                        value.Max = reader.ReadUInt16();
                        writer.WriteNumber($"[{value.Max.ReadNumber()}]最大数据数", value.Max);
                        break;
                }
            }
        }

        public JT809_0x9500_0x9504 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            var value = new JT809_0x9500_0x9504();
            if(config.Version == JT809Version.JTT2019)
            {
                value.StartTime = reader.ReadUTCDateTime();
                value.EndTime = reader.ReadUTCDateTime();
                value.Command = (JT809CommandType)reader.ReadByte();
            }
            else 
            {
                value.Command = (JT809CommandType)reader.ReadByte();
                switch (value.Command)
                {
                    case JT809CommandType.记录仪标准版本:
                    case JT809CommandType.当前驾驶人信息:
                    case JT809CommandType.记录仪时间:
                    case JT809CommandType.记录仪累计行驶里程:
                    case JT809CommandType.记录仪脉冲系数:
                    case JT809CommandType.车辆信息:
                    case JT809CommandType.记录仪状态信号配置信息:
                    case JT809CommandType.记录仪唯一性编号:
                        break;
                    case JT809CommandType.采集记录仪行驶记录:
                    case JT809CommandType.采集记录仪位置信息记录:
                    case JT809CommandType.采集记录仪事故疑点记录:
                    case JT809CommandType.采集记录仪超时驾驶记录:
                    case JT809CommandType.采集记录仪驾驶人身份记录:
                    case JT809CommandType.采集记录仪外部供电记录:
                    case JT809CommandType.采集记录仪参数修改记录:
                    case JT809CommandType.采集记录仪速度状态日志:
                        value.StartTime = reader.ReadDateTime6();
                        value.EndTime = reader.ReadDateTime6();
                        value.Max = reader.ReadUInt16();
                        break;
                }
            }
            return value;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9504 value, IJT809Config config)
        {
            if (config.Version == JT809Version.JTT2019)
            {
                writer.WriteUTCDateTime(value.StartTime);
                writer.WriteUTCDateTime(value.EndTime);
                writer.WriteByte((byte)value.Command);
            }
            else 
            {
                writer.WriteByte((byte)value.Command);
                switch (value.Command)
                {
                    case JT809CommandType.记录仪标准版本:
                    case JT809CommandType.当前驾驶人信息:
                    case JT809CommandType.记录仪时间:
                    case JT809CommandType.记录仪累计行驶里程:
                    case JT809CommandType.记录仪脉冲系数:
                    case JT809CommandType.车辆信息:
                    case JT809CommandType.记录仪状态信号配置信息:
                    case JT809CommandType.记录仪唯一性编号:
                        break;
                    case JT809CommandType.采集记录仪行驶记录:
                    case JT809CommandType.采集记录仪位置信息记录:
                    case JT809CommandType.采集记录仪事故疑点记录:
                    case JT809CommandType.采集记录仪超时驾驶记录:
                    case JT809CommandType.采集记录仪驾驶人身份记录:
                    case JT809CommandType.采集记录仪外部供电记录:
                    case JT809CommandType.采集记录仪参数修改记录:
                    case JT809CommandType.采集记录仪速度状态日志:
                        writer.WriteDateTime6(value.StartTime);
                        writer.WriteDateTime6(value.EndTime);
                        writer.WriteUInt16(value.Max);
                        break;
                }
            }
        }
    }
}
