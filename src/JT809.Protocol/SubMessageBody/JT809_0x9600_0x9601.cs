using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.SubMessageBody
{
    /// <summary>
    /// 补报车辆静态信息请求消息
    /// <para>子业务类型标识:DOWN_BASE_MSG_VEHICLE_ADDED</para>
    /// <para>描述:上级平台在接收到车辆定位信息后，发现该车辆静态信息在上级平台不存在，上级平台向下级平台下发补报该车辆静态信息的请求消息</para>
    /// </summary>
    public class JT809_0x9600_0x9601:JT809SubBodies
    {
    }
}
