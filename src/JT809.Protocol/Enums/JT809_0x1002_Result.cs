using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public enum JT809_0x1002_Result:byte
    {
        成功=0x00,
        IP地址不正确=0x01,
        接入码不正确=0x02,
        用户没用注册=0x03,
        密码错误=0x04,
        资源紧张_稍后再连接_已经占用= 0x05,
        其他 =0x06,
        其他_2019 = 0xFF
    }
}
