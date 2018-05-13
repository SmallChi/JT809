using System;
using System.Text;
using JT809.Protocol.Configs;
using JT809.Protocol.ProtocolPacket;
using JT809.Protocol.ProtocolPacket.Bodies.Master;
using Xunit;

namespace JT809.Protocol.Test.ProtocolPacket
{
    public class PackageTest
    {
        readonly static JT809Config JT809Config = new JT809Config
        {
            
        };

       [Fact]
        public void CreatePackageTest()
        {
           var body_UP_CONNECT_REQ= new Body_UP_CONNECT_REQ(20140813,
               Encoding.UTF8.GetBytes("20140813"),
               Encoding.UTF8.GetBytes("20140813"),
               809);
            Package package = Package.GeneratePackage(Enums.BusinessType.UP_CONNECT_REQ,
               body_UP_CONNECT_REQ,
                JT809Config);         
            var data = package.Buffer.ToHexString();
            Package package1 = new Package(package.Buffer);
            package1.Buffer.ToHexString();
        }

        [Fact]
        public void TestMethod1()
        {
            //5B 
            //00 00 00 48 
            //00 00 00 85 
            //10 01 
            //01 33 53 D5 
            //01 00 00 
            //00 
            //00 00 27 0F 
            //01 33 53 0D 32 30 31 34 30 38 31 33 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 29 51 83 
            //5D

            //UP-CONNECT-REQ
            byte[] login = new byte[]{
                91,
                00,00,00,48,
                00,00,00,85,
                10,01,
                01,33,53,213,
                01,00,00,
                00,00,00,
                27,15,01,33,
                53,13,32,30,
                31,34,30,38,
                31,33,31,32,
                37,46,30,46,
                30,46,31,00,
                00,00,00,00,
                00,00,00,00,
                00,00,00,00,
                00,00,00,00,
                00,00,
                00,00,
                00,00,03,29,
                51,83,
                93 };
            Package package = new Package(login);
        }

        [Fact]
        public void CrcTest()
        {
            byte[] login = new byte[] {51,83};

            
            var CRC16 = BitConverter.ToUInt16(login, 0);
            byte[] login1 = new byte[] { 83, 51 };
            var CRC161 = BitConverter.ToUInt16(login1, 0);
        }

        [Fact]
        public void MSG_GNSSCENTERIDTest()
        {//8449
            UInt64 result = 0;
            //00, 01, D7, 28
            //01 ,33 ,53 ,0xD5
            //00 01 D7 27
            //00 00 27 0F
            //5B 
            
            byte[] data = new byte[] { 00 ,0x8A ,0xDA ,0xEB };
            int length = 4;
            //00 << 8*(4-0-1)=>00 << 24
            //01 << 8*(4-1-1)=>01 << 16
            //0xD7 << 8*(4-2-1)=>0xD7 << 8
            //27 << 8*(4-3-1)=>27 << 0
            //var a1 = 27 << 0;
            //for (int i = 0; i < length; i++)
            //{

            //    UInt64 currentData = (UInt64)data[i] << (8 * (length - i - 1));
            //    result += currentData;
            //}
            uint value = 20141013;
            var a1 = (byte)(value >> 24);
            var a2 = (byte)(value >> 16);
            var a3 = (byte)(value >> 8);
            var a4 = (byte)(value);
            //01 51 83 213
            var b = (uint)(data[3] | data[2] << 8 | data[1] << 16 | data[0] << 24);
            var a=result.ToString();
        }
    }
}
