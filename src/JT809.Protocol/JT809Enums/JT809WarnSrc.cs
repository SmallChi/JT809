using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Enums
{
    /// <summary>
    /// 报警信息来源
    /// </summary>
    public enum JT809WarnSrc : byte
    {
        车载终端 = 0x00,
        企业监控平台 = 0x01,
        政府监管平台 = 0x02,
        其他 =0x09
    }
}
