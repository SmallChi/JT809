using JT809.Protocol.Extensions;
using JT809.Protocol.Enums;
using JT809.Protocol.SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters.SubMessageBodyFormatters
{
    public class JT809_0x9500_0x9504_Formatter : IJT809Formatter<JT809_0x9500_0x9504>
    {
        public JT809_0x9500_0x9504 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT809_0x9500_0x9504 jT809_0X9500_0X9504 = new JT809_0x9500_0x9504();
            jT809_0X9500_0X9504.Command = (JT809CommandType) JT809BinaryExtensions.ReadByteLittle(bytes, ref offset);
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
                    jT809_0X9500_0X9504.StartTime = JT809BinaryExtensions.ReadDateTime6Little(bytes, ref offset);
                    jT809_0X9500_0X9504.EndTime = JT809BinaryExtensions.ReadDateTime6Little(bytes, ref offset);
                    jT809_0X9500_0X9504.Max = JT809BinaryExtensions.ReadUInt16Little(bytes, ref offset);
                    break;
            }
            readSize = offset;
            return jT809_0X9500_0X9504;
        }

        public int Serialize(ref byte[] bytes, int offset, JT809_0x9500_0x9504 value)
        {
            offset += JT809BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Command);
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
                    offset +=  JT809BinaryExtensions.WriteDateTime6Little(bytes,  offset, value.StartTime);
                    offset +=  JT809BinaryExtensions.WriteDateTime6Little(bytes, offset, value.EndTime);
                    offset +=  JT809BinaryExtensions.WriteUInt16Little(bytes, offset, value.Max);
                    break;
            }
            return offset;
        }
    }
}
