using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 报警信息来源
    /// </summary>
    public enum JT809WarnSrc : byte
    {
        车载终端 = 0x01,
        企业监控平台 = 0x02,
        政府监管平台 = 0x03,
        其他 =0x09
    }
}
