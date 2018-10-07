using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Buffers.Binary;
using System.Buffers;

namespace JT809.Protocol.JT809Extensions
{
    public static  partial class JT809BinaryExtensions
    {
        public static string ReadStringLittle(ReadOnlySpan<byte> read, ref int offset, int len)
        {
            string value = encoding.GetString(read.Slice(offset, len).ToArray());
            offset += len;
            return value.Trim('\0');
        }

        public static string ReadStringLittle(ReadOnlySpan<byte> read, ref int offset)
        {
            string value = encoding.GetString(read.Slice(offset).ToArray());
            offset += value.Length;
            return value.Trim('\0');
        }

        public static int WriteStringLittle(IMemoryOwner<byte> memoryOwner, int offset, string data)
        {
            byte[] codeBytes = encoding.GetBytes(data);
            CopyTo(codeBytes, memoryOwner.Memory.Span, offset);
            return codeBytes.Length;
        }

        public static int WriteStringLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int len)
        {
            byte[] bytes = null;
            if (string.IsNullOrEmpty(data))
            {
                bytes = new byte[0];
            }
            else
            {
                bytes = encoding.GetBytes(data);
            }
            byte[] rBytes = new byte[len];
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i >= len) break;
                rBytes[i] = bytes[i];
            }
            CopyTo(rBytes, memoryOwner.Memory.Span, offset);
            return rBytes.Length;
        }

        public static int WriteStringPadLeftLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int len)
        {
            data = data.PadLeft(len, '\0');
            byte[] codeBytes = encoding.GetBytes(data);
            CopyTo(codeBytes, memoryOwner.Memory.Span, offset);
            return codeBytes.Length;
        }

        public static int WriteStringPadRightLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int len)
        {
            data = data.PadRight(len, '\0');
            byte[] codeBytes = encoding.GetBytes(data);
            CopyTo(codeBytes, memoryOwner.Memory.Span, offset);
            return codeBytes.Length;
        }
    }
}
