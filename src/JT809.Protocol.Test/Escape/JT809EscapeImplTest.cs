using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JT809.Protocol.Configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JT809.Protocol.Test.Escape
{
    [TestClass]
    public class JT809EscapeImplTest:BaseTest
    {
        //public IEncrypt encrypt;

        //public JT809EscapeImplTest()
        //{
        //    encrypt = new JT809EncryptImpl(base.JT809EncryptConfig);
        //}

        //[TestMethod]
        //public void Encrypt()
        //{
        //    byte[] buffer = System.Text.Encoding.UTF8.GetBytes("smallchi");
        //    Debug.WriteLine(JsonConvert.SerializeObject(buffer.Select(s => s).ToList()));
        //    encrypt.Encrypt(buffer);
        //    Debug.WriteLine(JsonConvert.SerializeObject(buffer.Select(s => s).ToList()));
        //}

        //[TestMethod]
        //public void Decrypt()
        //{
        //    byte[] buffer =new byte [8]{ 92, 113, 125, 112, 112, 127, 116, 117};
        //    Debug.WriteLine(JsonConvert.SerializeObject(buffer.Select(s => s).ToList()));
        //    encrypt.Decrypt(buffer);
        //    Debug.WriteLine(JsonConvert.SerializeObject(buffer.Select(s => s).ToList()));
        //    string name = System.Text.Encoding.UTF8.GetString(buffer);
        //    Assert.AreEqual("smallchi", name);
        //}
    }
}
