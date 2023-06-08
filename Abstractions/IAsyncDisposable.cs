/*
 * IAsyncDisposable.cs
 *
 *   Created: 2023-05-23-02:32:41
 *   Modified: 2023-05-23-02:32:41
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


using System;
using System.Threading.Tasks;

public interface IAsyncDisposable : IDisposable
{
#if NETSTANDARD2_1_OR_GREATER
    ValueTask DisposeAsync();
#else
    Task DisposeAsync();
#endif
}
