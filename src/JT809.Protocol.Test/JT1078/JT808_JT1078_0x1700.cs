using JT809.Protocol.Attributes;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Test.JT1078
{
    [JT809Formatter(typeof(JT809BodiesFormatter<JT808_JT1078_0x1700>))]
    public class JT808_JT1078_0x1700: JT809ExchangeMessageBodies
    {

    }
}
