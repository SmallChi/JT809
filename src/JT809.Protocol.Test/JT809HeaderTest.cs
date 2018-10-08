using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JT809.Protocol.Test
{
    public  class JT809HeaderTest
    {
        [Fact]
        public void Test1()
        {
            JT809Header jT809Header = new JT809Header();
            jT809Header.MsgLength = 24;
            jT809Header.MsgSN = 1024;
            jT809Header.MsgID = JT809Enums.JT809BusinessType.DOWN_BASE_MSG;
            jT809Header.MsgGNSSCENTERID = 1200;
            jT809Header.Version = new JT809Header_Version();
            jT809Header.EncryptFlag = JT809Header_Encrypt.None;
            jT809Header.EncryptKey = 0;
            var hex = JT809Serializer.Serialize(jT809Header).ToHexString();
            //"00 00 00 18 00 00 04 00 96 00 00 00 04 B0 01 00 00 00 00 00 00 00"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 18 00 00 04 00 96 00 00 00 04 B0 01 00 00 00 00 00 00 00".ToHexBytes();
            JT809Header jT809Header= JT809Serializer.Deserialize<JT809Header>(bytes);
            Assert.Equal((uint)24, jT809Header.MsgLength);
            Assert.Equal((uint)1024, jT809Header.MsgSN);
            Assert.Equal(JT809Enums.JT809BusinessType.DOWN_BASE_MSG, jT809Header.MsgID);
            Assert.Equal((uint)1200, jT809Header.MsgGNSSCENTERID);
            Assert.Equal(new JT809Header_Version().ToString(), jT809Header.Version.ToString());
            Assert.Equal(JT809Header_Encrypt.None, jT809Header.EncryptFlag);
            Assert.Equal((uint)0, jT809Header.EncryptKey);
        }

        [Fact]
        public void Test3()
        {    
            Parallel.For(0, 1000, (i) => 
            {
                JT809GlobalConfig.Instance.MsgSNDistributed.Increment();
            });
            Parallel.For(0, 1000, (i) =>
            {
                JT809GlobalConfig.Instance.MsgSNDistributed.Increment();
            });
            var sn = JT809GlobalConfig.Instance.MsgSNDistributed.Increment();
        }
    }
}
