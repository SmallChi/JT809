using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    [JT809Formatter(typeof(JT809PackageFormatter))]
    public class JT809Package
    {
        public const byte BEGINFLAG = 0X5B;

        public const byte ENDFLAG = 0X5D;

        /// <summary>
        /// 固定为26个字节长度
        /// <para>Head flag + Message Header + CRC Code + End Flag</para>
        /// <para>1 + 22 + 2 + 1 = 26</para>
        /// </summary>
        public const int FixedByteLength = 26;

        public byte BeginFlag { get; set; } = BEGINFLAG;

        public JT809Header Header { get; set; }

        public JT809Bodies Bodies { get; set; }

        public ushort CRCCode { get; set; }

        public byte EndFlag { get; set; } = ENDFLAG;
    }
}
