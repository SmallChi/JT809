using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 启动车辆定位信息交换应答消息
    /// <para>子业务类型标识:UP_EXG_ MSG_ RETURN_ STARTUP ACK</para>
    /// <para>描述：本条消息是下级平台对上级平台下发的 DOWN_EXG_ MSG_ RETURN_STARTUP 消息的应答消息</para>
    /// </summary>
    public class JT809_0x1200_0x1205:JT809SubBodies
    {
        public override ushort SubMsgId => JT809SubBusinessType.启动车辆定位信息交换应答消息.ToUInt16Value();

        public override string Description => "启动车辆定位信息交换应答消息";

        public override bool SkipSerialization => true;
    }
}
