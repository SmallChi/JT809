using JT809.Protocol;
using JT809.Protocol.Attributes;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JT808.Protocol.Internal
{
    internal class JT809BusinessTypeFactory : IJT809BusinessTypeFactory
    {
        public IDictionary<ushort, object> Map { get; }

        internal JT809BusinessTypeFactory()
        {
            Map = new Dictionary<ushort, object>();
            InitMap(Assembly.GetExecutingAssembly());
        }

        private void InitMap(Assembly assembly)
        {
            // var types = assembly.GetTypes().Where(w => w.BaseType == typeof(JT809Bodies)).Where(w=>w != typeof(JT809ExchangeMessageBodies)).ToList();
            var types = assembly.GetTypes()
                .Where(w => w.BaseType == typeof(JT809Bodies) || w.BaseType == typeof(JT809ExchangeMessageBodies)).ToList();
            foreach (var type in types)
            {
                if (type.Name == nameof(JT809ExchangeMessageBodies)) continue;
                var instance = Activator.CreateInstance(type);
                ushort msgId = 0;
                try
                {
                    msgId = (ushort)type.GetProperty(nameof(JT809Bodies.MsgId)).GetValue(instance);
                }
                catch (Exception ex)
                {
                    continue;
                }
                if (Map.ContainsKey(msgId))
                {
                    throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                }
                else
                {
                    Map.Add(msgId, instance);
                }
            }
        }

        public bool TryGetValue(ushort msgId, out object instance)
        {
            return Map.TryGetValue(msgId, out instance);
        }

        public IJT809BusinessTypeFactory SetMap<TJT809Bodies>() where TJT809Bodies : JT809Bodies
        {
            Type type = typeof(TJT809Bodies);
            var instance = Activator.CreateInstance(type);
            var msgId = (ushort)type.GetProperty(nameof(JT809Bodies.MsgId)).GetValue(instance);
            if (Map.ContainsKey(msgId))
            {
                throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
            }
            else
            {
                Map.Add(msgId, instance);
            }
            return this;
        }

        public void Register(Assembly externalAssembly)
        {
            InitMap(externalAssembly);
        }
    }
}
