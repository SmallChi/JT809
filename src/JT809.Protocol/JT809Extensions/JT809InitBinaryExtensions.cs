using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Extensions
{
    public static partial class JT809BinaryExtensions
    {
        public static Encoding encoding;

        private const ushort cnCRC_CCITT = 0x1021; //CRC校验多项式

        private static ulong[] CRC = new ulong[256]; //建立CRC16表 

        static JT809BinaryExtensions()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            encoding = Encoding.GetEncoding("GBK");
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
