//
// IEnumeration.cs
//
//   Created: 2022-11-02-01:22:22
//   Modified: 2022-11-02-01:22:22
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace Dgmjr.Enumerations.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Dgmjr.Abstractions;
public interface IEnumeration : IConvertible, IComparable, IHaveAValue, IHaveAName, IHaveADescription, IIdentifiable
{
    FieldInfo? FieldInfo { get; }//=> GetType().GetField(Name);
    [FromString]
    string DisplayName { get; }//=> Name;
    [FromString]
    string ShortName { get; }// => Name;
    string GroupName { get; }// => NoGroup;
    int Order { get; }// => DefaultOrder;
    TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute;
}
