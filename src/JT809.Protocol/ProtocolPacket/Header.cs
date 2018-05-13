using JT809.Protocol.Configs;
using JT809.Protocol.Enums;
using System;
using System.IO;

namespace JT809.Protocol.ProtocolPacket
{
    /// <summary>
    /// Message Header 数据头
    /// </summary>
    public class Header: BufferedEntityBase
    {
        /// <summary>
        /// 固定为22个字节长度
        /// </summary>
        public const int HeaderFixedByteLength = 22;
        /// <summary>
        /// 发送计数器
        /// 占用四个字节，为发送信息的序列号，用于接收方检测是否有信息的丢失，上级平台和下级平台接自己发送数据包的个数计数，互不影响。
        /// 程序开始运行时等于零，发送第一帧数据时开始计数，到最大数后自动归零
        /// </summary>
        public static uint CounterOnSendGenerater { get; private set; }
        /// <summary>
        /// 接收计数器
        /// 占用四个字节，为发送信息的序列号，用于接收方检测是否有信息的丢失，上级平台和下级平台接自己发送数据包的个数计数，互不影响。
        /// 程序开始运行时等于零，发送第一帧数据时开始计数，到最大数后自动归零
        /// </summary>
        public static uint CounterOnRecieveGenerater { get; private set; }
        /// <summary>
        /// 数据长度(包括头标识、数据头、数据体和尾标识)
        /// </summary>
        public uint Length { get; private set; }
        /// <summary>
        /// 报文序列号
        /// </summary>
        public uint SN { get; private set; }
        /// <summary>
        /// 业务数据类型
        /// </summary>
        public BusinessType BusinessID { get; private set; }
        /// <summary>
        /// 下级平台接入码，上级平台给下级平台分配唯一标识码。
        /// </summary>
        public uint SessionId { get; set; }
        public JT809Version JT809Version { get; private set; }
        public EncryptOpitions EncryptOpition { get; private set; }
        /// <summary>
        /// 数据加密的密匙，长度为 4 个字节。
        /// </summary>
        public uint EncryptKey { get; private set; } = 0X00;

        public Header(byte[] buffer) : base(buffer) { CounterOnRecieveGenerater++; }

        internal Header(uint length, uint number, BusinessType businessID, JT809Config jt809Config) : base(length, number, businessID, jt809Config)
        { CounterOnSendGenerater++; }

        public Header(uint length, BusinessType businessID, JT809Config jt809Config) : this(length, CounterOnSendGenerater, businessID, jt809Config) { }

        protected override void InitializeProperties(object[] properties, int startIndex)
        {
            Length = (uint)properties[0] + Package.NotDataLength;
            SN = (uint)properties[1];
            BusinessID = (BusinessType)properties[2];
            JT809Config jt809Config=(JT809Config)properties[3];
            SessionId = jt809Config.SessionId;
            JT809Version = jt809Config.JT809Version;
            EncryptOpition = jt809Config.JT809EncryptConfig==null? EncryptOpitions.None: EncryptOpitions.Common;
            if(jt809Config.JT809EncryptConfig == null)
            {
                EncryptOpition = EncryptOpitions.None;
            }
            else
            {
                EncryptOpition = EncryptOpitions.Common;
                EncryptKey = jt809Config.JT809EncryptConfig.Key;
            }
        }

        protected override void OnInitializePropertiesFromReadBuffer(BinaryReader reader)
        {
            Length = reader.ReadUInt32Little();
            SN = reader.ReadUInt32Little();
            BusinessID = (BusinessType)reader.ReadUInt16Little();
            SessionId = reader.ReadUInt32Little();
            JT809Version = new JT809Version(reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
            EncryptOpition = (EncryptOpitions)reader.ReadByte();
            EncryptKey = reader.ReadUInt32Little();
        }

        protected override void OnWriteToBuffer(BinaryWriter writer)
        {
            writer.WriteLittle(Length);
            writer.WriteLittle(SN);
            writer.WriteLittle((ushort)BusinessID);
            writer.WriteLittle(SessionId);
            writer.WriteLittle(JT809Version.Buffer);
            writer.WriteLittle((byte)EncryptOpition);
            writer.WriteLittle(EncryptKey);
        }
    }
}
