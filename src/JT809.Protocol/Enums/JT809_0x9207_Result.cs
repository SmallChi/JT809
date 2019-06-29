using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public enum JT809_0x9207_Result : byte
    {
        申请成功 = 0x00,
        上级平台没有该车数据 = 0x01,
        申请时间段错误 = 0x02,
        其它 = 0x03
    }
}
