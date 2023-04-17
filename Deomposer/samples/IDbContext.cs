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

namespace Microsoft.EntityFrameworkCore.Abstractions
{
    [Decompose(typeof(DbContext))]
    public partial interface IDbContext
    {

    }
}
