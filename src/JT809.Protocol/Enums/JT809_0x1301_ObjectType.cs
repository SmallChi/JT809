using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    /// <summary>
    /// 查岗对象的类型
    /// </summary>
    public enum JT809_0x1301_ObjectType:byte
    {
        当前连接的下级平台=0x01,
        下级平台所属单一业户=0x02,
        下级平台所属所有业户=0x03
    }
}
