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
    internal class JT809SubBusinessTypeFactory : IJT809SubBusinessTypeFactory
    {
        public IDictionary<ushort, object> Map { get; }

        internal JT809SubBusinessTypeFactory()
        {
            Map = new Dictionary<ushort, object>();
            InitMap(Assembly.GetExecutingAssembly());
        }

        private void InitMap(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(w => w.BaseType == typeof(JT809SubBodies)).ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                ushort msgId = 0;
                bool replaceInternalSubMsgId;
                try
                {
                    msgId = (ushort)type.GetProperty(nameof(JT809SubBodies.SubMsgId)).GetValue(instance);
                    replaceInternalSubMsgId = (bool)type.GetProperty(nameof(JT809SubBodies.ReplaceInternalSubMsgId)).GetValue(instance);
                }
                catch
                {
                    continue;
                }
                if (Map.ContainsKey(msgId))
                {
                    if (replaceInternalSubMsgId)
                    {
                        Map[msgId] = instance;
                    }
                    else
                    {
                        throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                    }
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

        public IJT809SubBusinessTypeFactory SetMap<TJT809SubBodies>() where TJT809SubBodies : JT809SubBodies
        {
            Type type = typeof(TJT809SubBodies);
            var instance = Activator.CreateInstance(type);
            var msgId = (ushort)type.GetProperty(nameof(JT809SubBodies.SubMsgId)).GetValue(instance);
            bool replaceInternalSubMsgId = (bool)type.GetProperty(nameof(JT809SubBodies.ReplaceInternalSubMsgId)).GetValue(instance);
            if (Map.ContainsKey(msgId))
            {
                if (replaceInternalSubMsgId)
                {
                    Map[msgId] = instance;
                }
                else
                {
                    throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                }
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
