using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 查岗对象的类型
    /// </summary>
    public enum JT809_0x9302_ObjectType : byte
    {
        下级平台所属单一平台 = 0x00,
        当前连接的下级平台 = 0x01,
        下级平台所属单一业户 = 0x02,
        下级平台所属所有业户 = 0x03,
        下级平台所属所有平台 = 0x04,
        下级平台所属所有平台和业户 = 0x05,
        下级平台所属所有政府监管平台_含监控端 = 0x06,
        下级平台所属所有企业监控平台 = 0x07,
        下级平台所属所有经营性企业监控平台 = 0x08,
        下级平台所属所有非经营性企业监控平台 = 0x09,
    }
}
