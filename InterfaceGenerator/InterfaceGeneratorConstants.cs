//
// Constants.cs
//
//   Created: 2022-11-11-04:00:23
//   Modified: 2022-11-12-11:24:45
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//


namespace Dgmjr.InterfaceGenerator
{
    using Microsoft.CodeAnalysis;

    // using Dgmjr.CodeGeneration.Extensions;
    public static class Constants
    {
        public const string AssemblyName = ThisAssembly.Info.Title;
        public const string AssemblyVersion = ThisAssembly.Info.Version;
        public const string GenerateInterfaceAttributeName = "GenerateInterfaceAttribute";
        public const string Header = $"""
    //----------------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by {AssemblyName} version {AssemblyVersion}
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //----------------------------------------------------------------------------------------
    """;

        public const string GenerateInterfaceAtributeDeclaration = $$$"""
    using System;

    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct)]
    internal sealed class {{{GenerateInterfaceAttributeName}}} : Attribute
    {
        public Type Type { get; }

        public {{{GenerateInterfaceAttributeName}}} (Type type = null)
        {
            {
                Type = type;
            }
        }
    }
    """;

        public const string InterfaceDeclaration =
            Header
            + """

    #nullable enable
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    namespace {{ namespace }}
    {
        public partial interface {{ interface_name }}
        {
            {{ members }}
        }
    }
    """;

        public static readonly Scriban.Template InterfaceDeclarationTemplate =
            Scriban.Template.Parse(InterfaceDeclaration);

        public const string MethodDeclaration = "{{ full_definition }};";

        public static readonly Scriban.Template MethodDeclarationTemplate = Scriban.Template.Parse(
            MethodDeclaration
        );

        public const string MethodParameter = """
    {{ type }} {{ name }}
    """;

        public static readonly Scriban.Template MethodParameterTemplate = Scriban.Template.Parse(
            MethodParameter
        );

        public const string PropertyDeclaration =
            "{{ type }} {{ if is_indexed }}this[ {{ indexers }}] {{ else }} {{ name }} {{ end }} { {{ if is_gettable }} get; {{ end }} {{ if is_settable }} set; {{ end }} }";

        public static readonly Scriban.Template PropertyDeclarationTemplate =
            Scriban.Template.Parse(PropertyDeclaration);

        // static Constants()
        // {
        //     if(!InterfaceDeclarationTemplate.HasErrors)
        //         throw new Exception(string.Join(Environment.NewLine, InterfaceDeclarationTemplate.Messages.Select(m => m.ToString())));
        // }

        public static readonly SymbolDisplayFormat SymbolDisplayFormat =
            new(
                SymbolDisplayGlobalNamespaceStyle.Included,
                SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
                SymbolDisplayGenericsOptions.IncludeTypeParameters
                    | SymbolDisplayGenericsOptions.IncludeVariance
                    | SymbolDisplayGenericsOptions.IncludeTypeConstraints,
                SymbolDisplayMemberOptions.IncludeConstantValue
                    | SymbolDisplayMemberOptions.IncludeExplicitInterface
                    | SymbolDisplayMemberOptions.IncludeModifiers
                    | SymbolDisplayMemberOptions.IncludeParameters
                    | SymbolDisplayMemberOptions.IncludeRef
                    | SymbolDisplayMemberOptions.IncludeType,
                SymbolDisplayDelegateStyle.NameAndSignature,
                SymbolDisplayExtensionMethodStyle.Default,
                SymbolDisplayParameterOptions.IncludeExtensionThis
                    | SymbolDisplayParameterOptions.IncludeName
                    | SymbolDisplayParameterOptions.IncludeParamsRefOut
                    | SymbolDisplayParameterOptions.IncludeType
                    | SymbolDisplayParameterOptions.IncludeType
                    | SymbolDisplayParameterOptions.IncludeDefaultValue
                    | SymbolDisplayParameterOptions.IncludeOptionalBrackets,
                SymbolDisplayPropertyStyle.ShowReadWriteDescriptor,
                miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes
                    | SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers
                    | SymbolDisplayMiscellaneousOptions.UseAsterisksInMultiDimensionalArrays
                    | SymbolDisplayMiscellaneousOptions.UseErrorTypeSymbolName
                    | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier
                    | SymbolDisplayMiscellaneousOptions.IncludeNotNullableReferenceTypeModifier
            );
    }

    public record struct InterfaceGeneratorModel(
        string Namespace,
        string InterfaceName,
        string Members,
        string TypeParameters,
        string TypeConstraints
    );

    // public record struct MethodDeclarationModel(
    //     string ReturnType,
    //     string MethodName,
    //     string Parameters,
    //     string TypeConstraints,
    //     string FullDefinition
    // );

    // public record struct MethodParameterModel(string Type, string Name);

    // public record struct PropertyDeclarationModel(
    //     string visibility,
    //     string Type,
    //     string Name,
    //     bool IsGettable,
    //     bool IsSettable,
    //     string? Indexers = null
    // )
    // {
    //     public bool IsIndexed => !string.IsNullOrWhiteSpace(Indexers);

    //     public string Name { get; } =
    //         (!string.IsNullOrWhiteSpace(Indexers) ? $"this[{Indexers}]" : Name);
    // }

    public static class Environment
    {
        public const string NewLine = "\r\n";
    }
}
