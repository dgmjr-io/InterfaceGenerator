/* 
 * IIdentifiable.cs
 * 
 *   Created: 2023-03-13-05:50:24
 *   Modified: 2023-03-29-12:12:20
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace Dgmjr.Abstractions;

/// <summary>
/// Marker interface for an object or struct that has a *read-only*
/// <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IIdentifiable
{
    object Id { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read-only*
/// <c><see cref="Id">Id</see></c> property of type <typeparamref name="TId"/>.
/// </summary>
public interface IIdentifiable<TId> where TId : IComparable, IEquatable<TId>
{
    TId Id { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read/write*
/// <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAWritableId : IIdentifiable
{
    new object Id { get; set; }
}


/// <summary>
/// Marker interface for an object or struct that has a *read/write*
/// <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAWritableId<TId> : IIdentifiable<TId> where TId : IComparable, IEquatable<TId>
{
    new TId Id { get; set; }
}
