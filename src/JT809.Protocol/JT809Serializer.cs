using JT809.Protocol.JT809Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// 
    /// ref:https://adamsitnik.com/Array-Pool/
    /// </summary>
    public static class JT809Serializer
    {
        public static byte[] Serialize(JT809Package jT809Package, int minBufferSize = 1024)
        {
            return Serialize<JT809Package>(jT809Package, minBufferSize);
        }

        public static JT809Package Deserialize(ReadOnlySpan<byte> bytes)
        {
            return Deserialize<JT809Package>(bytes);
        }

        public static byte[] Serialize<T>(T obj, int minBufferSize = 1024)
        {
            var formatter = JT809FormatterExtensions.GetFormatter<T>();
            byte[] buffer = JT809ArrayPool.Rent(minBufferSize);
            try
            {
                var len = formatter.Serialize(ref buffer, 0, obj);
                return buffer.AsSpan(0, len).ToArray();
            }
            finally
            {
                JT809ArrayPool.Return(buffer);
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
