using JT809.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JT809.Protocol.Test.JT1078
{
    public enum JT809_JT1078_SubBusinessType : ushort
    {
        ///<summary>
        ///时效口令上报消息
        ///UP_AUTHRIZE_MSG_STARTUP
        ///</summary>
        [Description("时效口令上报消息")]
        [JT809BodiesType(typeof(JT808_JT1078_0x1700_0x1701))]
        [JT809BusinessTypeDescription("UP_AUTHRIZE_MSG_STARTUP", "主链路时效口令业务类")]
        时效口令上报消息 = 0x1701,
    }
}
