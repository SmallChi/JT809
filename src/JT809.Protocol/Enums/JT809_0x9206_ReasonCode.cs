using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum JT809_0x9206_ReasonCode : byte
    {
        车辆离开指定区域 = 0x00,
        人工停止交换 = 0x01,
        紧急监控完成 = 0x02,
        车辆离线 = 0x03,
        其它原因 = 0x04
    }
}
