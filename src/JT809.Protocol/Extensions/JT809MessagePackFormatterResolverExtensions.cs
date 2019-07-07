using JT809.Protocol.Formatters;
using JT809.Protocol.Interfaces;
using JT809.Protocol.MessagePack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JT809.Protocol.Extensions
{
    /// <summary>
    /// 
    /// <para>ref http://adamsitnik.com/Span/#span-must-not-be-a-generic-type-argument </para>
    /// <para>ref http://adamsitnik.com/Span/ </para>
    /// <para>ref MessagePack.Formatters.DynamicObjectTypeFallbackFormatter </para>
    /// </summary>
    public static class JT809MessagePackFormatterResolverExtensions
    {
        delegate void JT809SerializeMethod(object dynamicFormatter, ref JT809MessagePackWriter writer,object value, IJT809Config config);

        delegate dynamic JT809DeserializeMethod(object dynamicFormatter, ref JT809MessagePackReader reader, IJT809Config config);

        static readonly ConcurrentDictionary<Type, (object Value, JT809SerializeMethod SerializeMethod)> jT809Serializers = new ConcurrentDictionary<Type, (object Value, JT809SerializeMethod SerializeMethod)>();

        static readonly ConcurrentDictionary<Type, (object Value, JT809DeserializeMethod DeserializeMethod)> jT809Deserializes = new ConcurrentDictionary<Type, (object Value, JT809DeserializeMethod DeserializeMethod)>();

        public static void JT809DynamicSerialize(object objFormatter, ref JT809MessagePackWriter writer, object value, IJT809Config config)
        {
            Type type = value.GetType();
            var ti = type.GetTypeInfo();
            (object Value, JT809SerializeMethod SerializeMethod) formatterAndDelegate;
            if (!jT809Serializers.TryGetValue(type, out formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IJT809MessagePackFormatter<>).MakeGenericType(t);
                    var param0 = Expression.Parameter(typeof(object), "formatter");
                    var param1 = Expression.Parameter(typeof(JT809MessagePackWriter).MakeByRefType(), "writer");
                    var param2 = Expression.Parameter(typeof(object), "value");
                    var param3 = Expression.Parameter(typeof(IJT809Config), "config");
                    var serializeMethodInfo = formatterType.GetRuntimeMethod("Serialize", new[] { typeof(JT809MessagePackWriter).MakeByRefType(),t, typeof(IJT809Config)});
                    var body = Expression.Call(
                        Expression.Convert(param0, formatterType),
                        serializeMethodInfo,
                        param1,
                        ti.IsValueType ? Expression.Unbox(param2, t) : Expression.Convert(param2, t),
                        param3);
                    var lambda = Expression.Lambda<JT809SerializeMethod>(body, param0, param1, param2, param3).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                jT809Serializers.TryAdd(t, formatterAndDelegate);
            }
            formatterAndDelegate.SerializeMethod(formatterAndDelegate.Value, ref writer, value, config);
        }

        public static dynamic JT809DynamicDeserialize(object objFormatter, ref JT809MessagePackReader reader, IJT809Config config)
        {
            var type = objFormatter.GetType();
            (object Value, JT809DeserializeMethod DeserializeMethod) formatterAndDelegate;
            if (!jT809Deserializes.TryGetValue(type, out formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IJT809MessagePackFormatter<>).MakeGenericType(t);
                    ParameterExpression param0 = Expression.Parameter(typeof(object), "formatter");
                    ParameterExpression param1 = Expression.Parameter(typeof(JT809MessagePackReader).MakeByRefType(), "reader");
                    ParameterExpression param2 = Expression.Parameter(typeof(IJT809Config), "config");
                    var deserializeMethodInfo = type.GetRuntimeMethod("Deserialize", new[] { typeof(JT809MessagePackReader).MakeByRefType(), typeof(IJT809Config) });
                    var body = Expression.Call(
                        Expression.Convert(param0, type),
                        deserializeMethodInfo,
                        param1,
                        param2
                        );
                    var lambda = Expression.Lambda<JT809DeserializeMethod>(body, param0, param1, param2).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                jT809Deserializes.TryAdd(t, formatterAndDelegate);
            }
            return formatterAndDelegate.DeserializeMethod(formatterAndDelegate.Value,ref reader, config);
        }
    }
}
