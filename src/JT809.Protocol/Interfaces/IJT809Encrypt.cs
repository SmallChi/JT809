using JT809.Protocol.Configs;
using System;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809Encrypt
    {
        byte[] Encrypt(ReadOnlySpan<byte> buffer, JT809EncryptOptions encryptOptions, uint privateKey);
        byte[] Decrypt(ReadOnlySpan<byte> buffer, JT809EncryptOptions encryptOptions, uint privateKey);
    }
}
