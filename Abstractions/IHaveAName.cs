/* 
 * IHaveAName.cs
 * 
 *   Created: 2023-03-13-05:50:24
 *   Modified: 2023-03-29-12:11:32
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace Dgmjr.Abstractions;
using System.ComponentModel.DataAnnotations;

public interface IHaveAName
{
    [FromString]
    string Name { get; }
}

public interface IHaveAWritableName : IHaveAName
{
    [FromString]
    new string Name { get; set; }
}
