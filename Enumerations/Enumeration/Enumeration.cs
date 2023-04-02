//
// Enumeration.cs
//
//   Created: 2022-11-05-08:45:07
//   Modified: 2022-11-05-08:45:08
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace Dgmjr.Enumerations;

public static class Enumeration
{
    public const int DefaultOrder = 0;
    public const string NoGroup = "No Group";

    public static FieldInfo? GetFieldInfo(this Type t, string name) => t.GetRuntimeField(name);
    public static IEnumeration? FromValue(Type t, object value) => Parse(t, x => x.Value.Equals(value));
    public static TEnumeration? FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration => FromValue(typeof(TEnumeration), value) as TEnumeration;
    public static IEnumeration[] GetValues(this Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
    public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
    public static IEnumerable<PropertyInfo> GetFromStringProperties(this Type t)
        => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);
    public static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
        => GetFromStringProperties(typeof(TEnumeration));
    public static IEnumeration? Parse(Type t, string value) => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) as string == value));
    public static TEnumeration? Parse<TEnumeration>(string value) where TEnumeration : IEnumeration
        => Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) as string == value));
    public static TEnumeration? Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration
        => GetValues<TEnumeration>().FirstOrDefault(matchPredicate);
    public static IEnumeration? Parse(Type t, Func<IEnumeration, bool> matchPredicate)
        => GetValues(t).FirstOrDefault(matchPredicate);
    public static bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration
        => (value = Parse<TEnumeration>(s) as TEnumeration) != null;
}
