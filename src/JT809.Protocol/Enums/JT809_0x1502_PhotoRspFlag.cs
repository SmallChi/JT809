using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 拍照应答标识
    /// </summary>
    public enum JT809_0x1502_PhotoRspFlag : byte
    {
        不支持拍照 = 0x00,
        完成拍照 = 0x01,
        完成拍照_照片数据稍后传送 = 0x02,
        未拍照_不在线 = 0x03,
        未拍照_无法使用指定镜头  = 0x04,
        未拍照_其他原因 = 0x05,
        车牌号码错误 = 0x09,
    }
}
