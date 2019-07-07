using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Extensions
{
    public static partial class JT809PackageExtensions
    {
        public static JT809Package Create<TJT809Bodies>(this JT809BusinessType jT809BusinessType, TJT809Bodies jT809Bodies)
            where TJT809Bodies: JT809Bodies
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Bodies = jT809Bodies;
            jT809Package.Header = new JT809Header()
            {
                BusinessType = (ushort)jT809BusinessType
             };
            return jT809Package;
        }

        public static JT809Package Create<TJT809Bodies>(this ushort jT809BusinessType, TJT809Bodies jT809Bodies)
       where TJT809Bodies : JT809Bodies
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Bodies = jT809Bodies;
            jT809Package.Header = new JT809Header()
            {
                BusinessType = jT809BusinessType
            };
            return jT809Package;
        }

        public static JT809Package Create(this JT809BusinessType jT809BusinessType)
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header()
            {
                BusinessType = (ushort)jT809BusinessType,
            };
            return jT809Package;
        }

        public static JT809Package Create(this ushort jT809BusinessType)
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header()
            {
                BusinessType = jT809BusinessType,
            };
            return jT809Package;
        }

        public static JT809Package Create<TJT809Bodies>(this JT809BusinessType jT809BusinessType, JT809Header jT809Header, TJT809Bodies jT809Bodies)
                    where TJT809Bodies : JT809Bodies
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Bodies = jT809Bodies;
            jT809Package.Header = new JT809Header()
            {
                BusinessType = (ushort)jT809BusinessType,
                MsgSN = jT809Header.MsgSN,
                EncryptFlag = jT809Header.EncryptFlag,
                EncryptKey = jT809Header.EncryptKey,
                MsgGNSSCENTERID = jT809Header.MsgGNSSCENTERID,
                Version = jT809Header.Version
            };
            return jT809Package;
        }

        public static JT809Package Create<TJT809Bodies>(this ushort jT809BusinessType, JT809Header jT809Header, TJT809Bodies jT809Bodies)
            where TJT809Bodies : JT809Bodies
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Bodies = jT809Bodies;
            jT809Package.Header = new JT809Header()
            {
                BusinessType = jT809BusinessType,
                MsgSN = jT809Header.MsgSN,
                EncryptFlag = jT809Header.EncryptFlag,
                EncryptKey = jT809Header.EncryptKey,
                MsgGNSSCENTERID = jT809Header.MsgGNSSCENTERID,
                Version = jT809Header.Version
            };
            return jT809Package;
        }

        public static JT809Package Create(this JT809BusinessType jT809BusinessType, JT809Header jT809Header)
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header()
            {
                BusinessType = (ushort)jT809BusinessType,
                MsgSN = jT809Header.MsgSN,
                EncryptFlag = jT809Header.EncryptFlag,
                EncryptKey = jT809Header.EncryptKey,
                MsgGNSSCENTERID = jT809Header.MsgGNSSCENTERID,
                Version = jT809Header.Version
            };
            return jT809Package;
        }

        public static JT809Package Create(this ushort jT809BusinessType, JT809Header jT809Header)
        {
            JT809Package jT809Package = new JT809Package();
            jT809Package.Header = new JT809Header()
            {
                BusinessType = jT809BusinessType,
                MsgSN = jT809Header.MsgSN,
                EncryptFlag = jT809Header.EncryptFlag,
                EncryptKey = jT809Header.EncryptKey,
                MsgGNSSCENTERID = jT809Header.MsgGNSSCENTERID,
                Version = jT809Header.Version
            };
            return jT809Package;
        }
    }
}
