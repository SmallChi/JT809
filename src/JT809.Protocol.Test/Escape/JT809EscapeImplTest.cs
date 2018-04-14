using System;
using System.Text;
using JT809.Protocol.Encrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JT809.Protocol.Test.Escape
{
    [TestClass]
    public class JT809EscapeImplTest:BaseTest
    {
        public IEncrypt encrypt;

        public IEncrypt encrypt2;

        public JT809EscapeImplTest()
        {
            encrypt = new JT809EncryptImpl(0x01,base.JT809EncryptConfig);
            encrypt2 = new JT809EncryptImpl(0x01, base.JT809EncryptConfig);
        }


        [TestMethod]
        public void Encrypt()
        {
            var pre = System.Text.Encoding.UTF8.GetBytes("smallchi");
            encrypt.Encrypt(pre);
        }

        [TestMethod]
        public void Decrypt()
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("smallchi");
            byte[] oldBuffer=new byte[buffer.Length];
            buffer.CopyTo(oldBuffer, 0);
            encrypt.Encrypt(buffer);
            encrypt2.Decrypt(buffer);
            string name=System.Text.Encoding.UTF8.GetString(buffer);
            Assert.AreEqual("smallchi",name);
        }
    }
}
