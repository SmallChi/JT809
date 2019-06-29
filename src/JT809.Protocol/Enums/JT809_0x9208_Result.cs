using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public enum JT809_0x9208_Result : byte
    {
        取消申请成功 = 0x00,
        之前没有对应申请信息 = 0x01,
        其它 = 0x02
    }
}
