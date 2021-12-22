using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 车辆颜色，按照 JT/T 415-2021 中5.4.12 的规定
    /// </summary>
    public enum JT809VehicleColorType : byte
    {
        蓝色 = 0x01,
        黄色 = 0x02,
        黑色 = 0x03,
        白色 = 0x04,
        其他 = 0x09,
        农黄色 = 91,
        农绿色 = 92,
        黄绿色 = 93,
        渐变绿 = 94,
    }
}
