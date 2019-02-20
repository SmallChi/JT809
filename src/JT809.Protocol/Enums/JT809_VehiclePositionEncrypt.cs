using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 定位信息是否使用国家测绘局批准的地图保密插件进行加密。
    /// </summary>
    public enum JT809_VehiclePositionEncrypt:byte
    {
        未加密 = 0x00,
        已加密 = 0x01
    }
}
