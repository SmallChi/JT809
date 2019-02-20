using JT809.Protocol.Formatters;
using System;
using System.Buffers;
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
    public static class JT809FormatterResolverExtensions
    {
        delegate int JT809SerializeMethod(object dynamicFormatter, ref byte[] bytes, int offset, object value);

        delegate dynamic JT809DeserializeMethod(object dynamicFormatter, ReadOnlySpan<byte> bytes,  out int readSize);

        static readonly ConcurrentDictionary<Type, (object Value, JT809SerializeMethod SerializeMethod)> jT809Serializers = new ConcurrentDictionary<Type, (object Value, JT809SerializeMethod SerializeMethod)>();

        static readonly ConcurrentDictionary<Type, (object Value, JT809DeserializeMethod DeserializeMethod)> jT809Deserializes = new ConcurrentDictionary<Type, (object Value, JT809DeserializeMethod DeserializeMethod)>();

        //T Deserialize(ReadOnlySpan<byte> bytes, out int readSize);
        //int Serialize(IMemoryOwner<byte> memoryOwner, int offset, T value);

        public static int JT809DynamicSerialize(object objFormatter,ref byte[] bytes, int offset, dynamic value)
        {
            Type type = value.GetType();
            var ti = type.GetTypeInfo();
            (object Value, JT809SerializeMethod SerializeMethod) formatterAndDelegate;
            if (!jT809Serializers.TryGetValue(type, out formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IJT809Formatter<>).MakeGenericType(t);
                    var param0 = Expression.Parameter(typeof(object), "formatter");
                    var param1 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
                    var param2 = Expression.Parameter(typeof(int), "offset");
                    var param3 = Expression.Parameter(typeof(object), "value");
                    var serializeMethodInfo = formatterType.GetRuntimeMethod("Serialize", new[] { typeof(byte[]).MakeByRefType(), typeof(int), t});
                    var body = Expression.Call(
                        Expression.Convert(param0, formatterType),
                        serializeMethodInfo,
                        param1,
                        param2,
                        ti.IsValueType ? Expression.Unbox(param3, t) : Expression.Convert(param3, t));
                    var lambda = Expression.Lambda<JT809SerializeMethod>(body, param0, param1, param2, param3).Compile();
                    formatterAndDelegate = (objFormatter, lambda);
                }
                jT809Serializers.TryAdd(t, formatterAndDelegate);
            }
            return formatterAndDelegate.SerializeMethod(formatterAndDelegate.Value, ref bytes, offset, value);
        }

        public static dynamic JT809DynamicDeserialize(object objFormatter,ReadOnlySpan<byte> bytes, out int readSize)
        {
            var type = objFormatter.GetType();
            (object Value, JT809DeserializeMethod DeserializeMethod) formatterAndDelegate;
            if (!jT809Deserializes.TryGetValue(type, out formatterAndDelegate))
            {
                var t = type;
                {
                    var formatterType = typeof(IJT809Formatter<>).MakeGenericType(t);
                    ParameterExpression param0 = Expression.Parameter(typeof(object), "formatter");
                    ParameterExpression param1 = Expression.Parameter(typeof(ReadOnlySpan<byte>), "bytes");
                    ParameterExpression param2 = Expression.Parameter(typeof(int).MakeByRefType(), "readSize");
                    var deserializeMethodInfo = type.GetRuntimeMethod("Deserialize", new[] { typeof(ReadOnlySpan<byte>), typeof(int).MakeByRefType() });
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
            return formatterAndDelegate.DeserializeMethod(formatterAndDelegate.Value, bytes,  out readSize);
        }
    }
}
