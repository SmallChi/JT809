using JT809.Protocol.MessagePack;
using JT809.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JT809.Protocol.Test.MessagePack
{
    public class JT808MessagePackReaderTest
    {
        [Fact]
        public void WriteCRC16Test()
        {
            var data = "5B000000480000008510010133EFB8010000000000270F0133EFB832303138303932303132372E302E302E31000000000000000000000000000000000000000000000003296A915D".ToHexBytes();
            JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(data);
            jT809MessagePackReader.Decode();
            Assert.True(jT809MessagePackReader.CheckXorCodeVali);
        }

        [Fact]
        public void WriteCRC16Test1()
        {
            var data = "5A 01 00 5A 02 48 5E 02 5E 00 5E 01".ToHexBytes();
            JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(data);
            jT809MessagePackReader.FullDecode();
            Assert.Equal("5B 00 5A 48 5E 5E 00 5D".ToHexBytes(), jT809MessagePackReader.Reader.ToArray());
        }

        [Fact]
        public void DecodeTest1()
        {
            //5B
            //0000006E00000002140000000000010000000000000014020000004E31323334353637383931320001000000005E7B1E28000000005E7B1E28000000005E7B1E28B4A8413132333435000000000000000000000000000131323334353637383931320000007B00000000
            //00 5A 02 4A
            //5D
            var data = "5B0000006E00000002140000000000010000000000000014020000004E31323334353637383931320001000000005E7B1E28000000005E7B1E28000000005E7B1E28B4A8413132333435000000000000000000000000000131323334353637383931320000007B000000005A024A5D".ToHexBytes();
            JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(data);
            jT809MessagePackReader.Decode();
            Assert.True(jT809MessagePackReader.CheckXorCodeVali);
            Assert.Equal(jT809MessagePackReader.Reader.Length, data.Length-1);
        }

        [Fact]
        public void DecodeTest2()
        {
            //手动测试
            var data = "5B0000006E00000002140000000000010000000000000014020000004E31323334353637383931320001000000005E7B1E28000000005E7B1E28000000005E7B1E28B4A8413132333435000000000000000000000000000131323334353637383931320000007B000000005A025A025D".ToHexBytes();
            JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(data);
            jT809MessagePackReader.Decode();
            Assert.Equal(jT809MessagePackReader.Reader.Length, data.Length - 2);
        }

        [Fact]
        public void DecodeTest3()
        {
            //手动测试
            var data = "5B0000006E00000002140000000000010000000000000014020000004E31323334353637383931320001000000005E7B1E28000000005E7B1E28000000005E7B1E28B4A8413132333435000000000000000000000000000131323334353637383931320000007B00000000A45A025D".ToHexBytes();
            JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(data);
            jT809MessagePackReader.Decode();
            Assert.Equal(jT809MessagePackReader.Reader.Length, data.Length - 1);
        }
    }
}
