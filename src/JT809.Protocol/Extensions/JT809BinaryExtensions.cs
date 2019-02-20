using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Buffers.Binary;
using System.Buffers;

namespace JT809.Protocol.Extensions
{
    public static  partial class JT809BinaryExtensions
    {
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

        public static byte[] ReadBytesLittle(ReadOnlySpan<byte> read, ref int offset)
        {
            ReadOnlySpan<byte> temp = read.Slice(offset);
            offset = offset + temp.Length;
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

        public static int WriteInt32Little(byte[] bytes, int offset, int data)
        {
            bytes[offset] = (byte)(data >> 24);
            bytes[offset + 1] = (byte)(data >> 16);
            bytes[offset + 2] = (byte)(data >> 8);
            bytes[offset + 3] = (byte)data;
            return 4;
        }

        public static int WriteUInt32Little(byte[] bytes, int offset, uint data)
        {
            bytes[offset] = (byte)(data >> 24);
            bytes[offset + 1] = (byte)(data >> 16);
            bytes[offset + 2] = (byte)(data >> 8);
            bytes[offset + 3] = (byte)data;
            return 4;
        }

        public static int WriteUInt64Little(byte[] bytes, int offset, ulong data)
        {
            bytes[offset] = (byte)(data >> 56);
            bytes[offset + 1] = (byte)(data >> 48);
            bytes[offset + 2] = (byte)(data >> 40);
            bytes[offset + 3] = (byte)(data >> 32);
            bytes[offset + 4] = (byte)(data >> 24);
            bytes[offset + 5] = (byte)(data >> 16);
            bytes[offset + 6] = (byte)(data >> 8);
            bytes[offset + 7] = (byte)data;
            return 8;
        }

        public static int WriteUInt16Little(byte[] bytes, int offset, ushort data)
        {
            bytes[offset] = (byte)(data >> 8);
            bytes[offset + 1] = (byte)data;
            return 2;
        }

        public static int WriteByteLittle(byte[] bytes, int offset, byte data)
        {
            bytes[offset] = data;
            return 1;
        }

        public static int WriteBytesLittle(byte[] bytes, int offset, byte[] data)
        {
            Array.Copy(data, 0, bytes, offset, data.Length);
            return data.Length;
        }

        /// <summary>
        /// 数字编码 大端模式、高位在前
        /// </summary>
        /// <param name="memoryOwner"></param>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int WriteBigNumberLittle(byte[] bytes, int offset, string data, int len)
        {
            ulong number = string.IsNullOrEmpty(data) ? 0 : (ulong)double.Parse(data);
            for (int i = len - 1; i >= 0; i--)
            {
                bytes[offset+i] = (byte)(number & 0xFF);  //取低8位
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
        public static int WriteLowNumberLittle(byte[] bytes, int offset, string data, int len)
        {
            ulong number = string.IsNullOrEmpty(data) ? 0 : (ulong)double.Parse(data);
            for (int i = 0; i < len; i++)
            {
                bytes[offset + i] = (byte)(number & 0xFF); //取低8位
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
            return ToBytes(data, JT809GlobalConfig.Instance.Encoding);
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
    }
}
