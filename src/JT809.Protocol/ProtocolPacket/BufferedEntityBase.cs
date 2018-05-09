using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JT809.Protocol.ProtocolPacket
{
    public abstract class BufferedEntityBase : IBuffered, IBuffer
    {
        public byte[] Buffer { get; protected set; }

        public virtual byte[] ToBuffer()
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                OnWriteToBuffer(writer);
                var reader = new BinaryReader(stream);
                stream.Seek(0, SeekOrigin.Begin);
                Buffer = reader.ReadBytes((int)stream.Length);//stream.GetBuffer();
                stream.Close();
            }
            return Buffer;
        }

        protected BufferedEntityBase(params object[] properties)
        {
            InitializeProperties(properties, 0);
            ToBuffer();
        }
        protected BufferedEntityBase(byte[] buffer)
        {
            Buffer = buffer;
            InitializePropertiesFromBuffer();
        }

        protected abstract void InitializeProperties(object[] properties, int startIndex);

        protected abstract void OnInitializePropertiesFromReadBuffer(BinaryReader reader);

        protected virtual void InitializePropertiesFromBuffer()
        {
            using (var stream = new MemoryStream(Buffer))
            {
                var reader = new BinaryReader(stream);
                OnInitializePropertiesFromReadBuffer(reader);
                stream.Close();
            }
        }

        protected abstract void OnWriteToBuffer(BinaryWriter writer);
    }
}
