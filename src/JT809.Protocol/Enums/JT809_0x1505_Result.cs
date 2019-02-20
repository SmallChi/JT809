using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 应答结果
    /// </summary>
    public enum JT809_0x1505_Result : byte
    {
        车载终端成功收到该命令 = 0x00,
        无该车辆 = 0x01,
        其它原因失败=0x02
    }
}
