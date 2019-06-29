using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public enum JT809_0x9209_Result : byte
    {
        成功_上级平台即刻补发 = 0x00,
        成功_上级平台择机补发 = 0x01,
        失败_上级平台无对应申请的定位数据 = 0x02,
        失败_申请内容不正确 = 0x03,
        其它原因 = 0x04,
    }
}
