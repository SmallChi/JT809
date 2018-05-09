using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.ProtocolPacket
{
    public interface IBuffered
    {
        byte[] ToBuffer();
    }
}
