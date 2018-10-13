using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace JT809.Protocol.JT809Extensions
{
    public static partial class JT809BinaryExtensions
    {
        public static string ReadBCDLittle(ReadOnlySpan<byte> buf, ref int offset, int len)
        {
            StringBuilder bcdSb = new StringBuilder(len*2);
            for(int i = 0; i < len; i++)
            {
                bcdSb.Append(buf[offset + i].ToString("X2"));
            }
            offset = offset + len;
            return bcdSb.ToString();
        }

        public static int WriteBCDLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int digit, int len)
        {
            ReadOnlySpan<char> bcd = data.PadLeft(len, '0').AsSpan();
            for (int i = 0; i < digit; i++)
            {
                memoryOwner.Memory.Span[offset + i] = Convert.ToByte(bcd.Slice(i * 2, 2).ToString(), 16);
            }
            return digit;
        }
    }
}
