using JT809.Protocol.Configs;
using JT809.Protocol.Encrypt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;

namespace JT809.Protocol.Test.JT809Encrypt
{
    public class JT809EncryptTest
    {
        private JT809EncryptOptions options = new JT809EncryptOptions
        {
            IA1 = 20000000,
            IC1 = 20000000,
            M1 = 30000000
        };

        [Fact]
        public void Test1()
        {
            byte[] bytes = new byte[]
            {
                01,02,03,04,05,06,07
            };
            IJT809Encrypt jT809Encrypt = new JT809EncryptImpl();
            var data = jT809Encrypt.Encrypt(bytes, options, 256178).ToHexString();
            //"D3 4C 70 78 A7 3A 41"
        }

        [Fact]
        public void Test2()
        {
            byte[] bytes = "D3 4C 70 78 A7 3A 41".ToHexBytes();
            IJT809Encrypt jT809Encrypt = new JT809EncryptImpl();
            var data = jT809Encrypt.Decrypt(bytes, options, 256178);
            Assert.Equal(new byte[]
            {
                01,02,03,04,05,06,07
            }, data);
        }
    }
}
