/*
 * IDbContext.cs
 *
 *   Created: 2023-04-16-02:10:19
 *   Modified: 2023-04-16-02:10:20
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
using Microsoft.EntityFrameworkCore;

[assembly: Decompose(typeof(DbContext))]

namespace Microsoft.EntityFrameworkCore.Abstractions
{
    public partial interface IDbContext { }
}
