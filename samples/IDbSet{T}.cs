/*
 * IDbSet{T}.cs
 *
 *   Created: 2023-05-06-03:37:21
 *   Modified: 2023-05-06-03:37:37
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.EntityFrameworkCore;

namespace Microsoft.EntityFrameworkCore.Abstractions;

[GenerateInterface(typeof(DbSet<>))]
public partial interface IDbSet<TEntity> { }
