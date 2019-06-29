using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Extensions
{
    public static partial class JT809SubPackageExtensions
    {
        public static TJT809SubBodies Create<TJT809SubBodies>(this JT809SubBusinessType jT809SubBusinessType, TJT809SubBodies jT809SubBodies)
            where TJT809SubBodies : JT809SubBodies
        {
            return jT809SubBodies;
        }
    }
}
