using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 命令字ID
    /// </summary>
    public enum JT809CommandType:byte
    {
        记录仪标准版本=0x00,
        当前驾驶人信息=0x01,
        记录仪时间=0x02,
        记录仪累计行驶里程=0x03,
        记录仪脉冲系数=0x04,
        车辆信息 = 0x05,
        记录仪状态信号配置信息 = 0x06,
        记录仪唯一性编号 = 0x07,
        采集记录仪行驶记录 = 0x08,
        采集记录仪位置信息记录 = 0x09,
        采集记录仪事故疑点记录 = 0x10,
        采集记录仪超时驾驶记录 = 0x11,
        采集记录仪驾驶人身份记录=0x12,
        采集记录仪外部供电记录=0x13,
        采集记录仪参数修改记录 = 0x14,
        采集记录仪速度状态日志 = 0x15,
    }
}
