namespace JT809.Protocol
{
    public interface IJT809Encrypt
    {
        byte[] Encrypt(byte[] buffer, uint privateKey);
        byte[] Decrypt(byte[] buffer, uint privateKey);
    }
}
