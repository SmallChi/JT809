using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// 抽象消息体 
    /// </summary>
    public abstract class MessageBody
    {
        public IEncrypt Encrypt { get; set; }
    }
}
