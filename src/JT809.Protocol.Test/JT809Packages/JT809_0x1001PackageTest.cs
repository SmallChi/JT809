using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.JT809Extensions;
using JT809.Protocol.JT809MessageBody;

namespace JT809.Protocol.Test.JT809Packages
{
    public class JT809_0x1001PackageTest
    {
        [Fact]
        public void Test1()
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header
            {
                MsgSN= 133,
                EncryptKey=9999,
                BusinessType= JT809Enums.JT809BusinessType.主链路登录请求消息,
                MsgGNSSCENTERID= 20180920,
            };
            JT809_0x1001 jT809_0X1001 = new JT809_0x1001();
            jT809_0X1001.UserId = 20180920;
            jT809_0X1001.Password = "20180920";
            jT809_0X1001.DownLinkIP = "127.0.0.1";
            jT809_0X1001.DownLinkPort = 809;
            jT809Package.Bodies = jT809_0X1001;
            var hex = JT809Serializer.Serialize(jT809Package).ToHexString();
            //"5B 
            //00 00 00 48 
            //00 00 00 85 
            //10 01 
            //01 33 EF B8 
            //01 00 00 
            //00 
            //00 00 27 0F 
            //01 33 EF B8 
            //32 30 31 38 30 39 32 30 
            //31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
            //03 29 
            //6A 91 
            //5D"
        }

        [Fact]
        public void Test2()
        {
            var bytes = "5B 00 00 00 48 00 00 00 85 10 01 01 33 EF B8 01 00 00 00 00 00 27 0F 01 33 EF B8 32 30 31 38 30 39 32 30 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 29 6A 91 5D".ToHexBytes();
            JT809Package jT809Package = JT809Serializer.Deserialize(bytes);
            Assert.Equal((uint)72, jT809Package.Header.MsgLength);
            Assert.Equal((uint)133, jT809Package.Header.MsgSN);
            Assert.Equal((uint)9999, jT809Package.Header.EncryptKey);
            Assert.Equal((uint)20180920, jT809Package.Header.MsgGNSSCENTERID);
            Assert.Equal(JT809Enums.JT809BusinessType.主链路登录请求消息, jT809Package.Header.BusinessType);
            Assert.Equal(new JT809Header_Version().ToString(), jT809Package.Header.Version.ToString());
            JT809_0x1001 jT809_0X1001 = (JT809_0x1001)jT809Package.Bodies;
            Assert.Equal((uint)20180920, jT809_0X1001.UserId);
            Assert.Equal("20180920", jT809_0X1001.Password);
            Assert.Equal("127.0.0.1", jT809_0X1001.DownLinkIP);
            Assert.Equal((ushort)809, jT809_0X1001.DownLinkPort);
        }

        [Fact]
        public void Test3()
        {
            //字符'0'：char c = '0'; 它的ASCII码实际上是48。
            //字符'\0' : ASCII码为0，表示一个字符串结束的标志。
            //"5B 00 00 00 48 00 00 00 85 10 01 01 33 EF B8 01 00 00 00 00 00 27 0F 30 01 33 EF B8 32 30 31 38 30 39 32 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 30 31 32 37 2E 30 2E 30 2E 31 03 29 7D 38 5D"
            var data="32 30 31 38 30 39 32 30".ToHexBytes();
            var str = Encoding.GetEncoding("GBK").GetString(data);
            var data1 = "31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00".ToHexBytes();
            var str1 = Encoding.GetEncoding("GBK").GetString(data1);
            var test1 = Encoding.GetEncoding("GBK").GetBytes("\0\0\0\0\0\0127.0.0.1");
            var test2 = Encoding.GetEncoding("GBK").GetBytes("127.0.0.1\0\0\0\0\0\0");
            var test3 = Encoding.GetEncoding("GBK").GetBytes("000000127.0.0.1");
            var test4 = Encoding.GetEncoding("GBK").GetBytes("127.0.0.1000000");
        }
    }
}
