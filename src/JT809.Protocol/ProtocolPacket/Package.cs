using System;
using System.Collections.Generic;
using System.IO;
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

        public JT809EncryptConfig Config;

        public Header Header { get; private set; }

        public MessageBody Body { get; private set; }

        private ushort CRC16 { get; set; }

        public Package(byte[] buffer) : base(buffer)
        { }

        public Package(Header header, MessageBody body) : base(header, body)
        { }

        protected override void InitializeProperties(object[] properties, int startIndex)
        {
            throw new NotImplementedException();
        }

        protected override void OnInitializePropertiesFromReadBuffer(BinaryReader reader)
        {
            var content00 = Buffer;
            var content01 = this.UnEscape(content00);
            var crc16 = this.CRC16_CCITT(content01, 0, content01.Length - Crc16ByteLength);
            CRC16 = BitConverter.ToUInt16(new[] { content01[content01.Length - 1], content01[content01.Length - 2] }, 0);
            if (CRC16 != crc16) throw new JT809Exception(ErrorCode.CRC16CheckInvalid);
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
                    bodyBuffer01 = this.Encrypt(bodyBuffer01, bodyBuffer01.Length, Config);
                    break;
            }
            if (Header.Length != (bodyBuffer01.Length + NotDataLength)) throw new JT809Exception(ErrorCode.HeaderLengthNotEqualBodyLength);
            Body = GenerateBody(Header.BusinessID, bodyBuffer01);
        }

        protected override void OnWriteToBuffer(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public static MessageBody GenerateBody(BusinessType businessID, byte[] bodyBuffer)
        {
            return Activator.CreateInstance(typeof(object), bodyBuffer) as MessageBody;
        }
    }
}
