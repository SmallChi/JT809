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

        public static int WriteBCDLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int len)
        {
            string bcdText = data == null ? "" : data;
            byte[] bytes = new byte[len];
            int startIndex = 0;
            int noOfZero = len * 2 - data.Length;
            if (noOfZero > 0)
            {
                bcdText = bcdText.Insert(startIndex, new string('0', noOfZero));
            }
            int byteIndex = 0;
            while (startIndex < bcdText.Length && byteIndex < len)
            {
                memoryOwner.Memory.Span[offset + byteIndex] = Convert.ToByte(bcdText.Substring(startIndex, 2), 16);
                startIndex += 2;
                byteIndex++;
            }
            return len;
        }
    }
}
