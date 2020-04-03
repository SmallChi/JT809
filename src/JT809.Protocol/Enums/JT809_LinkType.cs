using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 链路类型
    /// </summary>
    public enum JT809_LinkType:byte
    {
        /// <summary>
        /// 主链路
        /// </summary>
        main,
        /// <summary>
        /// 从链路
        /// </summary>
        subordinate
    }
}
