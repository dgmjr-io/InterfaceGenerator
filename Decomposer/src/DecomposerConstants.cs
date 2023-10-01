using System.Linq;
/*
 * DecomposerConstants.cs
 *
 *   Created: 2023-04-13-12:23:57
 *   Modified: 2023-04-13-12:23:57
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dgmjr.InterfaceGenerator.Decomposer
{
    internal static class Constants
    {
        public const string ThisAssemblyName = ThisAssembly.Project.AssemblyName;
        public const string ThisAssemblyVersion = ThisAssembly.Info.Version;
        public const string DecomposedInterfaceHeader = $$$"""
        //----------------------------------------------------------------------------------------
        // <auto-generated>
        //     This code was generated by {{{ThisAssemblyName}}}, version {{{ThisAssemblyVersion}}}
        //
        //     Changes to this file may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //----------------------------------------------------------------------------------------

        """;

        public static readonly AttributeListSyntax GeneratedCodeAttributesSyntax =
            SyntaxFactory.AttributeList(
                SyntaxFactory.SeparatedList(
                    SyntaxFactory
                        .ParseCompilationUnit(GeneratedCodeAttributes)
                        .DescendantNodesAndSelf(_ => true, false)
                        .SelectMany(node => node.ChildNodes())
                        .OfType<AttributeSyntax>()
                )
            );

        public const string GeneratedCodeAttributes = $$$"""
        [System.Runtime.CompilerServices.CompilerGenerated]
        [System.CodeDom.Compiler.GeneratedCode(\"{{{ThisAssemblyName}}}\", \"{{{ThisAssemblyVersion}}}\")]";
        """;

        public const string DecomposableAttributeName = "DecomposableAttribute";
        public const string DecomposableAttributeNamespace = "Dgmjr.InterfaceGenerator.Decomposer";
        public const string DecomposableAttributeFullName =
            DecomposableAttributeNamespace + "." + DecomposableAttributeName;

        public const string IDecomposedInterfaceDeclaration =
            DecomposedInterfaceHeader
            + GeneratedCodeAttributes
            + "public interface IDecomposedFrom<{{ decomposed_from }}> { }";

        public const string IDecomposedMarkerInterfaceDeclaration =
            DecomposedInterfaceHeader
            + GeneratedCodeAttributes
            + "                public interface I{{ decomposed_from }}{{ memeber_name }}\r\n                {";

        public const string DecomposedPropertyDeclaration =
            GeneratedCodeAttributes
            + """
            {{ property_type
    }
}
{ { property_name } }
{ { { if is_gettable } } get; { { end } } { { if is_settable } } set; { { end } } }
{ { { if is_gettable } } get; { { end } } { { if is_settable } } set; { { end } } }
""";

        public const string DecomposedMethodDeclaration =
            GeneratedCodeAttributes
            + """
            { { return_type } }
{ { method_name } } ({ { for parameter in parameters } }
{ { parameter.type } }
{ { parameter.name } }
{ { if not loop.last } }, { { endif } }
{ { endfor } })
                        { { if has_generic_type_constraints } }
{ { for generic_type_constraint in generic_type_constraints } }
where
{ { generic_type_constraint.name } } : { { type_constraint.constraint } }
{ { endfor } }
{ { endif } }
""";

        public const string DecomposableAttributeFilename = "DecomposableAttribute.g.cs";

public const string DecomposableAttributeDeclaration =
    DecomposedInterfaceHeader
    + """
[global::System.AttributeUsage(global::System.AttributeTargets.Class | global::System.AttributeTargets.Struct | global::System.AttributeTargets.Interface | global::System.AttributeTargets.Assembly)]
        public sealed class DecomposeAttribute : global::System.Attribute
{
    public DecomposeAttribute(string @namespace = null) { }
    public DecomposeAttribute(global::System.Type type, string @namespace = null) { }
}
""";

        public const string IComposedClassDeclaration = """
        public partial class {{ class_name }} : { { for type_member_tuple in decomposed_from } }
IDecomposed <{ { decomposed_from.type } }>
                {
    { { for type_member_tuple in decomposed_from } }
    { { if type_member_tuple.member.is_property } }
                    public
{ { ~type_member_tuple.member.type } }
{ { ~type_member_tuple.member.name } }
{ { get; } }
{ { elif type_member_tuple.member.is_method } }
public
{ { decomposed_from.type } }
{ { decomposed_from.member } }
{ { get; } }
{ { endfor } }


public
{ { class_name } } ({ decomposed_from }
decomposed)
                    {
    { decomposed_from } = decomposed;
}

public
{ decomposed_from }
{ decomposed_from }
{ { get; } }
        }
        """;

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

internal const string AttributeName = "Decompose";
internal const string AttributeFullName = AttributeName + nameof(Attribute);
internal const string InterfaceNamePrefix = "I";
internal const string InterfaceSuffix = "Decomposition";
internal const string NamespaceSuffix = ".Decompositions";
internal const string SourceFileNameSuffix = ".Decompositions.g.cs";
internal const string GeneratedCodeAttributeName = "GeneratedCodeAttribute";
internal const string GeneratedCodeAttributeFullName =
    $"System.Diagnostics.CodeAnalysis.{GeneratedCodeAttributeName}";
internal const string CompilerGeneratedAttributeFullName =
    "System.Runtime.CompilerServices.CompilerGeneratedAttribute";
    }
}
