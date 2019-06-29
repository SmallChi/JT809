using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum JT809_0x1007_ErrorCode:byte
    {
        主链路断开=0x00,
        其他原因=0x01
    }
}
