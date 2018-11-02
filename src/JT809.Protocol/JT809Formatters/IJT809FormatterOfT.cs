using System;
using System.Buffers;

namespace JT809.Protocol.JT809Formatters
{
    public interface IJT809Formatter<T>
    {
        T Deserialize(ReadOnlySpan<byte> bytes, out int readSize);

        int Serialize(ref byte[] bytes, int offset, T value);
    }
}
