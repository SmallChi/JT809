using JT809.Protocol;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT808.Protocol.Formatters
{
    public interface IJT809FormatterFactory : IJT809ExternalRegister
    {
        Dictionary<Guid,object> FormatterDict { get;}
        IJT809FormatterFactory SetMap<TJT809Bodies>()
                    where TJT809Bodies : JT809Bodies;
        IJT809FormatterFactory SetSubMap<TJT809SubBodies>()
            where TJT809SubBodies : JT809SubBodies;
    }
}
