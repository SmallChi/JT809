using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Extensions
{
    public static partial class JT809BinaryExtensions
    {
        /// <summary>
        /// 从数据头到校验码前的 CRC 1 G-CCITT 的校验值，遵循人端排序方式的规定。
        /// </summary>
        /// <param name="ucbuf"></param>
        /// <param name="offset"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public static ushort ToCRC16_CCITT(this byte[] ucbuf, int offset, int iLen)
        {
            ushort checkCode = 0xFFFF;
            for (int j = offset; j < iLen; ++j)
            {
                checkCode = (ushort)((checkCode << 8) ^ (ushort)JT809GlobalConfig.Instance.CRC[(checkCode >> 8) ^ ucbuf[j]]);
            }
            return checkCode;
        }

        /// <summary>
        /// 从数据头到校验码前的 CRC 1 G-CCITT 的校验值，遵循人端排序方式的规定。
        /// </summary>
        /// <param name="ucbuf"></param>
        /// <param name="offset"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public static ushort ToCRC16_CCITT(this ReadOnlySpan<byte> ucbuf, int offset, int iLen)
        {
            ushort checkCode = 0xFFFF;
            for (int j = offset; j < iLen; ++j)
            {
                checkCode = (ushort)((checkCode << 8) ^ (ushort)JT809GlobalConfig.Instance.CRC[(checkCode >> 8) ^ ucbuf[j]]);
            }
            return checkCode;
        }
    }
}
