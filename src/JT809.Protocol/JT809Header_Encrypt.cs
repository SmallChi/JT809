namespace JT809.Protocol
{
    /// <summary>
    /// 报文加密标识位 b: 0 表示报文不加密，1 表示报文加密。
    /// </summary>
    public enum JT809Header_Encrypt:byte
    {
        None = 0X00,
        Common = 0X01,
    }
}
