using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 处理结果
    /// </summary>
    public enum JT809_0x9201_Result : byte
    {
        完成注册_加注释=0x00,
        审核通过_完成注册= 0x01,
        信息错误_未完成注册= 0x02,
        审核没通过_未完成注册= 0x03
    }
}
