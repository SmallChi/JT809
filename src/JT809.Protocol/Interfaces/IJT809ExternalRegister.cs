using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Interfaces
{
    public interface IJT809ExternalRegister
    {
        void Register(Assembly externalAssembly);
    }
}
