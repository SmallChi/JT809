using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public static class JT809Util
    {
        internal static ReadOnlySpan<byte> JT809DeEscape(ReadOnlySpan<byte> buffer)
        {
            byte[] tmpBuffer = JT809ArrayPool.Rent(buffer.Length - 1);
            try
            {
                int offset = 0;
                tmpBuffer[offset++] = buffer[0];
                for (int i = 1; i < buffer.Length - 1; i++)
                {
                    byte first = buffer[i];
                    byte second = buffer[i + 1];
                    if (first == 0x5a && second == 0x01)
                    {
                        tmpBuffer[offset++] = 0x5b;
                        i++;
                    }
                    else if (first == 0x5a && second == 0x02)
                    {
                        tmpBuffer[offset++] = 0x5a;
                        i++;
                    }
                    else if (first == 0x5e && second == 0x01)
                    {
                        tmpBuffer[offset++] = 0x5d;
                        i++;
                    }
                    else if (first == 0x5e && second == 0x02)
                    {
                        tmpBuffer[offset++] = 0x5e;
                        i++;
                    }
                    else
                    {
                        tmpBuffer[offset++] = first;
                    }
                }
                tmpBuffer[offset++] = buffer[buffer.Length - 1];
                return tmpBuffer.AsSpan(0, offset).ToArray();
            }
            finally
            {
                JT809ArrayPool.Return(tmpBuffer);
            }
        }

        internal static int JT809Escape(ref byte[] buffer, int offset)
        {
            byte[] tmpBuffer = buffer.AsSpan(0, offset).ToArray();
            int tmpOffset = 0;
            buffer[tmpOffset++] = tmpBuffer[0];
            for (int i = 1; i < offset - 1; i++)
            {
                var item = tmpBuffer[i];
                switch (item)
                {
                    case 0x5b:
                        buffer[tmpOffset++] = 0x5a;
                        buffer[tmpOffset++] = 0x01;
                        break;
                    case 0x5a:
                        buffer[tmpOffset++] = 0x5a;
                        buffer[tmpOffset++] = 0x02;
                        break;
                    case 0x5d:
                        buffer[tmpOffset++] = 0x5e;
                        buffer[tmpOffset++] = 0x01;
                        break;
                    case 0x5e:
                        buffer[tmpOffset++] = 0x5e;
                        buffer[tmpOffset++] = 0x02;
                        break;
                    default:
                        buffer[tmpOffset++] = item;
                        break;
                }
            }
            buffer[tmpOffset++] = tmpBuffer[tmpBuffer.Length - 1];
            return tmpOffset;
        }
    }
}
