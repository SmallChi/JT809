using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Enums
{
    public enum JT809ErrorCode
    {
        CRC16CheckInvalid = 1001,
        HeaderLengthNotEqualBodyLength=1002,
        GetFormatterError=1003,
        SerializeError=1004,
        DeserializeError=1005,
        HeaderParseError=1006,
        BodiesParseError=1007,
        SubBodiesParseError = 1008,
        GetAttributeError=1009,
        ReaderRemainContentLengthError = 1010,
        NotGlobalRegisterFormatterAssembly=1011,
        IllegalArgument=1012
    }
}
