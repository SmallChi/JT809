using JT809.Protocol.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Extensions
{
    public static class JT809ConfigExtensions
    {
        private readonly static ConcurrentDictionary<string, JT809Serializer> jT809SerializerDict = new ConcurrentDictionary<string, JT809Serializer>(StringComparer.OrdinalIgnoreCase);
        public static JT809Serializer GetSerializer(this IJT809Config jT808Config)
        {
            if(!jT809SerializerDict.TryGetValue(jT808Config.ConfigId,out var serializer))
            {
                serializer = new JT809Serializer(jT808Config);
                jT809SerializerDict.TryAdd(jT808Config.ConfigId, serializer);
            }
            return serializer;
        }
    }
}
