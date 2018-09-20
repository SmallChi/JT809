using JT809.Protocol.JT809Attributes;
using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809Formatters;
using System;
using System.Reflection;

namespace JT809.Protocol.JT809Extensions
{
    public  static class JT809FormatterExtensions
    {
        public static IJT809Formatter<T> GetFormatter<T>()
        {
            IJT809Formatter<T> formatter;
            var attr = typeof(T).GetTypeInfo().GetCustomAttribute<JT809FormatterAttribute>();
            if (attr == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetFormatterError, $"该类{typeof(T).FullName}没有标记JT809FormatterAttribute");
            }
            if (attr.Arguments == null)
            {
                formatter = (IJT809Formatter<T>)Activator.CreateInstance(attr.FormatterType);
            }
            else
            {
                formatter = (IJT809Formatter<T>)Activator.CreateInstance(attr.FormatterType, attr.Arguments);
            }
            return formatter;
        }

        public static object GetFormatter(Type formatterType)
        {
            object formatter;
            var attr = formatterType.GetTypeInfo().GetCustomAttribute<JT809FormatterAttribute>();
            if (attr == null)
            {
                throw new JT809Exception(JT809ErrorCode.GetFormatterError,$"该类{formatterType.FullName}没有标记JT809FormatterAttribute");
            }
            if (attr.Arguments == null)
            {
                formatter = Activator.CreateInstance(attr.FormatterType);
            }
            else
            {
                formatter = Activator.CreateInstance(attr.FormatterType, attr.Arguments);
            }
            return formatter;
        }
    }
}
