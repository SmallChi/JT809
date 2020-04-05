using JT808.Protocol.Formatters;
using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Internal
{
    class JT809FormatterFactory : IJT809FormatterFactory
    {
        public Dictionary<Guid, object> FormatterDict { get; }

        public JT809FormatterFactory()
        {
            FormatterDict = new Dictionary<Guid, object>();
            Init(Assembly.GetExecutingAssembly());
        }

        private void Init(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes().Where(w => w.GetInterfaces().Contains(typeof(IJT809Formatter))))
            {
                var implTypes = type.GetInterfaces();
                if (implTypes != null && implTypes.Length > 1)
                {
                    var firstType = implTypes.FirstOrDefault(f => f.Name == typeof(IJT809MessagePackFormatter<>).Name);
                    var genericImplType = firstType.GetGenericArguments().FirstOrDefault();
                    if (genericImplType != null)
                    {
                        if (genericImplType.GUID == Guid.Empty)
                        {
                            continue;
                        }
                        if (!FormatterDict.ContainsKey(genericImplType.GUID))
                        {
                            FormatterDict.Add(genericImplType.GUID, Activator.CreateInstance(genericImplType));
                        }
                    }
                }
            }
        }

        public IJT809FormatterFactory SetMap<TIJT809Formatter>() where TIJT809Formatter : IJT809Formatter
        {
            Type type = typeof(TIJT809Formatter);
            if (!FormatterDict.ContainsKey(type.GUID))
            {
                FormatterDict.Add(type.GUID, Activator.CreateInstance(type));
            }
            return this;
        }

        public void Register(Assembly externalAssembly)
        {
            Init(externalAssembly);
        }
    }
}
