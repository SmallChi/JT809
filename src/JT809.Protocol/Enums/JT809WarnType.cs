using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    ///  报警类型
    /// </summary>
    public enum JT809WarnType:ushort
    {
            超速报警=0x0001,
            疲劳驾驶报警=0x0002,
            紧急报警= 0x0003,
            进入指定区域报警= 0x0004,
            离开指定区域报警= 0x0005,
            路段赌赛报警= 0x0006,
            危险路段报警= 0x0007,
            越界报警= 0x0008,
            盗警= 0x0009,
            劫警= 0x000A,
            偏离路线报警= 0x000B,
            车辆移动报警= 0x000C,
            超时驾驶报警= 0x000D,
            其他报警= 0x000E
    }
}
