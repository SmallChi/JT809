using JT809.Protocol.JT809Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Extensions
{
    public static class JT809PackageExtensions
    {
        /// <summary>
        /// 创建JT809Package对应的数据体：
        /// <list type="TJT809Bodies">
        /// <item>
        ///     <description>JT809_0x1001</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1002</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1003</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1004</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1005</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1006</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1007</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1008</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1200</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1300</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1400</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1500</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x1600</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9001</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9002</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9003</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9004</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9005</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9006</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9007</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9008</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9101</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9200</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9300</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9400</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9500</description>
        /// </item>
        /// <item>
        ///     <description>JT809_0x9600</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <typeparam name="TJT809Bodies"></typeparam>
        /// <param name="msgID"></param>
        /// <param name="jT809Bodies"></param>
        /// <returns></returns>
        public static JT809Package Create<TJT809Bodies>(this JT809BusinessType msgID, TJT809Bodies jT809Bodies)
            where TJT809Bodies: JT809Bodies
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Bodies = jT809Bodies;
            jT809Package.Header = new JT809Header()
            {
                MsgID = msgID,
                MsgSN = JT809GlobalConfig.Instance.MsgSNDistributed.Increment(),
                EncryptFlag = JT809GlobalConfig.Instance.HeaderOptions.EncryptFlag,
                EncryptKey = JT809GlobalConfig.Instance.HeaderOptions.EncryptKey,
                MsgGNSSCENTERID = JT809GlobalConfig.Instance.HeaderOptions.MsgGNSSCENTERID,
                Version = JT809GlobalConfig.Instance.HeaderOptions.Version
             };
            return jT809Package;
        }
    }
}
