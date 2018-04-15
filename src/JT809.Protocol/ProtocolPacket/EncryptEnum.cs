namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// 报文加密标识位 b: 0 表示报文不加密，1 表示报文加密。
    /// </summary>
    public enum EncryptEnum : byte
    {
        No = 0X00,
        Yes = 0X01,
    }
}
