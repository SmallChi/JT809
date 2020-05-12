using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Concurrent;

namespace JT809.Protocol
{
    public static class JT809ConfigExtensions
    {
        private readonly static ConcurrentDictionary<string, JT809Serializer> jT809SerializerDict = new ConcurrentDictionary<string, JT809Serializer>(StringComparer.OrdinalIgnoreCase);

        public static object GetMessagePackFormatterByType(this IJT809Config jT809Config, Type type)
        {
            if (!jT809Config.FormatterFactory.FormatterDict.TryGetValue(type.GUID, out var formatter))
            {
                throw new JT809Exception(JT809ErrorCode.NotGlobalRegisterFormatterAssembly, type.FullName);
            }
            return formatter;
        }
        public static IJT809MessagePackFormatter<T> GetMessagePackFormatter<T>(this IJT809Config jT809Config)
        {
            return (IJT809MessagePackFormatter<T>)GetMessagePackFormatterByType(jT809Config, typeof(T));
        }
        public static JT809Serializer GetSerializer(this IJT809Config jT808Config)
        {
            if(!jT809SerializerDict.TryGetValue(jT808Config.ConfigId,out var serializer))
            {
                serializer = new JT809Serializer(jT808Config);
                jT809SerializerDict.TryAdd(jT808Config.ConfigId, serializer);
            }
            return serializer;
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
    }
}
