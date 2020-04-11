using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 上报车辆车辆行驶路线请求
    /// <para>子业务类型标识:DOWN_BASE_MSG_DRVLINE_REQ</para>
    /// </summary>
    public class JT809_0x9200_0x920C:JT809SubBodies, IJT809_2019_Version
    {
        public override ushort SubMsgId => JT809SubBusinessType.上报车辆车辆行驶路线请求.ToUInt16Value();

        public override string Description => "上报车辆车辆行驶路线请求";

        public override bool SkipSerialization => true;
    }
}
