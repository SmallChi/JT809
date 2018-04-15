using JT809.Protocol.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT809.Protocol.Test
{
    public class BaseTest
    {
        public JT809EncryptConfig JT809EncryptConfig = new JT809EncryptConfig()
        {
            Key=0x01,
            IA1 = 20000000,
            IC1= 30000000,
            M1= 10000000
        };
    }
}
