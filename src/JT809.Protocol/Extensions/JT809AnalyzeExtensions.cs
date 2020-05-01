using JT809.Protocol;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT809.Protocol.Extensions
{
    public static class JT809AnalyzeExtensions
    {
        public static void Analyze(this object instance, ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config)
        {
            if(instance is IJT809Analyze analyze)
            {
                analyze.Analyze(ref reader, writer, config);
            }
            else
            {
                throw new NotImplementedException($"Not Implemented {instance.GetType().FullName} {nameof(IJT809Analyze)}");
            }
        }
    }
}
