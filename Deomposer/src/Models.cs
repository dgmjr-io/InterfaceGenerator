// /* 
//  * Models.cs
//  * 
//  *   Created: 2023-04-08-03:02:41
//  *   Modified: 2023-04-08-03:02:41
//  * 
//  *   Author: David G. Moore, Jr. <david@dgmjr.io>
//  *   
//  *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// using System.Text;
// using Microsoft.CodeAnalysis;

// namespace Dgmjr.InterfaceGenerator.Models
// {
//     public record struct InterfaceGeneratorModel(string Namespace, string InterfaceName, IDictionary<string, IEnumerable<MethodDeclarationModel>>? Methods, IDictionary<string, PropertyDeclarationModel>? Properties, IDictionary<string, TypeConstraintModel>? TypeConstraints)
//     {
//         public readonly string GetInterfaceDeclaration()
//         {
//             System.Console.WriteLine("A");
//             StringBuilder sb = new();
//             _ = sb.AppendLine($"namespace {Namespace}");
//             _ = sb.AppendLine("{");
//             _ = sb.AppendLine($"    public interface {InterfaceName}");
//             _ = sb.AppendLine("    {");
//             System.Console.WriteLine("B");
//             foreach (KeyValuePair<string, IEnumerable<MethodDeclarationModel>>? methods in Methods?.Select(v => (KeyValuePair<string, IEnumerable<MethodDeclarationModel>>?)v))
//             {
//                 foreach (MethodDeclarationModel methodDeclaration in methods?.Value)
//                 {
//                     _ = sb.AppendLine($"{methods?.Key}        {methodDeclaration.GetMethodDeclaration()}");
//                 }
//             }
//             System.Console.WriteLine("C");
//             foreach (KeyValuePair<string, PropertyDeclarationModel>? property in Properties.Select(v => (KeyValuePair<string, PropertyDeclarationModel>?)v))
//             {
//                 _ = sb.AppendLine($"{property?.Key}        {property?.Value.GetPropertyDeclaration()}");
//             }
//             _ = sb.AppendLine("    }");
//             _ = sb.AppendLine("}");
//             return sb.ToString();
//         }
//     }
//     public record struct MethodDeclarationModel(ITypeSymbol ReturnType, IMethodSymbol Method, MethodParameterModel[]? Parameters, TypeConstraintModel TypeConstraints)
//     {
//         public readonly string GetMethodDeclaration()
//         {
//             StringBuilder sb = new();
//             _ = sb.Append($"{ReturnType} {Method?.Name}(");
//             foreach (MethodParameterModel parameter in Parameters)
//             {
//                 _ = sb.Append($"{parameter.GetParameterDeclaration()}, ");
//             }
//             _ = sb.Remove(sb.Length - 2, 2);
//             _ = sb.Append(")");
//             if (TypeConstraints.Constraints.Length > 0)
//             {
//                 _ = sb.Append($" where {TypeConstraints.Type} : {Join(", ", TypeConstraints.Constraints ?? Empty<string>())}");
//             }
//             _ = sb.Append(";");
//             return sb.ToString();
//         }
//     }
//     public record struct TypeConstraintModel(string Type, string[] Constraints, ITypeParameterSymbol TypeParameterSymbol)
//     {
//         var constraints = new StringBuilder();
//         if(
//     }

//     public record struct MethodParameterModel(string Type, string Name)
//     {
//         public readonly string GetParameterDeclaration()
//         {
//             return $"{Type} {Name}";
//         }
//     }
//     public record struct PropertyDeclarationModel(string Visibility, string Type, string Name, bool IsGettable, bool IsSettable)
//     {
//         public readonly string GetPropertyDeclaration()
//         {
//             StringBuilder sb = new();
//             _ = sb.Append($"{Visibility} {Type} {Name} {{ ");
//             if (IsGettable)
//             {
//                 _ = sb.Append("get; ");
//             }
//             if (IsSettable)
//             {
//                 _ = sb.Append("set; ");
//             }
//             _ = sb.Remove(sb.Length - 1, 1);
//             _ = sb.Append(" }");
//             return sb.ToString();
//         }
//     }
// }
