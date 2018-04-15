using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// 数据包
    /// </summary>
    public class Package
    {
        public const int NotDataLength = 26;
        public const int CrcByteLength = 2;
        public const byte BeginFlag = 0X5B;
        public const byte EndFlag = 0X5D;
        public Header Header { get; private set; }
        private ushort CRCCheckCode { get; set; }
    }
}
