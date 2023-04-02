/*
 * IEnumeration{TSelf}.cs
 *
 *   Created: 2022-12-23-12:08:46
 *   Modified: 2022-12-23-12:08:46
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Enumerations.Abstractions;

public interface IEnumeration<TSelf> : IEnumeration
    where TSelf : IEnumeration<TSelf>
{
    //TValue Value { get; }
    //DisplayAttribute? DisplayAttribute { get; }
#if NET6_0_OR_GREATER
            public static virtual IEnumerable<TSelf> GetAll() => EnumerationHelpers.GetValues<TSelf>();
#endif
}

public static class EnumerationHelpers
{
    public static IEnumeration[] GetValues(Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
    /// <summary>
    /// Retrieves a list of values that are members of the enumeration.
    /// </summary>
    public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
}
