namespace JT809.Protocol
{
    public interface IJT809Encrypt
    {
        byte[] Encrypt(byte[] buffer);
        byte[] Decrypt(byte[] buffer);
    }
}
