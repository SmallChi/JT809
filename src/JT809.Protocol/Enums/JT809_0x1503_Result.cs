using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 应答结果
    /// </summary>
    public enum JT809_0x1503_Result : byte
    {
        下发成功 = 0x00,
        下发失败 = 0x01,
    }
}
