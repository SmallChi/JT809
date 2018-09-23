using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Buffers.Binary;
using System.Buffers;

namespace JT809.Protocol.JT809Extensions
{
    public static class JT809BinaryExtensions
    {
        /// <summary>
        /// 日期限制于2000年
        /// </summary>
        private const int DateLimitYear = 2000;

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

        private static Encoding encoding;

        public static int ReadBCD32(this byte data, byte dig)
        {
            int result = Convert.ToInt32(data.ToString("X"));
            return result * (int)Math.Pow(100, dig - 1);
        }

        public static int ReadBCD32(ReadOnlySpan<byte> read, ref int offset, int len)
        {
            int result = Convert.ToInt32(read[offset].ToString("X"));
            offset += len;
            return result * (int)Math.Pow(100, len - 1);
        }


        public static long ReadBCD64(this byte data, byte dig)
        {
            long result = Convert.ToInt64(data.ToString("X"));
            return result * (long)Math.Pow(100, dig - 1);
        }

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

        public static long ReadBCD(ReadOnlySpan<byte> buf, ref int offset, int len)
        {
            long result = 0;
            try
            {
                for (int i = offset; i < offset + len; i++)
                {
                    result += buf[i].ReadBCD64((byte)(offset + len - i));
                }
            }
            catch
            {
            }
            offset = offset + len;
            return result;
        }

        public static DateTime ReadDateTimeLittle(ReadOnlySpan<byte> buf, ref int offset)
        {
            DateTime dateTime = new DateTime(
                (buf[offset]).ReadBCD32(1) + DateLimitYear,
                (buf[offset + 1]).ReadBCD32(1),
                (buf[offset + 2]).ReadBCD32(1),
                (buf[offset + 3]).ReadBCD32(1),
                (buf[offset + 4]).ReadBCD32(1),
                (buf[offset + 5]).ReadBCD32(1));
            offset = offset + 6;
            return dateTime;
        }

        public static DateTime ReadDateLittle(ReadOnlySpan<byte> buf, ref int offset)
        {
            DateTime dateTime = new DateTime(
                    ((buf[offset] << 8) | (buf[offset + 1])),
                    (buf[offset + 2]).ReadBCD32(1),
                    (buf[offset + 3]).ReadBCD32(1));
            offset = offset + 4;
            return dateTime;
        }

        public static int ReadInt32Little(ReadOnlySpan<byte> read, ref int offset)
        {
            int value = (read[offset] << 24) | (read[offset + 1] << 16) | (read[offset + 2] << 8) | read[offset + 3];
            offset = offset + 4;
            return value;
        }

        public static uint ReadUInt32Little(ReadOnlySpan<byte> read, ref int offset)
        {
            uint value = (uint)((read[offset] << 24) | (read[offset + 1] << 16) | (read[offset + 2] << 8) | read[offset + 3]);
            offset = offset + 4;
            return value;
        }

        public static ulong ReadUInt64Little(ReadOnlySpan<byte> read, ref int offset)
        {
            ulong value = (ulong)(
                (read[offset] << 56) |
                (read[offset + 1] << 48) |
                (read[offset + 2] << 40) |
                (read[offset + 3] << 32) |
                (read[offset + 4] << 24) |
                (read[offset + 5] << 16) |
                (read[offset + 6] << 8) |
                 read[offset + 7]);
            offset = offset + 8;
            return value;
        }

        public static ushort ReadUInt16Little(ReadOnlySpan<byte> read, ref int offset)
        {
            ushort value = (ushort)((read[offset] << 8) | (read[offset + 1]));
            offset = offset + 2;
            return value;
        }

        public static byte ReadByteLittle(ReadOnlySpan<byte> read, ref int offset)
        {
            byte value = read[offset];
            offset = offset + 1;
            return value;
        }

        public static byte[] ReadBytesLittle(ReadOnlySpan<byte> read, ref int offset, int len)
        {
            ReadOnlySpan<byte> temp = read.Slice(offset, len);
            offset = offset + len;
            return temp.ToArray();
        }

        /// <summary>
        /// 数字编码 大端模式、高位在前
        /// </summary>
        /// <param name="read"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ReadBigNumberLittle(ReadOnlySpan<byte> read, ref int offset, int len)
        {
            ulong result = 0;
            for (int i = 0; i < len; i++)
            {
                ulong currentData = (ulong)read[offset+i] << (8 * (len - i - 1));
                result += currentData;
            }
            offset += len;
            return result.ToString();
        }

        /// <summary>
        /// 数字编码 小端模式、低位在前
        /// </summary>
        /// <param name="read"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ReadLowNumberLittle(ReadOnlySpan<byte> read, ref int offset, int len)
        {
            ulong result = 0;
            for (int i = 0; i < len; i++)
            {
                ulong currentData = (ulong)read[offset+i] << (8 * i);
                result += currentData;
            }
            offset += len;
            return result.ToString();
        }

        public static int WriteDateTime6Little(IMemoryOwner<byte> memoryOwner, int offset, DateTime date)
        {
            memoryOwner.Memory.Span[offset] = ((byte)(date.Year - DateLimitYear)).ToBcdByte();
            memoryOwner.Memory.Span[offset + 1] = ((byte)(date.Month)).ToBcdByte();
            memoryOwner.Memory.Span[offset + 2] = ((byte)(date.Day)).ToBcdByte();
            memoryOwner.Memory.Span[offset + 3] = ((byte)(date.Hour)).ToBcdByte();
            memoryOwner.Memory.Span[offset + 4] = ((byte)(date.Minute)).ToBcdByte();
            memoryOwner.Memory.Span[offset + 5] = ((byte)(date.Second)).ToBcdByte();
            return 6;
        }

        public static int WriteDateTime4Little(IMemoryOwner<byte> memoryOwner, int offset, DateTime date)
        {
            memoryOwner.Memory.Span[offset] = (byte)(date.Year >> 8);
            memoryOwner.Memory.Span[offset + 1] = (byte)date.Year;
            memoryOwner.Memory.Span[offset + 2] = ((byte)(date.Month)).ToBcdByte();
            memoryOwner.Memory.Span[offset + 3] = ((byte)(date.Day)).ToBcdByte();
            return 4;
        }

        public static int WriteInt32Little(IMemoryOwner<byte> memoryOwner, int offset, int data)
        {
            memoryOwner.Memory.Span[offset] = (byte)(data >> 24);
            memoryOwner.Memory.Span[offset + 1] = (byte)(data >> 16);
            memoryOwner.Memory.Span[offset + 2] = (byte)(data >> 8);
            memoryOwner.Memory.Span[offset + 3] = (byte)data;
            return 4;
        }

        public static int WriteUInt32Little(IMemoryOwner<byte> memoryOwner, int offset, uint data)
        {
            memoryOwner.Memory.Span[offset] = (byte)(data >> 24);
            memoryOwner.Memory.Span[offset + 1] = (byte)(data >> 16);
            memoryOwner.Memory.Span[offset + 2] = (byte)(data >> 8);
            memoryOwner.Memory.Span[offset + 3] = (byte)data;
            return 4;
        }

        public static int WriteUInt64Little(IMemoryOwner<byte> memoryOwner, int offset, ulong data)
        {
            memoryOwner.Memory.Span[offset] = (byte)(data >> 56);
            memoryOwner.Memory.Span[offset + 1] = (byte)(data >> 48);
            memoryOwner.Memory.Span[offset + 2] = (byte)(data >> 40);
            memoryOwner.Memory.Span[offset + 3] = (byte)(data >> 32);
            memoryOwner.Memory.Span[offset + 4] = (byte)(data >> 24);
            memoryOwner.Memory.Span[offset + 5] = (byte)(data >> 16);
            memoryOwner.Memory.Span[offset + 6] = (byte)(data >> 8);
            memoryOwner.Memory.Span[offset + 7] = (byte)data;
            return 8;
        }

        public static int WriteUInt16Little(IMemoryOwner<byte> memoryOwner, int offset, ushort data)
        {
            memoryOwner.Memory.Span[offset] = (byte)(data >> 8);
            memoryOwner.Memory.Span[offset + 1] = (byte)data;
            return 2;
        }

        public static int WriteByteLittle(IMemoryOwner<byte> memoryOwner, int offset, byte data)
        {
            memoryOwner.Memory.Span[offset] = data;
            return 1;
        }

        public static int WriteBytesLittle(IMemoryOwner<byte> memoryOwner, int offset, byte[] data)
        {
            CopyTo(data, memoryOwner.Memory.Span, offset);
            return data.Length;
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

        public static int WriteBCDLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int digit, int len)
        {
            ReadOnlySpan<char> bcd = data.PadLeft(len, '0').AsSpan();
            for (int i = 0; i < digit; i++)
            {
                memoryOwner.Memory.Span[offset + i] = Convert.ToByte(bcd.Slice(i * 2, 2).ToString(), 16);
            }
            return digit;
        }

        /// <summary>
        /// 数字编码 大端模式、高位在前
        /// </summary>
        /// <param name="memoryOwner"></param>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int WriteBigNumberLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int len)
        {
            ulong number = string.IsNullOrEmpty(data) ? 0 : (ulong)double.Parse(data);
            for (int i = len - 1; i >= 0; i--)
            {
                memoryOwner.Memory.Span[offset+i] = (byte)(number & 0xFF);  //取低8位
                number = number >> 8;
            }
            return len;
        }

        /// <summary>
        /// 数字编码 小端模式、低位在前
        /// </summary>
        /// <param name="memoryOwner"></param>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int WriteLowNumberLittle(IMemoryOwner<byte> memoryOwner, int offset, string data, int len)
        {
            ulong number = string.IsNullOrEmpty(data) ? 0 : (ulong)double.Parse(data);
            for (int i = 0; i < len; i++)
            {
                memoryOwner.Memory.Span[offset + i] = (byte)(number & 0xFF); //取低8位
                number = number >> 8;
            }
            return len;
        }

        public static IEnumerable<byte> ToBytes(this string data, Encoding coding)
        {
            return coding.GetBytes(data);
        }

        public static IEnumerable<byte> ToBytes(this string data)
        {
            return ToBytes(data, encoding);
        }

        public static IEnumerable<byte> ToBytes(this int data, int len)
        {
            List<byte> bytes = new List<byte>();
            int n = 1;
            for (int i = 0; i < len; i++)
            {
                bytes.Add((byte)(data >> 8 * (len - n)));
                n++;
            }
            return bytes;
        }

        /// <summary>
        /// 从数据头到校验码前的 CRC 1 G-CCITT 的校验值，遵循人端排序方式的规定。
        /// </summary>
        /// <param name="packege"></param>
        /// <param name="ucbuf"></param>
        /// <param name="offset"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public static ushort ToCRC16_CCITT(this Span<byte> ucbuf, int offset, int iLen)
        {
            ushort checkCode = 0xFFFF;
            for (int j = offset; j < iLen; ++j)
            {
                checkCode = (ushort)((checkCode << 8) ^ (ushort)CRC[(checkCode >> 8) ^ ucbuf[j]]);
            }
            return checkCode;
        }

        /// <summary>
        /// 从数据头到校验码前的 CRC 1 G-CCITT 的校验值，遵循人端排序方式的规定。
        /// </summary>
        /// <param name="packege"></param>
        /// <param name="ucbuf"></param>
        /// <param name="offset"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public static ushort ToCRC16_CCITT(this ReadOnlySpan<byte> ucbuf, int offset, int iLen)
        {
            ushort checkCode = 0xFFFF;
            for (int j = offset; j < iLen; ++j)
            {
                checkCode = (ushort)((checkCode << 8) ^ (ushort)CRC[(checkCode >> 8) ^ ucbuf[j]]);
            }
            return checkCode;
        }

        public static byte ToBcdByte(this byte buf)
        {
            return (byte)Convert.ToInt32(buf.ToString(), 16);
        }

        /// <summary>
        /// 经纬度
        /// </summary>
        /// <param name="latlng"></param>
        /// <returns></returns>
        public static double ToLatLng(this int latlng)
        {
            return Math.Round(latlng / Math.Pow(10, 6), 6);
        }

        public static void CopyTo(Span<byte> source, Span<byte> destination, int offset)
        {
            for (int i = 0; i < source.Length; i++)
            {
                destination[offset + i] = source[i];
            }
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="separator">默认 " "</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes, string separator = " ")
        {
            return string.Join(separator, bytes.Select(s => s.ToString("X2")));
        }

        /// <summary>
        /// 16进制字符串转16进制数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static byte[] ToHexBytes(this string hexString, string separator = " ")
        {
            return hexString.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToByte(s, 16)).ToArray();
        }

        /// <summary>
        /// 16进制字符串转16进制数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] ToStr2HexBytes(this string hexString)
        {
            //byte[] buf = new byte[hexString.Length / 2];
            //for (int i = 0; i < hexString.Length; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        buf[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16) ;
            //    }

            //}
            byte[] buf = new byte[hexString.Length / 2];
            ReadOnlySpan<char> readOnlySpan = hexString.AsSpan();
            for (int i = 0; i < hexString.Length; i++)
            {
                if (i % 2 == 0)
                {
                    buf[i / 2] = Convert.ToByte(readOnlySpan.Slice(i, 2).ToString(), 16);
                }
            }
            return buf;
            //List<byte> bytes = new List<byte>();
            //while (hexString.Length>0)
            //{
            //    bytes.Add(Convert.ToByte(hexString.AsSpan(0, 2).ToString(), 16));
            //    hexString = hexString.Remove(0,2);
            //}
            //return Regex.Replace(hexString, @"(\w{2})", "$1 ").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToByte(s, 16)).ToArray();
        }
    }
}
