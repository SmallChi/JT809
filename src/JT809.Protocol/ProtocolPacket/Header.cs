using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// Message Header 数据头
    /// </summary>
    public class Header
    {
        public Version Version { get; private set; }
        public EncryptEnum EncryptEnum { get; private set; }
    }
}
