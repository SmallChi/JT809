using JT809.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol
{
    public  interface IJT809Builder
    {
        IServiceCollection Services { get;}

        IJT809Config Config { get; }
    }
}
