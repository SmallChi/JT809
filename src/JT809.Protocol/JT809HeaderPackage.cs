using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// JT809头部数据包
    /// </summary>
    [JT809Formatter(typeof(JT809HeaderPackageFromatter))]
    public class JT809HeaderPackage
    {
        public byte BeginFlag { get; set; } = JT809Package.BEGINFLAG;

        public JT809Header Header { get; set; }

        public byte[] Bodies { get; set; }

        public ushort CRCCode { get; set; }

        public byte EndFlag { get; set; } = JT809Package.ENDFLAG;
    }
}
