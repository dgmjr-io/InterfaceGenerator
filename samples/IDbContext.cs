/*
 * IDbContext.cs
 *
 *   Created: 2022-12-30-11:57:22
 *   Modified: 2022-12-30-11:57:25
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
using Microsoft.EntityFrameworkCore;
namespace Microsoft.EntityFrameworkCore.Abstractions;

[GenerateInterfaceAttribute(typeof(DbContext))]
public partial interface IDbContext
{

}
