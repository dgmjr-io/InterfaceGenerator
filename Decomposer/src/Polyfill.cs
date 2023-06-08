/*
 * Polyfill.cs
 *
 *   Created: 2023-05-13-11:04:22
 *   Modified: 2023-05-13-11:04:22
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.InterfaceGenerator.Decomposer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using SourceHash = System.Int64;

public static class Polyfills
{
    /// <summary>
    /// This function creates a typed constant based on the given type and value.
    /// </summary>
    /// <param name="type">An interface representing a type symbol in the Roslyn compiler API. It
    /// provides information about a type, such as its name, base type, and members.</param>
    /// <param name="value">The value to be converted into a TypedConstant object.</param>
    /// <returns>
    /// A `TypedConstant` object is being returned.
    /// </returns>
    // public static TypedConstant Create(this ITypeSymbol type, object value)
    // {
    //     switch (type.SpecialType)
    //     {
    //         case SpecialType.System_Boolean:
    //             return TypedConstant.Create(value is bool ? value : false);
    //         case SpecialType.System_Char:
    //             return TypedConstant.Create((char)value);
    //         case SpecialType.System_String:
    //             return TypedConstant.Create(value is string ? value : string.Empty);
    //         case SpecialType.System_Int32:
    //             return TypedConstant.Create(value is int ? value : 0);
    //         // Add more cases for other types as needed...
    //         default:
    //             throw new ArgumentException($"Invalid type: {type.Name}");
    //     }
    // }
}
