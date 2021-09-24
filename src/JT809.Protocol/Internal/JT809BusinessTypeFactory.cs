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

        public IDictionary<ushort, object> Map_2019 { get; }

        internal JT809BusinessTypeFactory()
        {
            Map = new Dictionary<ushort, object>();
            Map_2019 = new Dictionary<ushort, object>();
            InitMap(Assembly.GetExecutingAssembly());
        }

        private void InitMap(Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(w => w.BaseType == typeof(JT809Bodies) || w.BaseType == typeof(JT809ExchangeMessageBodies)).ToList();
            foreach (var type in types)
            {
                if (type.Name == nameof(JT809ExchangeMessageBodies)) continue;
                var instance = Activator.CreateInstance(type);
                ushort msgId = 0;
                JT809Version version;
                bool replaceInternalMsgId;
                try
                {
                    msgId = (ushort)type.GetProperty(nameof(JT809Bodies.MsgId)).GetValue(instance);
                    version = (JT809Version)type.GetProperty(nameof(JT809Bodies.Version)).GetValue(instance);
                    replaceInternalMsgId = (bool)type.GetProperty(nameof(JT809Bodies.ReplaceInternalMsgId)).GetValue(instance);
                }
                catch
                {
                    continue;
                }
                if (Map_2019.ContainsKey(msgId))
                {
                    if (replaceInternalMsgId)
                    {
                        Map_2019[msgId] = instance;
                    }
                    else
                    {
                        if (version == JT809Version.JTT2019)
                        {
                            Map_2019[msgId] = instance;
                        }
                        else
                        {
                            throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                        }
                    }
                }
                else
                {
                    Map_2019.Add(msgId, instance);
                }
                if (Map.ContainsKey(msgId))
                {
                    if (version != JT809Version.JTT2019)
                    {
                        if (replaceInternalMsgId)
                        {
                            Map[msgId] = instance;
                        }
                        else
                        {
                            throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                        }
                    }
                }
                else
                {
                    Map.Add(msgId, instance);
                }
            }
        }

        public IJT809BusinessTypeFactory SetMap<TJT809Bodies>() where TJT809Bodies : JT809Bodies
        {
            Type type = typeof(TJT809Bodies);
            var instance = Activator.CreateInstance(type);
            var msgId = (ushort)type.GetProperty(nameof(JT809Bodies.MsgId)).GetValue(instance);
            JT809Version version = (JT809Version)type.GetProperty(nameof(JT809Bodies.Version)).GetValue(instance);
            bool replaceInternalMsgId = (bool)type.GetProperty(nameof(JT809Bodies.ReplaceInternalMsgId)).GetValue(instance);
            if (Map.ContainsKey(msgId))
            {
                if (replaceInternalMsgId)
                {
                    Map[msgId] = instance;
                }
                else
                {
                    if (version != JT809Version.JTT2019)
                    {
                        throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                    }
                }
            }
            else
            {
                Map.Add(msgId, instance);
            }
            if (Map_2019.ContainsKey(msgId))
            {
                if (replaceInternalMsgId)
                {
                    Map_2019[msgId] = instance;
                }
                else
                {
                    if (version == JT809Version.JTT2019)
                    {
                        Map_2019[msgId] = instance;
                    }
                    else
                    {
                        throw new ArgumentException($"{type.FullName} {msgId} An element with the same key already exists.");
                    }
                }
            }
            else
            {
                Map_2019.Add(msgId, instance);
            }
            return this;
        }

        public void Register(Assembly externalAssembly)
        {
            InitMap(externalAssembly);
        }

        public bool TryGetValue(ushort msgId, JT809Version version, out object instance)
        {
            if (version == JT809Version.JTT2019)
            {
                return Map_2019.TryGetValue(msgId, out instance);
            }
            else
            {
                return Map.TryGetValue(msgId, out instance);
            }
        }
    }
}
