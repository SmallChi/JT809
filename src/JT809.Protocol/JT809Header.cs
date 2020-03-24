﻿using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Formatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    [JT809Formatter(typeof(JT809HeaderFormatter))]
    public class JT809Header
    {
        /// <summary>
        /// 固定为22个字节长度
        /// <para>MSG LENGTH + MSG_SN + MSG_ID + MSG_GNSSCENTERID + VERSION_FLAG + ENCRYPT_FLAG + ENCRYPT_KEY + TIME</para>
        /// <para>4 + 4 + 2 + 4 + 3 + 1 + 4 + 8 = 30</para>
        /// </summary>
        public const int FixedByteLength = 30;
        /// <summary>
        /// 数据长度(包括头标识、数据头、数据体和尾标识)
        /// <para>头标识 + 数据头 + 数据体 + 尾标识</para>
        /// <para>1 + 30 + n + 1</para>
        /// </summary>
        public uint MsgLength { get; set; }
        /// <summary>
        /// 报文序列号 a
        /// </summary>
        public uint MsgSN { get; set; }
        /// <summary>
        /// 业务数据类型
        /// </summary>
        public ushort BusinessType { get; set; }
        /// <summary>
        /// 下级平台接入码，上级平台给下级平台分配唯一标识码。
        /// </summary>
        public uint MsgGNSSCENTERID { get; set; }
        /// <summary>
        /// 协议版本号标识，上下级平台之间采用的标准协议版
        /// 编号；长度为 3 个字节来表示，0x01 0x02 0x0F 标识
        /// 的版本号是 v1.2.15，以此类推。
        /// Hex编码
        /// </summary>
        public JT809Header_Version Version { get; set; } = new JT809Header_Version();
        /// <summary>
        /// 报文加密标识位 b: 0 表示报文不加密，1 表示报文加密。
        /// </summary>
        public JT809Header_Encrypt EncryptFlag { get; set; } = JT809Header_Encrypt.None;
        /// <summary>
        /// 数据加密的密匙，长度为 4 个字节
        /// </summary>
        public uint EncryptKey { get; set; }
        /// <summary>
        /// 发送消息时的系统UTC时间，长度为8个字节
        /// </summary>
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
