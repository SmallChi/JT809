using JT809.Protocol.Configs;
using System.Collections.Generic;


namespace JT809.Protocol.ProtocolPacket.Extensions
{
    /// <summary>
    /// 包扩展方法
    /// </summary>
    public static class PackageExtensions
    {
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
        internal static ushort CRC16_CCITT(this Package packege, byte[] ucbuf, int offset, int iLen)
        {
            ushort crc = 0xFFFF;
            ushort polynomial = 0x1021;
            for (int j = 0; j < iLen; ++j)
            {
                for (int i = 0; i < 8; i++)
                {
                    bool bit = ((ucbuf[j + offset] >> (7 - i) & 1) == 1);
                    bool c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit) crc ^= polynomial;
                }
            }
            crc &= 0xffff;
            return crc;
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
