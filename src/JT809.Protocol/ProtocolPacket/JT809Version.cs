namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// 协议版本好标识，上下级平台之间采用的标准协议版编号；
    /// 长度为 3 个字节来表示，
    /// 0x01 0x02 0x0F 标识的版本号是 v1.2.15，以此类推。
    /// </summary>
    public class JT809Version
    {
        public byte[] Buffer { get; } = new byte[3];
        private const int MajorIndex = 0;
        private const int MinorIndex = 1;
        private const int BuildIndex = 2;
        public byte Major
        {
            get { return Buffer[MajorIndex]; }
            private set { Buffer[MajorIndex] = value; }
        }
        public byte Minor
        {
            get { return Buffer[MinorIndex]; }
            private set { Buffer[MinorIndex] = value; }
        }
        public byte Build
        {
            get { return Buffer[BuildIndex]; }
            private set { Buffer[BuildIndex] = value; }
        }
        public JT809Version()
        {
            Major = 1;
            Minor = 0;
            Build = 0;
        }
        public JT809Version(byte major, byte minor, byte buid)
        {
            Major = major;
            Minor = minor;
            Build = buid;
        }
        public override string ToString()
        {
            return $"{Major}.{Minor}.{Build}";
        }
    }
}
