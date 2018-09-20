using JT809.Protocol.JT809Enums;
using JT809.Protocol.JT809Exceptions;
using JT809.Protocol.JT809Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public static class JT809Serializer
    {
        public static byte[] Serialize(JT809Package jT809Package)
        {
            var formatter = JT809FormatterExtensions.GetFormatter<JT809Package>();
            var pool = MemoryPool<byte>.Shared;
            IMemoryOwner<byte> buffer = pool.Rent(4096);
            try
            {
                var len = formatter.Serialize(buffer, 0, jT809Package);
                return buffer.Memory.Slice(0, len).ToArray();
            }
            finally
            {
                // 源码：System.Memory.MemoryPool 
                // private static readonly MemoryPool<T> s_shared = new ArrayMemoryPool<T>();
                // 单例内存池 不需要手动释放资源
                buffer.Dispose();
            }
        }

        public static JT809Package Deserialize(ReadOnlySpan<byte> bytes)
        {
            var formatter = JT809FormatterExtensions.GetFormatter<JT809Package>();
            return formatter.Deserialize(bytes, out int readSize);
        }

        public static byte[] Serialize<T>(T obj)
        {
            var formatter = JT809FormatterExtensions.GetFormatter<T>();
            var pool = MemoryPool<byte>.Shared;
            IMemoryOwner<byte> buffer = pool.Rent(10240);
            try
            {
                var len = formatter.Serialize(buffer, 0, obj);
                return buffer.Memory.Slice(0, len).ToArray();
            }
            finally
            {
                // 源码：System.Memory.MemoryPool 
                // private static readonly MemoryPool<T> s_shared = new ArrayMemoryPool<T>();
                // 单例内存池 不需要手动释放资源
                buffer.Dispose();
            }
        }

        public static T Deserialize<T>(ReadOnlySpan<byte> bytes)
        {
            var formatter = JT809FormatterExtensions.GetFormatter<T>();
            int readSize;
            return formatter.Deserialize(bytes, out readSize);
        }
    }
}
