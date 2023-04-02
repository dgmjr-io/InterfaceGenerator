//
// IEnumeration.cs
//
//   Created: 2022-10-16-12:16:22
//   Modified: 2022-10-31-01:44:39
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Enumerations.Abstractions;
using Dgmjr.Abstractions;

public interface IEnumeration<TSelf, TId, TValue> : IEnumeration<TSelf>, IIdentifiable<TId>
    where TValue : IComparable<TValue>, IEquatable<TValue>
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
    where TSelf : IEnumeration<TSelf, TId, TValue>
{
    //TValue Value { get; }
    //DisplayAttribute? DisplayAttribute { get; }
}
