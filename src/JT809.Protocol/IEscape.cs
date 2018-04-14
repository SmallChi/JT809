namespace JT809.Protocol
{
    public  interface IEscape
    {
        byte[] Escape(byte[] dataContent, IEncrypt encrypt);
        byte[] UnEscape(byte[] dataContent, IEncrypt encrypt);
    }
}
