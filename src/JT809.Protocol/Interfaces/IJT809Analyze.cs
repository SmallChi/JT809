using JT809.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809Analyze
    {
        void Analyze(ref JT809MessagePackReader reader, Utf8JsonWriter writer, IJT809Config config);
    }
}
