using JT809.Protocol.Configs;
using JT809.Protocol.Interfaces;
using System;

namespace JT809.Protocol.Encrypt
{
    /// <summary>
    /// JT809 异或加密解密为同一算法
    /// </summary>
    public class JT809EncryptImpl : IJT809Encrypt
    {
        public byte[] Decrypt(ReadOnlySpan<byte> buffer, JT809EncryptOptions encryptOptions, uint privateKey)
        {
             return Encrypt(buffer, encryptOptions,privateKey);
        }

        public byte[] Encrypt(ReadOnlySpan<byte> buffer, JT809EncryptOptions encryptOptions, uint privateKey)
        {
            byte[] data = new byte[buffer.Length];
            if (0 == privateKey)
            {
                privateKey = 1;
            }
            uint mkey = encryptOptions.M1;
            if (0 == mkey)
            {
                mkey = 1;
            }
            for (int idx = 0; idx < buffer.Length; idx++)
            {
                privateKey = encryptOptions.IA1 * (privateKey % mkey) + encryptOptions.IC1;
                byte tmp = buffer[idx];
                tmp ^= (byte)((privateKey >> 20) & 0xFF);
                data[idx] = tmp;
            }
            return data;
        } 
    }
}
