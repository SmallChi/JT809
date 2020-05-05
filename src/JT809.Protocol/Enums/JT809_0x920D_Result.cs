using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    public enum JT809_0x920D_Result:byte
    {
        完成记录= 0x00,
        审核通过_完成记录= 0x01,
        信息错误_未完成记录= 0x02,
        审核未通过_未完成记录= 0x03
    }
}
