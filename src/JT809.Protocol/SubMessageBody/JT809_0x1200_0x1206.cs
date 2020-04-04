using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 结束车辆定位信息交换应答消息
    /// <para>子业务类型标识:UP_EXG_MSG_RETURN_END_ACK</para>
    /// </summary>
    public class JT809_0x1200_0x1206:JT809SubBodies
    {
        public override ushort SubMsgId => JT809SubBusinessType.结束车辆定位信息交换应答消息.ToUInt16Value();

        public override string Description => "结束车辆定位信息交换应答消息";

        public override bool SkipSerialization => true;
    }
}
