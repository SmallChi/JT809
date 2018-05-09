using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            if (CRC16 != crc16) throw new InvalidDataException("CRC16 check invalid.");
        }

        protected override void OnWriteToBuffer(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
