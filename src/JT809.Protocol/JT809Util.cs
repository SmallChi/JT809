using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    internal static class HexUtil
    {
        static readonly char[] HexdumpTable = new char[256 * 4];
        static HexUtil()
        {
            char[] digits = "0123456789ABCDEF".ToCharArray();
            for (int i = 0; i < 256; i++)
            {
                HexdumpTable[i << 1] = digits[(int)((uint)i >> 4 & 0x0F)];
                HexdumpTable[(i << 1) + 1] = digits[i & 0x0F];
            }
        }

        public static string DoHexDump(ReadOnlySpan<byte> buffer, int fromIndex, int length)
        {
            if (length == 0)
            {
                return "";
            }
            int endIndex = fromIndex + length;
            var buf = new char[length << 1];
            int srcIdx = fromIndex;
            int dstIdx = 0;
            for (; srcIdx < endIndex; srcIdx++, dstIdx += 2)
            {
                Array.Copy(HexdumpTable, buffer[srcIdx] << 1, buf, dstIdx, 2);
            }
            return new string(buf);
        }

        public static string DoHexDump(byte[] array, int fromIndex, int length)
        {
            if (length == 0)
            {
                return "";
            }
            int endIndex = fromIndex + length;
            var buf = new char[length << 1];
            int srcIdx = fromIndex;
            int dstIdx = 0;
            for (; srcIdx < endIndex; srcIdx++, dstIdx += 2)
            {
                Array.Copy(HexdumpTable, (array[srcIdx] & 0xFF) << 1, buf, dstIdx, 2);
            }
            return new string(buf);
        }
    }

    public static class CRCUtil
    {
        public static ulong[] CRC;  //建立CRC16表 
        private const ushort cnCRC_CCITT = 0x1021; //CRC校验多项式
        static CRCUtil()
        {
            InitCrcTable();
        }
        private static void InitCrcTable()
        {
            CRC = new ulong[256];
            ushort i, j;
            ushort nData;
            ushort nAccum;
            for (i = 0; i < 256; i++)
            {
                nData = (ushort)(i << 8);
                nAccum = 0;
                for (j = 0; j < 8; j++)
                {
                    if (((nData ^ nAccum) & 0x8000) > 0)
                        nAccum = (ushort)((nAccum << 1) ^ cnCRC_CCITT);
                    else
                        nAccum <<= 1;
                    nData <<= 1;
                }
                CRC[i] = (ulong)nAccum;
            }
        }
    }
}
