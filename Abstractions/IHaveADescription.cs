/* 
 * IHaveADescription.cs
 * 
 *   Created: 2023-03-13-05:50:24
 *   Modified: 2023-03-29-12:11:23
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace Dgmjr.Abstractions;

/// <summary>
/// Marker interface for an object or struct that has a *read-only*
/// <c><see cref="Description">Description</see></c> property.
/// </summary>
public interface IHaveADescription
{
    /// <summary>
    /// The thing's description
    /// </summary>
    string Description { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read/write*
/// <c><see cref="Description">Description</see></c> property.
/// </summary>
public interface IHaveAWritableDescription : IHaveADescription
{
    new string Description { get; set; }
}


//public interface IHaveAReadWriteDescription : IHaveADescription, IHaveAWritableDescription { }
