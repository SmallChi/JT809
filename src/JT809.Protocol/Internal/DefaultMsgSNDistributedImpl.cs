using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JT809.Protocol.Internal
{
    internal class DefaultMsgSNDistributedImpl : IJT809MsgSNDistributed
    {
        int _counter = 0;

        public uint Increment()
        {
            return (uint)Interlocked.Increment(ref _counter);
        }
    }
}
