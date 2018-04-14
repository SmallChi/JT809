namespace JT809.Protocol
{
    public interface IEncrypt
    {
        void Encrypt(byte[] buffer);
        void Decrypt(byte[] buffer);
    }
}
