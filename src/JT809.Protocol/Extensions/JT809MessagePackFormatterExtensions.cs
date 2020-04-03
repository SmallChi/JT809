using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace JT809.Protocol.Extensions
{
    public  static class JT809MessagePackFormatterExtensions
    {
        private readonly static ConcurrentDictionary<string, JT809Serializer> jT809SerializerDict = new ConcurrentDictionary<string, JT809Serializer>(StringComparer.OrdinalIgnoreCase);
        public static IJT809MessagePackFormatter<T> GetMessagePackFormatter<T>(this IJT809Config config)
        {
            return (IJT809MessagePackFormatter<T>)GetMessagePackFormatterByType(config, typeof(T));
        }
        public static object GetMessagePackFormatterByType(this IJT809Config config, Type type)
        {
            if (!config.FormatterFactory.FormatterDict.TryGetValue(type.GUID, out var formatter))
            {
                throw new JT809Exception(JT809ErrorCode.NotGlobalRegisterFormatterAssembly, type.FullName);
            }
            return formatter;
        }
        public static object GetAnalyzeByType(this IJT809Config config, Type type)
        {
            if (!config.FormatterFactory.FormatterDict.TryGetValue(type.GUID, out var analyze))
            {
                throw new JT809Exception(JT809ErrorCode.NotGlobalRegisterFormatterAssembly, type.FullName);
            }
            return analyze;
        }
        public static IJT809Analyze GetAnalyze<T>(this IJT809Config config)
        {
            return (IJT809Analyze)GetAnalyzeByType(config, typeof(T));
        }
        public static JT809Serializer GetSerializer(this IJT809Config config)
        {
            if (!jT809SerializerDict.TryGetValue(config.ConfigId, out var serializer))
            {
                serializer = new JT809Serializer(config);
                jT809SerializerDict.TryAdd(config.ConfigId, serializer);
            }
            return serializer;
        }
    }
}
