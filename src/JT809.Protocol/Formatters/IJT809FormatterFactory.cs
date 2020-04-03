using JT809.Protocol;
using JT809.Protocol.Formatters;
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
        IJT809FormatterFactory SetMap<TIJT809Formatter>()
                    where TIJT809Formatter : IJT809Formatter;
    }
}
