/* 
 * EnumValueAttribute.cs
 * 
 *   Created: 2023-04-01-03:29:38
 *   Modified: 2023-04-01-03:29:38
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace System.ComponentModel.DataAnnotations;

public class EnumValueAttribute : Attribute
{
    public string Value { get; }

    public EnumValueAttribute(string value)
    {
        Value = value;
    }
}
