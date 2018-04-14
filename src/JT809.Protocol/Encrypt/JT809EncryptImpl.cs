using JT809.Protocol.Configs;

namespace JT809.Protocol.Encrypt
{
    /// <summary>
    /// JT809 异或加密解密为同一算法
    /// </summary>
    public class JT809EncryptImpl : IEncrypt
    {
        private JT809EncryptConfig Config;

        private uint Key { get; set; }

        public JT809EncryptImpl(uint key,JT809EncryptConfig config)
        {
            Config = config;
            Key = key;
        }

        public void Decrypt(byte[] buffer)
        {
             Encrypt(buffer);
        }

        public void Encrypt(byte[] buffer)
        {
            if (0 == Key)
            {
                Key = 1;
            }
            uint mkey = Config.M1;
            if (0 == mkey)
            {
                mkey = 1;
            }
            for (int idx = 0; idx < buffer.Length; idx++)
            {
                Key = Config.IA1 * (Key % mkey) + Config.IC1;
                buffer[idx] ^= (byte)((Key >> 20) & 0xFF);
            }
        }
    }
}
