using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// 协议版本号标识
    /// BCD编码
    /// </summary>
    public class JT809Header_Version
    {
        public byte[] Buffer { get;} = new byte[3];
        private const int MajorIndex = 0;
        private const int MinorIndex = 1;
        private const int BuildIndex = 2;
        public const int FixedByteLength = 3;

        public byte Major
        {
            get { return Buffer[MajorIndex]; }
            set { Buffer[MajorIndex] = value; }
        }

        public byte Minor
        {
            get { return Buffer[MinorIndex]; }
            set { Buffer[MinorIndex] = value; }
        }

        public byte Build
        {
            get { return Buffer[BuildIndex]; }
            set { Buffer[BuildIndex] = value; }
        }

        /// <summary>
        /// 默认1.0.0版本
        /// </summary>
        public JT809Header_Version()
        {
            Major = 1;
            Minor = 0;
            Build = 0;
        }

        public JT809Header_Version(byte major, byte minor, byte buid)
        {
            Major = major;
            Minor = minor;
            Build = buid;
        }

        public JT809Header_Version(byte[] bytes)
        {
            Major = bytes[0];
            Minor = bytes[1];
            Build = bytes[2];
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Build}";
        }
    }
}
