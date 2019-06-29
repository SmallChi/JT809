using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.MessagePack
{
    public class JT809MessagePackWriterTest
    {
        [Fact]
        public void WriteCRC16Test()
        {
            var bytes = new byte[4096];
            var data = "5B000000480000008510010133EFB8010000000000270F0133EFB832303138303932303132372E302E302E31000000000000000000000000000000000000000000000003296A915D".ToHexBytes();
            JT809MessagePackWriter jT809MessagePackWriter = new JT809MessagePackWriter(bytes);
            jT809MessagePackWriter.WriteArray(data);
            jT809MessagePackWriter.WriteEncode();
            var result=jT809MessagePackWriter.FlushAndGetEncodingArray();
            Assert.Equal(data, result);
        }
    }
}
