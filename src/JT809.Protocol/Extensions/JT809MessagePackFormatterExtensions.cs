using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace JT809.Protocol.Extensions
{
    public  static class JT809MessagePackFormatterExtensions
    {
        private readonly static ConcurrentDictionary<Guid, object> cache = new ConcurrentDictionary<Guid, object>();

        public static IJT809MessagePackFormatter<T> GetFormatter<T>()
        {
            return (IJT809MessagePackFormatter<T>) GetFormatter(typeof(T));
        }

        public static object GetFormatter(Type type)
        {
            if(!cache.TryGetValue(type.GUID,out object formatter))
            {
                var attr = type.GetTypeInfo().GetCustomAttribute<JT809FormatterAttribute>();
                if (attr == null)
                {
                    throw new JT809Exception(JT809ErrorCode.GetFormatterError, $"该类{type.FullName}没有标记JT809FormatterAttribute");
                }
                if (attr.Arguments == null)
                {
                    formatter = Activator.CreateInstance(attr.FormatterType);
                }
                else
                {
                    formatter = Activator.CreateInstance(attr.FormatterType, attr.Arguments);
                }
                cache.TryAdd(type.GUID, formatter);
            }
            return formatter;
        }
    }
}
