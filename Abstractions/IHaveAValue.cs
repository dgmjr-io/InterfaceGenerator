/* 
 * IHaveAValue.cs
 * 
 *   Created: 2023-03-13-05:50:24
 *   Modified: 2023-03-29-12:11:57
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 

namespace Dgmjr.Abstractions;

public interface IHaveAValue
{
    object Value { get; }
}

public interface IHaveAWritableValue : IHaveAValue
{
    new object Value { get; set; }
}
