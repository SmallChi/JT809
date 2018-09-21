using JT809.Protocol.JT809Configs;

namespace JT809.Protocol.JT809Encrypt
{
    /// <summary>
    /// JT809 异或加密解密为同一算法
    /// </summary>
    public class JT809EncryptImpl : IJT809Encrypt
    {
        private JT809EncryptOptions  jT809EncryptOptions;

        public JT809EncryptImpl(JT809EncryptOptions jT809EncryptOptions)
        {
            this.jT809EncryptOptions = jT809EncryptOptions;
        }

        public byte[] Decrypt(byte[] buffer)
        {
             return Encrypt(buffer);
        }

        public byte[] Encrypt(byte[] buffer)
        {
            byte[] data = new byte[buffer.Length];
            if (0 == jT809EncryptOptions.Key)
            {
                jT809EncryptOptions.Key = 1;
            }
            uint mkey = jT809EncryptOptions.M1;
            if (0 == mkey)
            {
                mkey = 1;
            }
            for (int idx = 0; idx < buffer.Length; idx++)
            {
                jT809EncryptOptions.Key = jT809EncryptOptions.IA1 * (jT809EncryptOptions.Key % mkey) + jT809EncryptOptions.IC1;
                buffer[idx] ^= (byte)((jT809EncryptOptions.Key >> 20) & 0xFF);
                data[idx] = buffer[idx];
            }
            return data;
        } 
    }
}
