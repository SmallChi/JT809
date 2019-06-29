using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    internal static class JT809ArrayPool
    {
        private readonly static ArrayPool<byte> ArrayPool;

        static JT809ArrayPool()
        {
            ArrayPool = ArrayPool<byte>.Create();
        }

        public static byte[] Rent(int minimumLength)
        {
            return ArrayPool.Rent(minimumLength);
        }

        public static void Return(byte[] array, bool clearArray = false)
        {
             ArrayPool.Return(array, clearArray);
        }
    }
}
