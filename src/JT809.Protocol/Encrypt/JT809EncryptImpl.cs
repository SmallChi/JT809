using JT809.Protocol.Configs;

namespace JT809.Protocol.Encrypt
{
    /// <summary>
    /// JT809 异或加密解密为同一算法
    /// </summary>
    public class JT809EncryptImpl : IEncrypt
    {
        private JT809EncryptConfig Config;


        public JT809EncryptImpl(JT809EncryptConfig config)
        {
            Config = config;
        }

        public void Decrypt(byte[] buffer)
        {
             Encrypt(buffer);
        }

        public void Encrypt(byte[] buffer)
        {
            if (0 == Config.Key)
            {
                Config.Key = 1;
            }
            uint mkey = Config.M1;
            if (0 == mkey)
            {
                mkey = 1;
            }
            for (int idx = 0; idx < buffer.Length; idx++)
            {
                Config.Key = Config.IA1 * (Config.Key % mkey) + Config.IC1;
                buffer[idx] ^= (byte)((Config.Key >> 20) & 0xFF);
            }
        } 
    }
}
