using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Extensions
{
    public static class JT809PackageExtensions
    {
        public static JT809Package Create<TJT809Bodies>(this JT809BusinessType jT809BusinessType, TJT809Bodies jT809Bodies)
            where TJT809Bodies: JT809Bodies
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Bodies = jT809Bodies;
            jT809Package.Header = new JT809Header()
            {
                BusinessType = jT809BusinessType,
                MsgSN = JT809GlobalConfig.Instance.MsgSNDistributed.Increment(),
                EncryptFlag = JT809GlobalConfig.Instance.HeaderOptions.EncryptFlag,
                EncryptKey = JT809GlobalConfig.Instance.HeaderOptions.EncryptKey,
                MsgGNSSCENTERID = JT809GlobalConfig.Instance.HeaderOptions.MsgGNSSCENTERID,
                Version = JT809GlobalConfig.Instance.HeaderOptions.Version
             };
            return jT809Package;
        }

        public static JT809Package Create(this JT809BusinessType jT809BusinessType)
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header()
            {
                BusinessType = jT809BusinessType,
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
