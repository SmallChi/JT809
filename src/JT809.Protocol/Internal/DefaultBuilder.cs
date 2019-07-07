using System;
using System.Collections.Generic;
using System.Text;
using JT809.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JT809.Protocol.Internal
{
    class DefaultBuilder : IJT809Builder
    {
        public IServiceCollection Services { get; }

        public IJT809Config Config { get; }

        public DefaultBuilder(IServiceCollection services, IJT809Config config)
        {
            Services = services;
            Config = config;
        }
    }
}
