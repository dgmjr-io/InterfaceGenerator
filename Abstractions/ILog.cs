/* 
 * ILog.cs
 * 
 *   Created: 2023-03-13-05:50:24
 *   Modified: 2023-03-29-12:12:30
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

using Microsoft.Extensions.Logging;

namespace Dgmjr.Abstractions;

/// <summary>
/// Marker interface for a class that has a reference to an
/// <see cref="ILogger"/>.
/// </summary>
public interface ILog
{
    ILogger Logger { get; }
}
