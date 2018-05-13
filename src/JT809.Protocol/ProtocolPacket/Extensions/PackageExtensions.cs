using JT809.Protocol.Configs;
using System.Collections.Generic;


namespace JT809.Protocol.ProtocolPacket.Extensions
{
    /// <summary>
    /// 包扩展方法
    /// </summary>
    public static class PackageExtensions
    {
        const ushort cnCRC_CCITT = 0x1021; //CRC校验多项式
        static ulong[] CRC = new ulong[256]; //建立CRC16表 
        static PackageExtensions()
        {
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
        internal static byte[] Escape(this Package packege, byte[] bytes)
        {
            List<byte> dataList = new List<byte>();
            dataList.Add(bytes[0]);
            for (int i = 1; i < bytes.Length - 1; i++)
            {
                var item = bytes[i];
                switch (item)
                {
                    case 0x5b:
                        dataList.Add(0x5a);
                        dataList.Add(0x01);
                        break;
                    case 0x5a:
                        dataList.Add(0x5a);
                        dataList.Add(0x02);
                        break;
                    case 0x5d:
                        dataList.Add(0x5e);
                        dataList.Add(0x01);
                        break;
                    case 0x5e:
                        dataList.Add(0x5e);
                        dataList.Add(0x02);
                        break;
                    default:
                        dataList.Add(item);
                        break;
                }
            }
            dataList.Add(bytes[bytes.Length - 1]);
            var tempBuffe = dataList.ToArray();
            return tempBuffe;
        }
        internal static byte[] UnEscape(this Package packege, byte[] bytes)
        {
            List<byte> dataList = new List<byte>();
            dataList.Add(bytes[0]);
            for (int i = 1; i < bytes.Length - 1; i++)
            {
                byte first = bytes[i];
                byte second = bytes[i + 1];
                if (first == 0x5a && second == 0x01)
                {
                    dataList.Add(0x5b);
                    i++;
                }
                else if (first == 0x5a && second == 0x02)
                {
                    dataList.Add(0x5a);
                    i++;
                }
                else if (first == 0x5e && second == 0x01)
                {
                    dataList.Add(0x5d);
                    i++;
                }
                else if (first == 0x5e && second == 0x02)
                {
                    dataList.Add(0x5e);
                    i++;
                }
                else
                {
                    dataList.Add(first);
                }
            }
            dataList.Add(bytes[bytes.Length - 1]);
            var tempBuffe = dataList.ToArray();
            return tempBuffe;
        }
        /// <summary>
        /// 从数据头到校验码前的 CRC 1 G-CCITT 的校验值，遵循人端排序方式的规定。
        /// </summary>
        /// <param name="packege"></param>
        /// <param name="ucbuf"></param>
        /// <param name="offset"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        internal static ushort CRC16_CCITT(this Package packege, byte[] ucbuf, int offset, int iLen)
        {
            ushort checkCode = 0xFFFF;
            for (int j = offset; j < iLen; ++j)
            {
                checkCode = (ushort)((checkCode << 8) ^ (ushort)CRC[(checkCode >> 8) ^ ucbuf[j]]);
            }
            return checkCode;
        }
        internal static byte[] Encrypt(this Package packege, byte[] buffer, int size, JT809EncryptConfig Config)
        {
            if (0 == Config.Key)
            {
                Config.Key = 1;
            }
            uint mkey = Config.M1;
            if (0 == mkey)
            {
                mkey = 1;
            }
            for (int idx = 0; idx < size; idx++)
            {
                Config.Key = Config.IA1 * (Config.Key % mkey) + Config.IC1;
                buffer[idx] ^= (byte)((Config.Key >> 20) & 0xFF);
            }
            return buffer;
        }
    }
}
