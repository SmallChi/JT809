using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using JT809.Protocol.Configs;
using JT809.Protocol.Enums;
using JT809.Protocol.Exceptions;
using JT809.Protocol.ProtocolPacket.Extensions;

namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// 数据包
    /// </summary>
    public class Package: BufferedEntityBase
    {
        public const int NotDataLength = 26;
        public const int Crc16ByteLength = 2;
        public const byte BeginFlag = 0X5B;
        public const byte EndFlag = 0X5D;
        public const int BeginFixedByteLength = 1;
        public const int EndFixedByteLength = 1;

        public JT809Config JT809Config;

        public Header Header { get; private set; }

        public MessageBody Body { get; private set; }

        private ushort CRC16 { get; set; }

        public Package(byte[] buffer) : base(buffer){}

        public Package(Header header, MessageBody body, JT809Config jt809Config) : base(header, body)
        {
            JT809Config = jt809Config;
        } 

        protected override void InitializeProperties(object[] properties, int startIndex)
        {
            Header = properties[0] as Header;
            Body = properties[1] as MessageBody;
            if (Header == null) throw new NullReferenceException($"{new StackFrame().GetMethod().Name }:Header can't be null.");
            if (Body == null) throw new NullReferenceException($"{new StackFrame().GetMethod().Name }:Body can't be null.");
        }

        protected override void OnInitializePropertiesFromReadBuffer(BinaryReader reader)
        {
            var content00 = new byte[Buffer.Length- BeginFixedByteLength-EndFixedByteLength];
            Array.Copy(Buffer, BeginFixedByteLength, content00, 0, Buffer.Length- BeginFixedByteLength-EndFixedByteLength);
            var content01 = this.UnEscape(content00);
            var crc16 = this.CRC16_CCITT(content01, 0, content01.Length - Crc16ByteLength);
            CRC16 = BitConverter.ToUInt16(new[] { content01[content01.Length - 1], content01[content01.Length - 2] }, 0);
            if (CRC16 != crc16) throw new JT809Exception(ErrorCode.CRC16CheckInvalid,$"{CRC16}-{crc16},{content01.ToHexString()}");
            Header = new Header(content01);
            var bodyBuffer00 = new byte[content01.Length - Header.HeaderFixedByteLength - Crc16ByteLength];
            Array.Copy(content01, Header.HeaderFixedByteLength, bodyBuffer00, 0, bodyBuffer00.Length);
            //Default
            byte[] bodyBuffer01 = bodyBuffer00;
            switch (Header.EncryptOpition)
            {
                case EncryptOpitions.None:
                    break;
                case EncryptOpitions.Common:
                    bodyBuffer01 = this.Encrypt(bodyBuffer01, bodyBuffer01.Length, JT809Config.JT809EncryptConfig);
                    break;
            }
            if (Header.Length != (bodyBuffer01.Length + NotDataLength)) throw new JT809Exception(ErrorCode.HeaderLengthNotEqualBodyLength);
            Body = GenerateBody(Header.BusinessID, bodyBuffer01);
        }

        protected override void OnWriteToBuffer(BinaryWriter writer)
        {
            writer.WriteLittle(BeginFlag);
            //Dealling Code On Header
            var headerBuffer00 = Header.Buffer;
            //Dealling Code On Body
            byte[] bodyBuffer00 = Body.Buffer;
            switch (Header.EncryptOpition)
            {
                case EncryptOpitions.None:
                    bodyBuffer00 = Body.Buffer;
                    break;
                case EncryptOpitions.Common:
                    bodyBuffer00 = this.Encrypt(Body.Buffer, Body.Buffer.Length, JT809Config.JT809EncryptConfig);
                    break;
            }
            //Content:Except BeginFlag & EndFlag
            var content = new byte[headerBuffer00.Length + bodyBuffer00.Length + Crc16ByteLength];
            Array.Copy(headerBuffer00, 0, content, 0, headerBuffer00.Length);
            Array.Copy(bodyBuffer00, 0, content, headerBuffer00.Length, bodyBuffer00.Length);
            //Dealling Code On CRC16
            CRC16 = this.CRC16_CCITT(content, 0, content.Length - Crc16ByteLength);
            var crc1600 = BitConverter.GetBytes(CRC16).Reverse().ToArray();
            Array.Copy(crc1600, 0, content, headerBuffer00.Length + bodyBuffer00.Length, Crc16ByteLength);
            //Last Content
            var content00 = this.Escape(content);
            //ToBuffer Core.
            writer.WriteLittle(content00);
            writer.WriteLittle(EndFlag);
        }

        public static Package GeneratePackage(BusinessType businessType, MessageBody messageBody, JT809Config jt809Config)
        {
            var header = new Header((uint)messageBody.Buffer.Length, businessType, jt809Config);
            return new Package(header, messageBody, jt809Config);
        }

        public static MessageBody GenerateBody(BusinessType businessID, byte[] bodyBuffer)
        {
            return Activator.CreateInstance(typeof(object), bodyBuffer) as MessageBody;
        }
    }
}
