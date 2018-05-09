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
        public uint GNSSCENTERID { get; set; }
        public Version Version { get; private set; }
        public EncryptOpitions EncryptOpition { get; private set; }
        /// <summary>
        /// 数据加密的密匙，长度为 4 个字节。
        /// </summary>
        public uint EncryptKey { get; private set; } = 0X00;

        public Header(byte[] buffer) : base(buffer) { CounterOnRecieveGenerater++; }


        protected override void InitializeProperties(object[] properties, int startIndex)
        {
            throw new NotImplementedException();
        }

        protected override void OnInitializePropertiesFromReadBuffer(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToBuffer(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
