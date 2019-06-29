using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum JT809_0x9205_ReasonCode : byte
    {
        车辆进入指定区域 = 0x00,
        人工指定交换 = 0x01,
        应急状态下车辆定位信息回传 = 0x02,
        其它原因 = 0x03
    }
}
