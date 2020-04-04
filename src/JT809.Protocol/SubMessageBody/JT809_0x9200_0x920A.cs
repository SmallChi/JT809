using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆驾驶员身份识别信息请求
    /// <para>子业务类型标识:DOWN_EXG_MSG_REPORT_DRIVER_INFO</para>
    /// </summary>
    public class JT809_0x9200_0x920A:JT809SubBodies
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆驾驶员身份识别信息请求.ToUInt16Value();

        public override string Description => "上报车辆驾驶员身份识别信息请求";

        public override bool SkipSerialization => true;
    }
}
