using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum JT809_0x9007_ReasonCode : byte
    {
        无法连接下级平台指定的服务IP与端口 = 0x00,
        上级平台客户端与下级平台服务端断开 = 0x01,
        其他原因=0x02
    }
}
