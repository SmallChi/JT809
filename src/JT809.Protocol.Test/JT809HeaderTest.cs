using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using System.Threading.Tasks;
using System.Diagnostics;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test
{
    public  class JT809HeaderTest
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            JT809Header jT809Header = new JT809Header();
            jT809Header.MsgLength = 24;
            jT809Header.MsgSN = 1024;
            jT809Header.BusinessType = JT809BusinessType.从链路静态信息交换消息.ToUInt16Value();
            jT809Header.MsgGNSSCENTERID = 1200;
            jT809Header.Version = new JT809Header_Version();
            jT809Header.EncryptFlag = JT809Header_Encrypt.None;
            jT809Header.EncryptKey = 0;
            var hex = JT809Serializer.Serialize(jT809Header).ToHexString();
            Assert.Equal("00000018000004009600000004B00100000000000000", hex);
            //"00 00 00 18 00 00 04 00 96 00 00 00 04 B0 01 00 00 00 00 00 00 00"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 00 00 18 00 00 04 00 96 00 00 00 04 B0 01 00 00 00 00 00 00 00".ToHexBytes();
            JT809Header jT809Header= JT809Serializer.Deserialize<JT809Header>(bytes);
            Assert.Equal((uint)24, jT809Header.MsgLength);
            Assert.Equal((uint)1024, jT809Header.MsgSN);
            Assert.Equal(JT809BusinessType.从链路静态信息交换消息, (JT809BusinessType)jT809Header.BusinessType);
            Assert.Equal((uint)1200, jT809Header.MsgGNSSCENTERID);
            Assert.Equal(new JT809Header_Version().ToString(), jT809Header.Version.ToString());
            Assert.Equal(JT809Header_Encrypt.None, jT809Header.EncryptFlag);
            Assert.Equal((uint)0, jT809Header.EncryptKey);
        }

        [Fact]
        public void Test4()
        {
            JT809Header jT809Header = new JT809Header();
            jT809Header.MsgLength = 24;
            jT809Header.MsgSN = 1024;
            jT809Header.BusinessType = JT809BusinessType.从链路静态信息交换消息.ToUInt16Value();
            jT809Header.MsgGNSSCENTERID = 1200; 
            jT809Header.Version = new JT809Header_Version (0xFF,0xAA,0xBB);
            jT809Header.EncryptFlag = JT809Header_Encrypt.None;
            jT809Header.EncryptKey = 0;
            var hex = JT809Serializer.Serialize(jT809Header).ToHexString();
            Assert.Equal("00000018000004009600000004B0FFAABB0000000000", hex);
        }
    }
}
