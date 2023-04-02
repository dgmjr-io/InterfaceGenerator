//
// Enumeration{TEnumeration, TId, TValue}.cs
//
//   Created: 2022-10-19-01:55:33
//   Modified: 2022-11-03-12:28:37
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Enumerations;
using System;
using System.Diagnostics;
using Dgmjr.Abstractions;

/// <summary>
/// An abstract base class for enumerations.
/// </summary>
/// <typeparam name="TValue">The type of the enumeration's value</typeparam>
/// <typeparam name="TId">The type of the enumeration's id</typeparam>
/// <typeparam name="TSelf">The type of the enumeration (must be the name of the
///     declared class)</typeparam>
#if NETSTANDARD2_0_OR_GREATER
[Serializable]
#endif
[DebuggerDisplay("{DisplayName} - {Value}")]
public record struct Enumeration<TSelf, TId, TValue> : IEnumeration, IEnumeration<TSelf, TId>, IEquatable<TValue>, IComparable<TValue>, IHaveAValue<TValue>, IHaveAValue, IIdentifiable<TId>, IIdentifiable
    where TSelf : struct, IEnumeration<TSelf, TId>
    where TValue : Enum, IComparable
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
{
    public Enumeration(TId id, TValue value, string name)
    {
        Id = id;
        Value = value;
        Name = name;
    }

    /// <summary>
    /// Gets the underlying value of the enumeration.
    /// </summary>
    /// <returns>The underlying value of the enumeration.</returns>
    public TValue Value { get; init; }
    /// <summary>
    /// Gets the numeric ID of the enumeration.
    /// </summary>
    /// <returns>The numeric ID of the enumeration.</returns>
    public TId Id { get; init; }
    object IIdentifiable.Id => Id;
    object IHaveAValue.Value => Value;
    /// <summary>
    /// Gets the field info of the backing type of the enumeration.
    /// </summary>
    /// <returns>The field info of the backing type of the enumeration.
    ///     </returns>
    public FieldInfo? FieldInfo => GetType().GetFieldInfo(Name);
    private Func<IEnumeration, string> ToStringDelegate { get; init; } = e => e.DisplayName;
    /// <summary>
    /// Gets the custom attribute of type <typeparamref name="TAttribute"/> from
    /// the enumeration's <see cref="FieldInfo"/>.
    /// </summary>
    public TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute
        => ((IEnumeration)this).GetCustomAttribute<DisplayAttribute>() as TAttribute;
    /// <summary>
    /// Gets the <see cref="DisplayAttribute"/> of the
    /// enumeration'<see cref="FieldInfo"/>.
    /// </summary>
    public DisplayAttribute? DisplayAttribute => GetCustomAttribute<DisplayAttribute>();

    /// <summary>
    /// Gets the short name of the enumeration as pulled from the
    /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
    /// </summary>
    [FromString]
    public string ShortName => DisplayAttribute?.ShortName ?? Name;
    /// <summary>
    /// Gets the description of the enumeration as pulled from the
    /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
    /// </summary>
    public string Description => DisplayAttribute?.Description ?? Name;
    /// <summary>
    /// Gets the display name of the enumeration as pulled from the
    /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
    /// </summary>
    [FromString]
    public string DisplayName => DisplayAttribute?.Name ?? Name;
    /// <summary>
    /// Gets the group name of the enumeration as pulled from the
    /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
    /// </summary>
    public string GroupName => DisplayAttribute?.GroupName ?? Enumeration.NoGroup;
    /// <summary>
    /// Gets the order of the enumeration as pulled from the
    /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
    /// </summary>
    public int Order => DisplayAttribute?.Order ?? Enumeration.DefaultOrder;

    /// <summary>
    /// Gets the name of the enumeration.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the enumeration's value as a string.
    /// </summary>
    public override string ToString() => ToStringDelegate(this);

    public int CompareTo(object? other) => other is IEnumeration ? CompareTo((IEnumeration)other) : -1;
    public int CompareTo(IEnumeration other) => Id.CompareTo(other.Id);
    // public override bool Equals(object other) => other is IEnumeration && CompareTo(other) == 0;
    public bool Equals(IEnumeration? other) => GetHashCode() == other?.GetHashCode();
    public override int GetHashCode() => Id.GetHashCode();

    public TypeCode GetTypeCode() => Convert.GetTypeCode(Value);

    #region type conversions
    /// <summary>
    /// Converts the value of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent string representation.
    /// </summary>
    public object ToType(Type conversionType, IFormatProvider? provider) => Convert.ChangeType(Value, conversionType);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="bool"/> representation (if it exists).
    /// </summary>
    public bool ToBoolean(IFormatProvider? provider = null) => Convert.ToBoolean(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="byte"/> representation (if it exists).
    /// </summary>
    public byte ToByte(IFormatProvider? provider = null) => Convert.ToByte(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="char"/> representation (if it exists).
    /// </summary>
    public char ToChar(IFormatProvider? provider = null) => Convert.ToChar(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see cref="DateTime"/> representation (if it exists).
    /// </summary>
    public DateTime ToDateTime(IFormatProvider? provider = null) => Convert.ToDateTime(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="decimal"/> representation (if it exists).
    /// </summary>
    public decimal ToDecimal(IFormatProvider? provider = null) => Convert.ToDecimal(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="double"/> representation (if it exists).
    /// </summary>
    public double ToDouble(IFormatProvider? provider = null) => Convert.ToDouble(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="short"/> representation (if it exists).
    /// </summary>
    public short ToInt16(IFormatProvider? provider = null) => Convert.ToInt16(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="int"/> representation (if it exists).
    /// </summary>
    public int ToInt32(IFormatProvider? provider = null) => Convert.ToInt32(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="long"/> representation (if it exists).
    /// </summary>
    public long ToInt64(IFormatProvider? provider = null) => Convert.ToInt64(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="sbyte"/> representation (if it exists).
    /// </summary>
    public sbyte ToSByte(IFormatProvider? provider = null) => Convert.ToSByte(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="float"/> representation (if it exists).
    /// </summary>
    public float ToSingle(IFormatProvider? provider = null) => Convert.ToSingle(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="string"/> representation (if it exists).
    /// </summary>
    public string ToString(IFormatProvider? provider = null) => ToString();
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="ushort"/> representation (if it exists).
    /// </summary>
    public ushort ToUInt16(IFormatProvider? provider = null) => Convert.ToUInt16(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="uint"/> representation (if it exists).
    /// </summary>
    public uint ToUInt32(IFormatProvider? provider = null) => Convert.ToUInt32(Value, provider);
    /// <summary>
    /// Converts the <see cref="Value"/> of the current
    /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
    /// equivalent <see langword="ulong"/> representation (if it exists).
    /// </summary>
    public ulong ToUInt64(IFormatProvider? provider = null) => Convert.ToUInt64(Value, provider);
    #endregion

    // public static bool operator ==(Enumeration<TSelf, TId, TValue> e, Enumeration<TSelf, TId, TValue> o) => e.Equals(o);
    // public static bool operator !=(Enumeration<TSelf, TId, TValue> e, Enumeration<TSelf, TId, TValue> o) => !e.Equals(o);

    /// <summary>
    /// Converts the <paramref name="value"/> to an object of type
    /// <paramref name="t"/>.
    /// </summary>
    public static IEnumeration? FromValue(Type t, object value) => Parse(t, x => x.Value.Equals(value));
    /// <summary>
    /// Converts the <paramref name="value"/> to an object of type
    /// <typeparamref name="TEnumeration"/>.
    /// </summary>
    public static TEnumeration? FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration => FromValue(typeof(TEnumeration), value) as TEnumeration;
    /// <summary>
    /// Retrieves a list of values that are members of the enumeration.
    /// </summary>
    public static IEnumeration[] GetValues(Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
    /// <summary>
    /// Retrieves a list of values that are members of the enumeration.
    /// </summary>
    public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
    /// <summary>
    /// Retrieves a list of <see cref="PropertyInfo"/>s that can be used to
    /// convert <see langword="string"/>s to the enumeration.
    /// </summary>
    private static IEnumerable<PropertyInfo> GetFromStringProperties(Type t)
        => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);
    /// <summary>
    /// Retrieves a list of <see cref="PropertyInfo"/>s that can be used to
    /// convert <see langword="string"/>s to the enumeration.
    /// </summary>
    private static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
        => GetFromStringProperties(typeof(TEnumeration));
    /// <summary>
    /// Parses the <paramref name="value"/> to an object of type
    /// <see cref="IEnumeration"/>.
    /// </summary>
    public static IEnumeration? Parse(Type t, string value) => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) as string == value));
    /// <summary>
    /// Parses the <paramref name="value"/> to an object of type
    /// <typeparamref name="TEnumeration"/>.
    /// </summary>
    public static TEnumeration? Parse<TEnumeration>(string value) where TEnumeration : IEnumeration
        => Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) as string == value));
    public static TEnumeration? Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration
        => GetValues<TEnumeration>().FirstOrDefault(matchPredicate);
    public static IEnumeration? Parse(Type t, Func<IEnumeration, bool> matchPredicate)
        => GetValues(t).FirstOrDefault(matchPredicate);
    public static bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration
        => (value = Parse<TEnumeration>(s) as TEnumeration) != null;

    public bool Equals(IEnumeration<TSelf> other) => Equals(other as IEnumeration);
    public int CompareTo(TValue? other) => Value.CompareTo(other);
    public bool Equals(TValue? other) => Value.Equals(other);

    public static IEnumerable<TSelf> GetAll() => GetValues<TSelf>();
}

// /// <summary>
// /// An abstract base class for enumerations.
// /// </summary>
// /// <typeparam name="TValue">The type of the enumeration's value</typeparam>
// /// <typeparam name="TId">The type of the enumeration's id</typeparam>
// /// <typeparam name="TSelf">The type of the enumeration (must be the name of the
// ///     declared class)</typeparam
// #if NETSTANDARD2_0_OR_GREATER
// [Serializable]
// #endif
// [DebuggerDisplay("{DisplayName} - {Value}")]
// public record class EnumerationClass<TSelf, TId, TValue> : IEnumeration, IEnumeration<TSelf, TId>, IEquatable<TValue>, IComparable<TValue>, IHaveAValue<TValue>, IHaveAValue, IIdentifiable<TId>, IIdentifiable
//     where TSelf : class, IEnumeration<TSelf, TId>
//     where TValue : Enum, IComparable
//     where TId : IComparable, IComparable<TId>, IEquatable<TId>
// {
//     public EnumerationClass(TId id, TValue value, string name)
//     {
//         Id = id;
//         Value = value;
//         Name = name;
//     }

//     /// <summary>
//     /// Gets the underlying value of the enumeration.
//     /// </summary>
//     /// <returns>The underlying value of the enumeration.</returns>
//     public TValue Value { get; init; }
//     /// <summary>
//     /// Gets the numeric ID of the enumeration.
//     /// </summary>
//     /// <returns>The numeric ID of the enumeration.</returns>
//     public TId Id { get; init; }
//     object IIdentifiable.Id => Id;
//     object IHaveAValue.Value => Value;
//     /// <summary>
//     /// Gets the field info of the backing type of the enumeration.
//     /// </summary>
//     /// <returns>The field info of the backing type of the enumeration.
//     ///     </returns>
//     public FieldInfo FieldInfo => GetType().GetFieldInfo(Name);
//     private Func<IEnumeration, string> ToStringDelegate { get; init; } = e => e.DisplayName;
//     /// <summary>
//     /// Gets the custom attribute of type <typeparamref name="TAttribute"/> from
//     /// the enumeration's <see cref="FieldInfo"/>.
//     /// </summary>
//     public TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute
//         => ((IEnumeration)this).GetCustomAttribute<DisplayAttribute>() as TAttribute;
//     /// <summary>
//     /// Gets the <see cref="DisplayAttribute"/> of the
//     /// enumeration'<see cref="FieldInfo"/>.
//     /// </summary>
//     public DisplayAttribute? DisplayAttribute => GetCustomAttribute<DisplayAttribute>();

//     /// <summary>
//     /// Gets the short name of the enumeration as pulled from the
//     /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
//     /// </summary>
//     [FromString]
//     public string ShortName => DisplayAttribute?.ShortName ?? Name;
//     /// <summary>
//     /// Gets the description of the enumeration as pulled from the
//     /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
//     /// </summary>
//     public string Description => DisplayAttribute?.Description ?? Name;
//     /// <summary>
//     /// Gets the display name of the enumeration as pulled from the
//     /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
//     /// </summary>
//     [FromString]
//     public string DisplayName => DisplayAttribute?.Name ?? Name;
//     /// <summary>
//     /// Gets the group name of the enumeration as pulled from the
//     /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
//     /// </summary>
//     public string GroupName => DisplayAttribute?.GroupName ?? Enumeration.NoGroup;
//     /// <summary>
//     /// Gets the order of the enumeration as pulled from the
//     /// <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute"/>.
//     /// </summary>
//     public int Order => DisplayAttribute?.Order ?? Enumeration.DefaultOrder;

//     /// <summary>
//     /// Gets the name of the enumeration.
//     /// </summary>
//     public string Name { get; init; }

//     /// <summary>
//     /// Gets the enumeration's value as a string.
//     /// </summary>
//     public override string ToString() => ToStringDelegate(this);

//     public int CompareTo(object other) => other is IEnumeration ? CompareTo((IEnumeration)other) : -1;
//     public int CompareTo(IEnumeration other) => Id.CompareTo(other.Id);
//     // public override bool Equals(object other) => other is IEnumeration && CompareTo(other) == 0;
//     public bool Equals(IEnumeration other) => GetHashCode() == other.GetHashCode();
//     public override int GetHashCode() => Id.GetHashCode();

//     public TypeCode GetTypeCode() => Convert.GetTypeCode(Value);

//     #region type conversions
//     /// <summary>
//     /// Converts the value of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent string representation.
//     /// </summary>
//     public object ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(Value, conversionType);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="bool"/> representation (if it exists).
//     /// </summary>
//     public bool ToBoolean(IFormatProvider? provider = null) => Convert.ToBoolean(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="byte"/> representation (if it exists).
//     /// </summary>
//     public byte ToByte(IFormatProvider? provider = null) => Convert.ToByte(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="char"/> representation (if it exists).
//     /// </summary>
//     public char ToChar(IFormatProvider? provider = null) => Convert.ToChar(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see cref="DateTime"/> representation (if it exists).
//     /// </summary>
//     public DateTime ToDateTime(IFormatProvider? provider = null) => Convert.ToDateTime(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="decimal"/> representation (if it exists).
//     /// </summary>
//     public decimal ToDecimal(IFormatProvider? provider = null) => Convert.ToDecimal(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="double"/> representation (if it exists).
//     /// </summary>
//     public double ToDouble(IFormatProvider? provider = null) => Convert.ToDouble(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="short"/> representation (if it exists).
//     /// </summary>
//     public short ToInt16(IFormatProvider? provider = null) => Convert.ToInt16(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="int"/> representation (if it exists).
//     /// </summary>
//     public int ToInt32(IFormatProvider? provider = null) => Convert.ToInt32(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="long"/> representation (if it exists).
//     /// </summary>
//     public long ToInt64(IFormatProvider? provider = null) => Convert.ToInt64(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="sbyte"/> representation (if it exists).
//     /// </summary>
//     public sbyte ToSByte(IFormatProvider? provider = null) => Convert.ToSByte(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="float"/> representation (if it exists).
//     /// </summary>
//     public float ToSingle(IFormatProvider? provider = null) => Convert.ToSingle(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="string"/> representation (if it exists).
//     /// </summary>
//     public string ToString(IFormatProvider? provider = null) => ToString();
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="ushort"/> representation (if it exists).
//     /// </summary>
//     public ushort ToUInt16(IFormatProvider? provider = null) => Convert.ToUInt16(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="uint"/> representation (if it exists).
//     /// </summary>
//     public uint ToUInt32(IFormatProvider? provider = null) => Convert.ToUInt32(Value, provider);
//     /// <summary>
//     /// Converts the <see cref="Value"/> of the current
//     /// <see cref="IEnumeration{TEnumeration, TId, TValue}"/> object to its
//     /// equivalent <see langword="ulong"/> representation (if it exists).
//     /// </summary>
//     public ulong ToUInt64(IFormatProvider? provider = null) => Convert.ToUInt64(Value, provider);
//     #endregion

//     // public static bool operator ==(Enumeration<TSelf, TId, TValue> e, Enumeration<TSelf, TId, TValue> o) => e.Equals(o);
//     // public static bool operator !=(Enumeration<TSelf, TId, TValue> e, Enumeration<TSelf, TId, TValue> o) => !e.Equals(o);

//     /// <summary>
//     /// Converts the <paramref name="t"/> to an object of type
//     /// <typeparamref name="TSelf"/>.
//     /// </summary>
//     public static IEnumeration? FromValue(Type t, object value) => Parse(t, x => x.Value.Equals(value));
//     /// <summary>
//     /// Converts the <paramref name="t"/> to an object of type
//     /// <typeparamref name="TSelf"/>.
//     /// </summary>
//     public static TEnumeration? FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration => FromValue(typeof(TEnumeration), value) as TEnumeration;
//     /// <summary>
//     /// Retrieves a list of values that are members of the enumeration.
//     /// </summary>
//     public static IEnumeration[] GetValues(Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
//     /// <summary>
//     /// Retrieves a list of values that are members of the enumeration.
//     /// </summary>
//     public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
//     /// <summary>
//     /// Retrieves a list of <see cref="PropertyInfo"/>s that can be used to
//     /// convert <see langword="string"/>s to the enumeration.
//     /// </summary>
//     private static IEnumerable<PropertyInfo> GetFromStringProperties(Type t)
//         => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);
//     /// <summary>
//     /// Retrieves a list of <see cref="PropertyInfo"/>s that can be used to
//     /// convert <see langword="string"/>s to the enumeration.
//     /// </summary>
//     private static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
//         => GetFromStringProperties(typeof(TEnumeration));
//     /// <summary>
//     /// Parses the <paramref name="value"/> to an object of type
//     /// <see cref="IEnumeration"/>.
//     /// </summary>
//     public static IEnumeration? Parse(Type t, string value) => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) as string == value));
//     /// <summary>
//     /// Parses the <paramref name="value"/> to an object of type
//     /// <typeparamref name="TEnumeration"/>.
//     /// </summary>
//     public static TEnumeration? Parse<TEnumeration>(string value) where TEnumeration : IEnumeration
//         => Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) as string == value));
//     public static TEnumeration? Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration
//         => GetValues<TEnumeration>().FirstOrDefault(matchPredicate);
//     public static IEnumeration? Parse(Type t, Func<IEnumeration, bool> matchPredicate)
//         => GetValues(t).FirstOrDefault(matchPredicate);
//     public static bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration
//         => (value = Parse<TEnumeration>(s) as TEnumeration) != null;

//     public bool Equals(IEnumeration<TSelf> other) => Equals(other as IEnumeration);
//     public int CompareTo(TValue other) => Value.CompareTo(other);
//     public bool Equals(TValue other) => Value.Equals(other);

// #if !NETSTANDARD2_0_OR_GREATER
//     // public static bool operator ==(EnumerationClass<TSelf, TId, TValue> a, EnumerationClass<TSelf, TId, TValue> b) => a.Equals(b);
//     // public static bool operator !=(EnumerationClass<TSelf, TId, TValue> a, EnumerationClass<TSelf, TId, TValue> b) => !a.Equals(b);
// #endif
// }
