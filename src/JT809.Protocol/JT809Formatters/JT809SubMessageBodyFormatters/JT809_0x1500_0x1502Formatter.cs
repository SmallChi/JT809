using JT809.Protocol.JT809SubMessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Formatters.JT809SubMessageBodyFormatters
{
    public class JT809_0x1500_0x1502Formatter : IJT809Formatter<JT809_0x1500_0x1502>
    {
        public JT809_0x1500_0x1502 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            throw new NotImplementedException();
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT809_0x1500_0x1502 value)
        {
            throw new NotImplementedException();
        }
    }
}
