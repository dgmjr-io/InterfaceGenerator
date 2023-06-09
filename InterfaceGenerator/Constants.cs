// //
// // Constants.cs
// //
// //   Created: 2022-11-11-04:00:23
// //   Modified: 2022-11-12-11:24:45
// //
// //   Author: David G. Mooore, Jr. <david@dgmjr.io>
// //
// //   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
// //      License: MIT (https://opensource.org/licenses/MIT)
// //


// namespace Dgmjr.InterfaceGenerator;

// using System.ComponentModel;

// // using Dgmjr.CodeGeneration.Extensions;
// public static class Constants
// {
//     public const string GenerateInterfaceAttributeName = "GenerateInterfaceAttribute";
//     public const string GenerateInterfaceAtributeDeclaration =
//     """
//     using System;

//     [AttributeUsage(AttributeTargets.Interface)]
//     internal sealed class GenerateInterfaceAttribute : Attribute
//     {
//         public Type Type { get; }

//         public GenerateInterfaceAttribute (Type type = null)
//         {
//             {
//                 Type = type;
//             }
//         }
//     }
//     """;

//     public const string InterfaceDeclaration =
//     Header +
//     """

//     #nullable enable
//     using System;
//     using System.Collections.Generic;
//     using System.Linq;
//     using System.Reflection;
//     using System.Runtime.CompilerServices;
//     using System.Threading.Tasks;

//     namespace {{ namespace }}
//     {
//         public partial interface {{ interface_name }}
//         {
//             {{ members }}
//         }
//     }
//     """;

//     public static readonly Scriban.Template InterfaceDeclarationTemplate = Scriban.Template.Parse(InterfaceDeclaration);

//     public const string MethodDeclaration =
//     """
//     {{ return_type }} {{ method_name }}({{ parameters }}) {{ type_constraints }};
//     """;

//     public static readonly Scriban.Template MethodDeclarationTemplate = Scriban.Template.Parse(MethodDeclaration);

//     public const string MethodParameter =
//     """
//     {{ type }} {{ name }}
//     """;

//     public static readonly Scriban.Template MethodParameterTemplate = Scriban.Template.Parse(MethodParameter);

//     public const string PropertyDeclaration =
//     """
//     {{ type }} {{ name }} { {{~ if is_gettable ~}} get; {{~ end ~}} {{~ if is_settable ~}} set; {{~ end ~}} }
//     """;

//     public static readonly Scriban.Template PropertyDeclarationTemplate = Scriban.Template.Parse(PropertyDeclaration);

//     // static Constants()
//     // {
//     //     if(!InterfaceDeclarationTemplate.HasErrors)
//     //         throw new Exception(string.Join(Environment.NewLine, InterfaceDeclarationTemplate.Messages.Select(m => m.ToString())));
//     // }
// }

// public record struct InterfaceGeneratorModel(string Namespace, string InterfaceName, string Members);

// // public record struct MethodDeclarationModel(string ReturnType, string MethodName, string Parameters, string TypeConstraints);

// // public record struct MethodParameterModel(string Type, string Name);

// // public record struct PropertyDeclarationModel(string visibility, string Type, string Name, bool IsGettable, bool IsSettable);
