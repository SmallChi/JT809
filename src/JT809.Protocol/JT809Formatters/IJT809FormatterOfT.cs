using System;
using System.Buffers;

namespace JT809.Protocol.JT809Formatters
{
    public interface IJT809Formatter<T>
    {
        T Deserialize(ReadOnlySpan<byte> bytes, out int readSize);

        int Serialize(IMemoryOwner<byte> memoryOwner, int offset, T value);
    }
}
