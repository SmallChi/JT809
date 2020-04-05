using JT809.Protocol.Extensions;
using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.Internal;
using JT809.Protocol.MessagePack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    /// <summary>
    /// 
    /// ref:https://adamsitnik.com/Array-Pool/
    /// </summary>
    public class JT809Serializer
    {
        private readonly IJT809Config jT809Config;
        private static readonly JT809Package jT809Package = new JT809Package();
        private static readonly JT809HeaderPackage jT809HeaderPackage = new JT809HeaderPackage();
        public JT809Serializer(IJT809Config jT809Config)
        {
            this.jT809Config = jT809Config;
        }
        public JT809Serializer():this(new DefaultGlobalConfig())
        {

        }
        public string SerializerId => jT809Config.ConfigId;
        public byte[] Serialize(JT809Package jT809Package, int minBufferSize = 4096)
        {
            byte[] buffer = JT809ArrayPool.Rent(minBufferSize);
            try
            {
                JT809MessagePackWriter jT809MessagePackWriter = new JT809MessagePackWriter(buffer);
                jT809Package.Serialize(ref jT809MessagePackWriter,jT809Package, jT809Config);
                return jT809MessagePackWriter.FlushAndGetEncodingArray();
            }
            finally
            {
                JT809ArrayPool.Return(buffer);
            }
        }
        public JT809Package Deserialize(ReadOnlySpan<byte> bytes, int minBufferSize = 4096)
        {
            byte[] buffer = JT809ArrayPool.Rent(minBufferSize);
            try
            {
                JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(bytes);
                jT809MessagePackReader.Decode(buffer);
                return jT809Package.Deserialize(ref jT809MessagePackReader, jT809Config);
            }
            finally
            {
                JT809ArrayPool.Return(buffer);
            }
        }
        private static bool CheckPackageType(Type type)
        {
            return type == typeof(JT809Package) || type == typeof(JT809HeaderPackage);
        }
        public byte[] Serialize<T>(T obj,int minBufferSize = 4096)
        {
            byte[] buffer = JT809ArrayPool.Rent(minBufferSize);
            try
            {
                JT809MessagePackWriter jT809MessagePackWriter = new JT809MessagePackWriter(buffer);
                JT809MessagePackFormatterExtensions.GetMessagePackFormatter<T>(jT809Config).Serialize(ref jT809MessagePackWriter, obj,jT809Config);
                return jT809MessagePackWriter.FlushAndGetEncodingArray();
            }
            finally
            {
                JT809ArrayPool.Return(buffer);
            }
        }
        public T Deserialize<T>(ReadOnlySpan<byte> bytes, int minBufferSize = 4096)
        {
            byte[] buffer = JT809ArrayPool.Rent(minBufferSize);
            try
            {
                JT809MessagePackReader jT809MessagePackReader = new JT809MessagePackReader(bytes);
                if (CheckPackageType(typeof(T)))
                    jT809MessagePackReader.Decode(buffer);
                return JT809MessagePackFormatterExtensions.GetMessagePackFormatter<T>(jT809Config).Deserialize(ref jT809MessagePackReader, jT809Config);
            }
            finally
            {
                JT809ArrayPool.Return(buffer);
            }
        }
        public JT809HeaderPackage HeaderDeserialize(ReadOnlySpan<byte> bytes, int minBufferSize = 4096)
        {
            byte[] buffer = JT809ArrayPool.Rent(minBufferSize);
            try
            {
                JT809MessagePackReader jT808MessagePackReader = new JT809MessagePackReader(bytes);
                jT808MessagePackReader.Decode(buffer);
                return jT809HeaderPackage.Deserialize(ref jT808MessagePackReader, jT809Config);
            }
            finally
            {
                JT809ArrayPool.Return(buffer);
            }
        }
    }
}
