using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809BusinessTypeFactory : IJT809ExternalRegister
    {
        IDictionary<ushort, object> Map { get; }
        IDictionary<ushort, object> Map_2019 { get; }
        bool TryGetValue(ushort msgId, JT809Version version , out object instance);
        IJT809BusinessTypeFactory SetMap<TJT809Bodies>() where TJT809Bodies : JT809Bodies;
    }
}
