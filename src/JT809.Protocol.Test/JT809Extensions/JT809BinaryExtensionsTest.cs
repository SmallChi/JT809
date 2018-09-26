using JT809.Protocol.JT809Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.JT809Extensions
{
    public class JT809BinaryExtensionsTest
    {
        [Fact]
        public void Test1()
        {
            string vno = "粤A12345";
            byte[] bytes = JT809BinaryExtensions.encoding.GetBytes(vno);
            Assert.Equal(7,vno.Length);
            Assert.Equal(8, bytes.Length);
        }
    }
}
