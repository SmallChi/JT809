using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Formatters;
using System;
using System.Reflection;

namespace JT809.Protocol.Extensions
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

        static JT809FormatterExtensions()
        {
            PackageFormatter = (JT809PackageFormatter)GetFormatter<JT809Package>();
            HeaderPackageFormatter = (JT809HeaderPackageFormatter)GetFormatter<JT809HeaderPackage>();
            HeaderFormatter = (JT809HeaderFormatter)GetFormatter<JT809Header>();
        }
        public static JT809PackageFormatter PackageFormatter { get; }
        public static JT809HeaderPackageFormatter HeaderPackageFormatter { get; }
        public static JT809HeaderFormatter HeaderFormatter { get; }
    }
}
