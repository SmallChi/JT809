using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    public enum ErrorCode
    {
        CRC16CheckInvalid = 1001,
        HeaderLengthNotEqualBodyLength=1002
    }
}
