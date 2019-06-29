using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 报警处理结果
    /// </summary>
    public enum JT809_0x1401_Result : byte
    {
        处理中 = 0x00,
        已处理完毕 = 0x01,
        不做处理 = 0x02,
        将来处理 = 0x03
    }
}
