using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Formatters
{
    public interface IJT809MessagePackFormatter<T> : IJT809Formatter
    {
        void Serialize(ref JT809MessagePackWriter writer, T value, IJT809Config config);
        T Deserialize(ref JT809MessagePackReader reader, IJT809Config config);
    }

    public interface IJT809Formatter
    {

    }
}
