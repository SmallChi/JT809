using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JT809.Protocol.ProtocolPacket.Bodies.Master
{
    public sealed class Body_UP_CONNECT_REQ : MessageBody
    {
        public uint UserId { get; private set; }

        public byte[] Password { get; private set; }

        public byte[] DownLinkIp { get; private set; }

        public ushort DownLinkPort { get; private set; }

        public Body_UP_CONNECT_REQ(byte[] buffer) : base(buffer) { }

        public Body_UP_CONNECT_REQ(uint userId, byte[] password, byte[] downLinkIp, ushort downLinkPort)
            : base(userId, password, downLinkIp, downLinkPort) { }

        protected override void InitializeProperties(object[] properties, int startIndex)
        {
            UserId = (uint)properties[startIndex++];
            Password = SetMatchBytes((byte[])properties[startIndex++], 8);
            DownLinkIp = SetMatchBytes((byte[])properties[startIndex++], 32);
            DownLinkPort = (ushort)properties[startIndex++];
        }

        protected override void OnInitializePropertiesFromReadBuffer(BinaryReader reader)
        {
            UserId = reader.ReadUInt32Little();
            Password = reader.ReadBytes(8);
            DownLinkIp = reader.ReadBytes(32);
            DownLinkPort = reader.ReadUInt16Little();
        }

        protected override void OnWriteToBuffer(BinaryWriter writer)
        {
            writer.WriteLittle(UserId);
            writer.WriteLittle(Password);
            writer.WriteLittle(DownLinkIp);
            writer.WriteLittle(DownLinkPort);
        }
    }
}
