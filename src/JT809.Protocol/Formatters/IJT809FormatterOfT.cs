using System;
using System.Buffers;

namespace JT809.Protocol.Formatters
{
    public interface IJT809Formatter<T>: IJT809Formatter
    {
        T Deserialize(ReadOnlySpan<byte> bytes, out int readSize);

        int Serialize(ref byte[] bytes, int offset, T value);
    }

    public interface IJT809Formatter
    {

    }
}
