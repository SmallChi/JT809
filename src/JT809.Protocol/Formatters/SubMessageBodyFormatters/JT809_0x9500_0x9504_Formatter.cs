using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9500_0x9504_Formatter : IJT809MessagePackFormatter<JT809_0x9500_0x9504>
    {
        public readonly static JT809_0x9500_0x9504_Formatter Instance = new JT809_0x9500_0x9504_Formatter();

        public JT809_0x9500_0x9504 Deserialize(ref JT809MessagePackReader reader, IJT809Config config)
        {
            JT809_0x9500_0x9504 jT809_0X9500_0X9504 = new JT809_0x9500_0x9504();
            jT809_0X9500_0X9504.Command = (JT809CommandType)reader.ReadByte();
            switch (jT809_0X9500_0X9504.Command)
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
                    jT809_0X9500_0X9504.StartTime = reader.ReadDateTime6();
                    jT809_0X9500_0X9504.EndTime = reader.ReadDateTime6();
                    jT809_0X9500_0X9504.Max = reader.ReadUInt16();
                    break;
            }
            return jT809_0X9500_0X9504;
        }

        public void Serialize(ref JT809MessagePackWriter writer, JT809_0x9500_0x9504 value, IJT809Config config)
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
