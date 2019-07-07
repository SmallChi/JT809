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
            foreach (var type in assembly.GetTypes())
            {
                var attr = type.GetCustomAttribute<JT809FormatterAttribute>();
                if (attr != null)
                {
                    if (!FormatterDict.ContainsKey(type.GUID))
                    {
                        FormatterDict.Add(type.GUID, Activator.CreateInstance(attr.FormatterType));
                    }
                }
            }
        }

        public IJT809FormatterFactory SetMap<TJT809Bodies>() where TJT809Bodies : JT809Bodies
        {
            Type bodiesType = typeof(TJT809Bodies);
            var attr = bodiesType.GetTypeInfo().GetCustomAttribute<JT809FormatterAttribute>();
            if (attr == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetFormatterAttributeError, bodiesType.FullName);
            }
            if (!FormatterDict.ContainsKey(bodiesType.GUID))
            {
                FormatterDict.Add(bodiesType.GUID, Activator.CreateInstance(attr.FormatterType));
            }
            return this;
        }

        public void Register(Assembly externalAssembly)
        {
            Init(externalAssembly);
        }

        public IJT809FormatterFactory SetSubMap<TJT809SubBodies>() where TJT809SubBodies : JT809SubBodies
        {
            Type bodiesType = typeof(TJT809SubBodies);
            var attr = bodiesType.GetTypeInfo().GetCustomAttribute<JT809FormatterAttribute>();
            if (attr == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetFormatterAttributeError, bodiesType.FullName);
            }
            if (!FormatterDict.ContainsKey(bodiesType.GUID))
            {
                FormatterDict.Add(bodiesType.GUID, Activator.CreateInstance(attr.FormatterType));
            }
            return this;
        }
    }
}
