using JT809.Protocol.Buffers;
using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("JT809.Protocol.Test")]

namespace JT809.Protocol.MessagePack
{
    public ref struct JT809MessagePackWriter
    {
        private JT809BufferWriter writer;
        public JT809MessagePackWriter(Span<byte> buffer)
        {
            this.writer = new JT809BufferWriter(buffer);
        }
        public byte[] FlushAndGetEncodingArray()
        {
            return writer.Written.Slice(writer.BeforeCodingWrittenPosition).ToArray();
        }
        public byte[] FlushAndGetRealArray()
        {
            return writer.Written.ToArray();
        }
        public void WriteStart()=> WriteByte(JT809Package.BEGINFLAG);
        public void WriteEnd() => WriteByte(JT809Package.ENDFLAG);
        public void Nil(out int position)
        {
            position = writer.WrittenCount;
            var span = writer.Free;
            span[0] = 0x00;
            writer.Advance(1);
        }
        public void Skip(int count, out int position)
        {
            position = writer.WrittenCount;
            var span = writer.Free;
            for (var i = 0; i < count; i++)
            {
                span[i] = 0x00;
            }
            writer.Advance(count);
        }
        public void Skip(int count,out int position, byte fullValue = 0x00)
        {
            position = writer.WrittenCount;
            var span = writer.Free;
            for (var i = 0; i < count; i++)
            {
                span[i] = fullValue;
            }
            writer.Advance(count);
        }
        public void WriteByte(byte value)
        {
            var span = writer.Free;
            span[0] = value;
            writer.Advance(1);
        }
        public void WriteUInt16(ushort value)
        {
            BinaryPrimitives.WriteUInt16BigEndian(writer.Free, value);
            writer.Advance(2);
        }
        public void WriteInt16(short value)
        {
            BinaryPrimitives.WriteInt16BigEndian(writer.Free, value);
            writer.Advance(2);
        }
        public void WriteInt32(int value)
        {
            BinaryPrimitives.WriteInt32BigEndian(writer.Free, value);
            writer.Advance(4);
        }
        public void WriteUInt32(uint value)
        {
            BinaryPrimitives.WriteUInt32BigEndian(writer.Free, value);
            writer.Advance(4);
        }
        public void WriteUInt64(ulong value)
        {
            BinaryPrimitives.WriteUInt64BigEndian(writer.Free, value);
            writer.Advance(8);
        }
        public void WriteInt64(long value)
        {
            BinaryPrimitives.WriteInt64BigEndian(writer.Free, value);
            writer.Advance(8);
        }
        public void WriteStringPadLeft(string value, int len)
        {
            Span<byte> codeBytes = JT809Constants.Encoding.GetBytes(value).AsSpan();
            var fillLength = codeBytes.Length - len;
            if (fillLength > 0)
            {
                codeBytes.Slice(0, len).CopyTo(writer.Free);
                writer.Advance(codeBytes.Length);
            }
            else if (fillLength < 0)
            {
                Skip(-fillLength, out _);
                codeBytes.CopyTo(writer.Free);
                writer.Advance(codeBytes.Length);
            }
            else
            {
                codeBytes.CopyTo(writer.Free);
                writer.Advance(codeBytes.Length);
            }
        }
        public void WriteStringPadRight(string value,int len)
        {
            Span<byte> codeBytes = JT809Constants.Encoding.GetBytes(value).AsSpan();
            var fillLength = codeBytes.Length - len;
            if (fillLength > 0)
            {
                codeBytes.Slice(0, len).CopyTo(writer.Free);
                writer.Advance(codeBytes.Length);
            }
            else if(fillLength < 0)
            {
                codeBytes.CopyTo(writer.Free);
                writer.Advance(codeBytes.Length);
                Skip(-fillLength, out _);
            }
            else
            {
                codeBytes.CopyTo(writer.Free);
                writer.Advance(codeBytes.Length);
            }
        }
        public void WriteString(string value)
        {
            byte[] codeBytes = JT809Constants.Encoding.GetBytes(value);
            codeBytes.CopyTo(writer.Free);
            writer.Advance(codeBytes.Length);
        }
        public void WriteArray(ReadOnlySpan<byte> src)
        {
            src.CopyTo(writer.Free);
            writer.Advance(src.Length);
        }
        public void WriteUInt16Return(ushort value, int position)
        {
            BinaryPrimitives.WriteUInt16BigEndian(writer.Written.Slice(position,2), value);
        }
        public void WriteInt16Return(short value, int position)
        {
            BinaryPrimitives.WriteInt16BigEndian(writer.Written.Slice(position, 2), value);
        }
        public void WriteInt32Return(int value, int position)
        {
            BinaryPrimitives.WriteInt32BigEndian(writer.Written.Slice(position, 4), value);
        }
        public void WriteUInt32Return(uint value, int position)
        {
            BinaryPrimitives.WriteUInt32BigEndian(writer.Written.Slice(position, 4), value);
        }
        public void WriteInt64Return(long value, int position)
        {
            BinaryPrimitives.WriteInt64BigEndian(writer.Written.Slice(position, 8), value);
        }
        public void WriteUInt64Return(ulong value, int position)
        {
            BinaryPrimitives.WriteUInt64BigEndian(writer.Written.Slice(position, 8), value);
        }
        public void WriteByteReturn(byte value, int position)
        {
            writer.Written[position] = value;
        }
        public void WriteBCDReturn(string value,int len, int position)
        {
            string bcdText = value ?? "";
            int startIndex = 0;
            int noOfZero = len - bcdText.Length;
            if (noOfZero > 0)
            {
                bcdText = bcdText.Insert(startIndex, new string('0', noOfZero));
            }
            int byteIndex = 0;
            int count = len / 2;
            var bcdSpan = bcdText.AsSpan();
            while (startIndex < bcdText.Length && byteIndex < count)
            {
                writer.Written[position+(byteIndex++)] = Convert.ToByte(bcdSpan.Slice(startIndex, 2).ToString(), 16);
                startIndex += 2;
            }
        }
        public void WriteStringReturn(string value, int position)
        {
            Span<byte> codeBytes = JT809Constants.Encoding.GetBytes(value);
            codeBytes.CopyTo(writer.Written.Slice(position));
        }
        public void WriteArrayReturn(ReadOnlySpan<byte> src, int position)
        {
            src.CopyTo(writer.Written.Slice(position));
        }
        /// <summary>
        /// yyMMddHHmmss
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromBase"></param>
        public void WriteDateTime6(DateTime value, int fromBase = 16)
        {
            var span = writer.Free;
            span[0] = Convert.ToByte(value.ToString("yy"), fromBase);
            span[1] = Convert.ToByte(value.ToString("MM"), fromBase);
            span[2] = Convert.ToByte(value.ToString("dd"), fromBase);
            span[3] = Convert.ToByte(value.ToString("HH"), fromBase);
            span[4] = Convert.ToByte(value.ToString("mm"), fromBase);
            span[5] = Convert.ToByte(value.ToString("ss"), fromBase);
            writer.Advance(6);
        }
        /// <summary>
        /// HH-mm-ss-msms
        /// HH-mm-ss-fff
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromBase"></param>
        public void WriteDateTime5(DateTime value, int fromBase = 16)
        {
            var span = writer.Free;
            span[0] = Convert.ToByte(value.ToString("HH"), fromBase);
            span[1] = Convert.ToByte(value.ToString("mm"), fromBase);
            span[2] = Convert.ToByte(value.ToString("ss"), fromBase);
            span[3] = (byte)(value.Millisecond >> 8);
            span[4] = (byte)(value.Millisecond);
            writer.Advance(5);
        }
        public void WriteUTCDateTime(DateTime value)=>WriteUInt64((ulong)(value.AddHours(-8) - JT809Constants.UTCBaseTime).TotalSeconds);
        /// <summary>
        /// YYYYMMDD
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromBase"></param>
        public void WriteDateTime4(DateTime value, int fromBase = 16)
        {
            var span = writer.Free;
            span[0] = (byte)(value.Year >> 8);
            span[1] = (byte)(value.Year);
            span[2] = Convert.ToByte(value.ToString("MM"), fromBase);
            span[3] = Convert.ToByte(value.ToString("dd"), fromBase);
            writer.Advance(4);
        }
        public void WriteCRC16(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentOutOfRangeException($"start>end:{start}>{end}");
            }
            var crcSpan = writer.Written.Slice(start, end);
            ushort crcCode = 0xFFFF;
            for (int i = 0; i < crcSpan.Length; i++)
            {
                crcCode = (ushort)((crcCode << 8) ^ (ushort)CRCUtil.CRC[(crcCode >> 8) ^ crcSpan[i]]);
            }
            WriteUInt16(crcCode);
        }
        public void WriteCRC16(int start)
        {
            if (writer.WrittenCount < start)
            {
                throw new ArgumentOutOfRangeException($"Written<start:{writer.WrittenCount}>{1}");
            }
            var crcSpan = writer.Written.Slice(start);
            ushort crcCode = 0xFFFF;
            for (int i = 0; i < crcSpan.Length; i++)
            {
                crcCode = (ushort)((crcCode << 8) ^ (ushort)CRCUtil.CRC[(crcCode >> 8) ^ crcSpan[i]]);
            }
            WriteUInt16(crcCode);
        }
        public void WriteCRC16()
        {
            if (writer.WrittenCount < 1)
            {
                throw new ArgumentOutOfRangeException($"Written<start:{writer.WrittenCount}>{1}");
            }
            //从第1位开始
            var crcSpan = writer.Written.Slice(1);
            ushort crcCode = 0xFFFF;
            for (int i = 0; i < crcSpan.Length; i++)
            {
                crcCode = (ushort)((crcCode << 8) ^ (ushort)CRCUtil.CRC[(crcCode >> 8) ^ crcSpan[i]]);
            }
            WriteUInt16(crcCode);
        }
        public void WriteBCD(string value, int len)
        {
            string bcdText = value ?? "";
            int startIndex = 0;
            int noOfZero = len - bcdText.Length;
            if (noOfZero > 0)
            {
                bcdText = bcdText.Insert(startIndex, new string('0', noOfZero));
            }
            int byteIndex = 0;
            int count = len / 2;
            var bcdSpan = bcdText.AsSpan();
            var spanFree = writer.Free;
            while (startIndex < bcdText.Length && byteIndex < count)
            {
                spanFree[byteIndex++] = Convert.ToByte(bcdSpan.Slice(startIndex, 2).ToString(), 16);
                startIndex += 2;
            }
            writer.Advance(byteIndex);
        }
        public void WriteHex(string value, int len)
        {
            value = value ?? "";
            value = value.Replace(" ", "");
            int startIndex = 0;
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                startIndex = 2;
            }
            int length = len;
            if (length == -1)
            {
                length = (value.Length - startIndex) / 2;
            }
            int noOfZero = length * 2 + startIndex - value.Length;
            if (noOfZero > 0)
            {
                value = value.Insert(startIndex, new string('0', noOfZero));
            }
            int byteIndex = 0;
            var hexSpan = value.AsSpan();
            var spanFree = writer.Free;
            while (startIndex < value.Length && byteIndex < length)
            {
                spanFree[byteIndex++] = Convert.ToByte(hexSpan.Slice(startIndex, 2).ToString(), 16);
                startIndex += 2;
            }
            writer.Advance(byteIndex);
        }
        public void WriteFullEncode()
        {
            var tmpSpan = writer.Written;
            writer.BeforeCodingWrittenPosition = writer.WrittenCount;
            var spanFree = writer.Free;
            int tmpOffset = 0;
            for (int i = 0; i < tmpSpan.Length; i++)
            {
                var item = tmpSpan[i];
                switch (item)
                {
                    case 0x5b:
                        spanFree[tmpOffset++] = 0x5a;
                        spanFree[tmpOffset++] = 0x01;
                        break;
                    case 0x5a:
                        spanFree[tmpOffset++] = 0x5a;
                        spanFree[tmpOffset++] = 0x02;
                        break;
                    case 0x5d:
                        spanFree[tmpOffset++] = 0x5e;
                        spanFree[tmpOffset++] = 0x01;
                        break;
                    case 0x5e:
                        spanFree[tmpOffset++] = 0x5e;
                        spanFree[tmpOffset++] = 0x02;
                        break;
                    default:
                        spanFree[tmpOffset++] = item;
                        break;
                }
            }
            writer.Advance(tmpOffset);
        }
        internal void WriteEncode()
        {
            var tmpSpan = writer.Written;
            writer.BeforeCodingWrittenPosition = writer.WrittenCount;
            var spanFree = writer.Free;
            int tmpOffset = 0;
            spanFree[tmpOffset++] = tmpSpan[0];
            for (int i = 1; i < tmpSpan.Length - 1; i++)
            {
                var item = tmpSpan[i];
                switch (item)
                {
                    case 0x5b:
                        spanFree[tmpOffset++] = 0x5a;
                        spanFree[tmpOffset++] = 0x01;
                        break;
                    case 0x5a:
                        spanFree[tmpOffset++] = 0x5a;
                        spanFree[tmpOffset++] = 0x02;
                        break;
                    case 0x5d:
                        spanFree[tmpOffset++] = 0x5e;
                        spanFree[tmpOffset++] = 0x01;
                        break;
                    case 0x5e:
                        spanFree[tmpOffset++] = 0x5e;
                        spanFree[tmpOffset++] = 0x02;
                        break;
                    default:
                        spanFree[tmpOffset++] = item;
                        break;
                }
            }
            spanFree[tmpOffset++] = tmpSpan[tmpSpan.Length - 1];
            writer.Advance(tmpOffset);
        }
        /// <summary>
        /// 数字编码 大端模式、高位在前
        /// </summary>
        /// <param name="value"></param>
        /// <param name="len"></param>
        public void WriteBigNumber(string value, int len)
        {
            var spanFree = writer.Free;
            ulong number = string.IsNullOrEmpty(value) ? 0 : (ulong)double.Parse(value);
            for (int i = len - 1; i >= 0; i--)
            {
                spanFree[i] = (byte)(number & 0xFF);  //取低8位
                number = number >> 8;
            }
            writer.Advance(len);
        }
        public ReadOnlySpan<byte> Extract(int start)
        {
            return writer.Written.Slice(start);
        }
        public void CopyTo(ReadOnlySpan<byte> buffer, int from)
        {
            buffer.CopyTo(writer.Written.Slice(from, buffer.Length));
        }
        public void Shrink(int length)
        {
            writer.Shrink(length);
        }
        public int GetCurrentPosition()
        {
            return writer.WrittenCount;
        }
    }
}
