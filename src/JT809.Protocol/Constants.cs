using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// 常量
    /// </summary>
    public static  class Constants
    {
        /// <summary>
        /// 报警类型
        /// </summary>
        public readonly static Dictionary<ushort, string> AlramType = new Dictionary<ushort, string>()
        {
            {0x0001,"超速报警"},
            {0x0002,"疲劳驾驶报警"},
            {0x0003,"紧急报警"},
            {0x0004,"进入指定区域报警"},
            {0x0005,"离开指定区域报警"},
            {0x0006,"路段赌赛报警"},
            {0x0007,"危险路段报警"},
            {0x0008,"越界报警"},
            {0x0009,"盗警"},
            {0x000A,"劫警"},
            {0x000B,"偏离路线报警"},
            {0x000C,"车辆移动报警"},
            {0x000D,"超时驾驶报警"},
            {0x000E,"其他报警"}
        };

        /// <summary>
        /// 车牌颜色
        /// </summary>
        public readonly static Dictionary<byte, string> CarColor = new Dictionary<byte, string>()
        {
            {1,"蓝色"},
            {2,"黄色"},
            {3,"黄色"},
            {4,"白色"},
            {5,"绿"},
            {6,"黄绿"},
            {8,"农黄"},
            {9,"其他"}
        };
    }
}
