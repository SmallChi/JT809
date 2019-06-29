using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;

namespace JT809.Protocol.Formatters
{
    [Obsolete("请使用 IJT809MessagePackFormatter<T>")]
    public interface IJT809Formatter<T>: IJT809Formatter
    {
        T Deserialize(ReadOnlySpan<byte> bytes, out int readSize);

        int Serialize(ref byte[] bytes, int offset, T value);
    }
}
