using JT809.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JT809.Protocol.Test.JT1078
{
    public enum JT809_JT1078_BusinessType:ushort
    {
        ///<summary>
        ///主链路时效口令业务类
        ///UP_AUTHORIZE_MSG
        ///</summary>
        [Description("主链路时效口令业务类")]
        [JT809BodiesType(typeof(JT808_JT1078_0x1700))]
        [JT809BusinessTypeDescription("UP_AUTHORIZE_MSG", "主链路时效口令业务类")]
        主链路时效口令业务类 = 0x1700,
    }
}
