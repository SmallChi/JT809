using System;
using System.Collections.Generic;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809SubBusinessTypeFactory : IJT809ExternalRegister
    {
        IDictionary<ushort, object> Map { get; }
        bool TryGetValue(ushort msgId, out object instance);
        IJT809SubBusinessTypeFactory SetMap<TJT809SubBodies>() where TJT809SubBodies : JT809SubBodies;
    }
}
