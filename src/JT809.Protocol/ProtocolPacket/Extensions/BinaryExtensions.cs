using System;
using System.IO;
using System.Linq;

namespace JT809.Protocol.ProtocolPacket
{
    public static class BinaryExtensions
    {
        public static void WriteLittle(this BinaryWriter writer, ulong value)
        {
            writer.Write((byte)(value >> 56));
            writer.Write((byte)(value >> 48));
            writer.Write((byte)(value >> 40));
            writer.Write((byte)(value >> 32));
            writer.Write((byte)(value >> 24));
            writer.Write((byte)(value >> 16));
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value));
        }

        public static void WriteLittle(this BinaryWriter writer, uint value)
        {
            writer.Write((byte)(value >> 24));
            writer.Write((byte)(value >> 16));
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value));
        }

        public static void WriteLittle(this BinaryWriter writer, int value)
        {
            writer.Write((byte)(value >> 24));
            writer.Write((byte)(value >> 16));
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value));
        }

        public static void WriteLittle(this BinaryWriter writer, short value)
        {
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value));
        }

        public static void WriteLittle(this BinaryWriter writer, ushort value)
        {
            writer.Write((byte)(value >> 8));
            writer.Write((byte)(value));
        }

        public static void WriteLittle(this BinaryWriter writer, byte value)
        {
            writer.Write(value);
        }

        public static void WriteLittle(this BinaryWriter writer, byte[] value)
        {
            writer.Write(value);
        }

        public static ulong ReadUInt64Little(this BinaryReader read)
        {
            var buffer = read.ReadBytes(8);
            return (ulong)(buffer[7] | buffer[6] << 8 | buffer[5] << 16 | buffer[4] << 24| buffer[3] << 32 | buffer[2] << 40 | buffer[1] << 48 | buffer[0] << 56);
        }

        public static uint ReadUInt32Little(this BinaryReader read)
        {
            var buffer = read.ReadBytes(4);
            return (uint)(buffer[3] | buffer[2] << 8 | buffer[1] << 16 | buffer[0] << 24);
        }

        public static ushort ReadUInt16Little(this BinaryReader read)
        {
            var buffer = read.ReadBytes(2);
            return (ushort)(buffer[1] | buffer[0] << 8);
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="separator">默认 " "</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes,string  separator=" ")
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
    }
}
