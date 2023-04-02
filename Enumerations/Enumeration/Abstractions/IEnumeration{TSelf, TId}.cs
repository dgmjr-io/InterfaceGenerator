//
// IEnumeration<TId>.cs
//
//   Created: 2022-11-02-03:46:21
//   Modified: 2022-11-02-03:46:21
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace Dgmjr.Enumerations.Abstractions;

public interface IEnumeration<TSelf, TId> : IEnumeration<TSelf>
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
    where TSelf : IEnumeration<TSelf, TId>
{
    //string Name { get; }
}
