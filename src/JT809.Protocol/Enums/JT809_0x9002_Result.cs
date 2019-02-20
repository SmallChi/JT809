using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public enum JT809_0x9002_Result:byte
    {
        成功=0x00,
        VERIFY_CODE错误= 0x01,
        资源紧张_稍后再连接_已经占用= 0x02,
        其他= 0x03
    }
}
