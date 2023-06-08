using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using SourceHash = System.Collections.Immutable.ImmutableArray<byte>;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Dgmjr.InterfaceGenerator.Decomposer;

[Generator]
public class Decomposer : ISourceGenerator, IIncrementalGenerator
{
    private const string AttributeName = "Decompose";
    private const string InterfaceNamePrefix = "I";
    private const string InterfaceSuffix = "Decomposition";
    private const string NamespaceSuffix = ".Decompositions";
    private const string SourceFileNameSuffix = ".Decompositions.g.cs";
    private const string GeneratedCodeAttributeName = "GeneratedCodeAttribute";
    private const string GeneratedCodeAttributeFullName =
        $"System.Diagnostics.CodeAnalysis.{GeneratedCodeAttributeName}";
    private const string CompilerGeneratedAttributeFullName =
        "System.Runtime.CompilerServices.CompilerGeneratedAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(
            ctx =>
                ctx.AddSource(
                    Constants.DecomposableAttributeFilename,
                    Constants.DecomposableAttributeDeclaration
                )
        );
    }

    public void Initialize(GeneratorInitializationContext context) { }

    public void Execute(GeneratorExecutionContext context)
    {
        var syntaxTrees = context.Compilation.SyntaxTrees;
        var attributeSymbol = context.Compilation.GetTypeByMetadataName(AttributeName);

        foreach (var syntaxTree in syntaxTrees)
        {
            var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
            var root = syntaxTree.GetRoot();
            var attributeSyntaxes = root.DescendantNodes()
                .OfType<AttributeSyntax>()
                .Where(
                    attr =>
                        semanticModel.GetSymbolInfo(attr).Symbol?.Equals(attributeSymbol) == true
                );

            foreach (var attributeSyntax in attributeSyntaxes)
            {
                var targetSymbol = semanticModel.GetSymbolInfo(attributeSyntax.Parent).Symbol;
                if (targetSymbol == null)
                {
                    continue;
                }

                var targetNamespace = targetSymbol.ContainingNamespace.ToDisplayString();
                var targetAssemblyName = targetSymbol.ContainingAssembly.Name;
                var interfaceName = InterfaceNamePrefix + targetSymbol.Name + InterfaceSuffix;
                var namespaceName = targetNamespace + NamespaceSuffix;
                var sourceFileName = targetSymbol.Name + SourceFileNameSuffix;

                var interfaceDeclaration = SyntaxFactory
                    .InterfaceDeclaration(interfaceName)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddBaseListTypes(
                        SyntaxFactory.SimpleBaseType(
                            SyntaxFactory.ParseTypeName(
                                $"IDecompose<{targetSymbol.ToDisplayString()}>"
                            )
                        )
                    );

                var members = (targetSymbol as INamedTypeSymbol)!
                    .GetMembers()
                    .Where(m => m.Kind == SymbolKind.Method || m.Kind == SymbolKind.Property)
                    .Where(m => m.DeclaredAccessibility == Accessibility.Public)
                    .Where(
                        m =>
                            !(
                                m is IPropertySymbol property
                                && (
                                    property.IsIndexer
                                    || property.IsReadOnly
                                    || property.IsWriteOnly
                                )
                            )
                    )
                    .ToList();

                var generatedCoeAttributeLists = SyntaxFactory.SeparatedList(
                    new[]
                    {
                        SyntaxFactory.AttributeList(
                            SyntaxFactory.SeparatedList(
                                new[]
                                {
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.ParseName(GeneratedCodeAttributeFullName),
                                        SyntaxFactory.AttributeArgumentList(
                                            SyntaxFactory.SeparatedList(
                                                new[]
                                                {
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            SyntaxFactory.Literal(
                                                                ThisAssembly.Info.Title
                                                            )
                                                        )
                                                    ),
                                                    SyntaxFactory.AttributeArgument(
                                                        SyntaxFactory.LiteralExpression(
                                                            SyntaxKind.StringLiteralExpression,
                                                            SyntaxFactory.Literal(
                                                                ThisAssembly.Info.Version
                                                            )
                                                        )
                                                    )
                                                }
                                            )
                                        )
                                    ),
                                    SyntaxFactory.Attribute(
                                        SyntaxFactory.ParseName(CompilerGeneratedAttributeFullName)
                                    )
                                }
                            )
                        )
                    }
                );

                var interfaceDeclarationSyntaxTrees = new DefaultableDictionary<
                    string,
                    IList<InterfaceDeclarationSyntax>
                >(new List<InterfaceDeclarationSyntax>());

                foreach (var member in members)
                {
                    var memberType = member switch
                    {
                        IMethodSymbol method => method.ReturnType,
                        IPropertySymbol property => property.Type,
                        _
                            => throw new InvalidOperationException(
                                $"Unexpected member kind: {member.Kind}"
                            ),
                    };
                    var memberName = member.Name;

                    if (
                        member is IPropertySymbol p
                        && p.DeclaredAccessibility == Accessibility.Public
                    )
                    {
                        interfaceDeclarationSyntaxTrees[p.Name].Add(
                            SyntaxFactory
                                .InterfaceDeclaration($"I{targetSymbol.Name}{member.Name}")
                                .WithMembers(
                                    SyntaxFactory.List(
                                        CSharpSyntaxTree
                                            .ParseText(
                                                p.ToDisplayString(Constants.SymbolDisplayFormat)
                                            )
                                            .GetRoot()
                                            .DescendantNodes()
                                            .OfType<MemberDeclarationSyntax>()
                                    )
                                )
                        );
                    }
                    else if (
                        member is IMethodSymbol meth
                        && meth.CanBeReferencedByName
                        && meth.DeclaredAccessibility == Accessibility.Public
                    )
                    {
                        var methodSyntax = CSharpSyntaxTree.ParseText(
                            meth.ToDisplayString(Constants.SymbolDisplayFormat)
                        );
                        var methodSyntaxString = methodSyntax.ToString();
                        if (!methodSyntaxString.Contains("*"))
                        {
                            interfaceDeclarationSyntaxTrees[meth.Name].Add(
                                SyntaxFactory
                                    .InterfaceDeclaration($"I{targetSymbol.Name}{member.Name}")
                                    .WithMembers(
                                        SyntaxFactory.List(
                                            methodSyntax
                                                .GetRoot()
                                                .DescendantNodes()
                                                .OfType<MemberDeclarationSyntax>()
                                        )
                                    )
                            );
                        }
                    }
                }

                var memberInterfaceDeclarations = interfaceDeclarationSyntaxTrees.SelectMany(
                    itsts => itsts.Value
                );
                var baseNamespaceDeclarationSyntax = SyntaxFactory.NamespaceDeclaration(
                    SyntaxFactory.ParseName(namespaceName),
                    SyntaxFactory.List<ExternAliasDirectiveSyntax>(),
                    SyntaxFactory.List<UsingDirectiveSyntax>(),
                    SyntaxFactory.List(
                        memberInterfaceDeclarations.OfType<MemberDeclarationSyntax>()
                    )
                );

                context.AddSource(
                    sourceFileName,
                    baseNamespaceDeclarationSyntax.NormalizeWhitespace().ToFullString()
                );
            }
        }
    }

    private record AdditionalTextFile(string Path, TextLoader TextLoader, SourceHash Checksum);
}



// using System.Collections.Immutable;
// using Dgmjr.InterfaceGenerator.Decomposer.Models;
// using Microsoft.CodeAnalysis;
// using Microsoft.CodeAnalysis.CSharp;
// using Microsoft.CodeAnalysis.CSharp.Syntax;
// using static Dgmjr.InterfaceGenerator.Decomposer.Constants;
// using OneOf;

// namespace Dgmjr.InterfaceGenerator.Decomposer
// {
//     [Generator]
//     public class DecomposableGenerator : IIncrementalGenerator
//     {
//         public void Initialize(IncrementalGeneratorInitializationContext context)
//         {
//             context.RegisterPostInitializationOutput(
//                 ctx =>
//                     ctx.AddSource(
//                         DecomposableAttributeName + ".g.cs",
//                         DecomposableAttributeDeclaration
//                     )
//             );

//             var decomposedTypes = context.SyntaxProvider
//                 .ForAttributeWithMetadataName(
//                     DecomposableAttributeName,
//                     (n, _) => IsEligibleType(n, _),
//                     (generatorAttributeSyntaxContext, _) =>
//                         (
//                             generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax,
//                             generatorAttributeSyntaxContext.TargetSymbol
//                                 as OneOf<INamedTypeSymbol, IAttributeSymbol>
//                         )
//                 )
//                 .Collect();

//             // fullyQualifiedMetadataName: DecomposableAttributeName,
//             //     (node, _) => IsEligibleType((node, (node as TypeDeclarationSyntax).SemanticModel), _),
//             //     generatorAttributeSyntaxContext =>
//             //         (ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel),
//             //         ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel).TargetSymbol as INamedTypeSymbol,
//             //         (ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel).TargetNode as TypeDeclarationSyntax).Members.OfType<MethodDeclarationSyntax>().ToImmutableArray(),
//             //         (ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel).TargetNode as TypeDeclarationSyntax).Members.OfType<PropertyDeclarationSyntax>().ToImmutableArray()
//             //     )).Collect();


//             var decomposedMembers = context.SyntaxProvider
//                 .ForAttributeWithMetadataName(
//                     DecomposableAttributeName,
//                     t => IsEligibleMember(t, context.Compilation),
//                     (generatorAttributeSyntaxContext, _) =>
//                         (
//                             generatorAttributeSyntaxContext.TargetSymbol.ContainingType.DeclaringSyntaxReferences
//                                 .FirstOrDefault()
//                                 ?.GetSyntax() as TypeDeclarationSyntax,
//                             generatorAttributeSyntaxContext
//                                 .TargetSymbol
//                                 .ContainingType
//                                 .ContainingSymbol as INamedTypeSymbol,
//                             new[]
//                             {
//                                 generatorAttributeSyntaxContext.TargetNode
//                                     as MethodDeclarationSyntax
//                             }.ToImmutableArray(),
//                             new[]
//                             {
//                                 generatorAttributeSyntaxContext.TargetNode
//                                     as PropertyDeclarationSyntax
//                             }.ToImmutableArray()
//                         )
//                 )
//                 .Collect();

//             context.RegisterSourceOutput(decomposedTypes, Generate);
//             context.RegisterSourceOutput(decomposedMembers, Generate);
//         }

//         public void GenerateInterfaceForType(
//             GeneratorExecutionContext context,
//             INamedTypeSymbol typeSymbol
//         )
//         {
//             var typeAttributes = typeSymbol.GetAttributes();
//             var generateInterfaceAttribute = typeAttributes.FirstOrDefault(
//                 a =>
//                     a.AttributeClass?.ToDisplayString()
//                     == "GenerateInterface.GenerateInterfaceAttribute"
//             );

//             if (generateInterfaceAttribute != null)
//             {
//                 var isPartial = typeSymbol.IsPartial();
//                 if (!isPartial)
//                 {
//                     context.ReportDiagnostic(
//                         Diagnostic.Create(
//                             InvalidPartialInterfaceRule,
//                             typeSymbol.Locations[0],
//                             typeSymbol.Name
//                         )
//                     );
//                     return;
//                 }

//                 var typeParameter =
//                     generateInterfaceAttribute.ConstructorArguments.FirstOrDefault();
//                 if (typeParameter.Value is INamedTypeSymbol parameterTypeSymbol)
//                 {
//                     typeSymbol = parameterTypeSymbol;
//                 }

//                 var interfaceName = $"{typeSymbol.Name}Interface";
//                 var interfaceNamespace = typeSymbol.ContainingNamespace.ToDisplayString();

//                 var syntaxFactory = SyntaxFactory
//                     .CompilationUnit()
//                     .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")));

//                 var interfaceDeclaration = SyntaxFactory
//                     .InterfaceDeclaration(interfaceName)
//                     .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

//                 var members = typeSymbol.GetMembers();
//                 foreach (var member in members)
//                 {
//                     if (member is IMethodSymbol method)
//                     {
//                         var methodDeclaration = SyntaxFactory
//                             .MethodDeclaration(
//                                 SyntaxFactory.ParseTypeName(method.ReturnType.ToDisplayString()),
//                                 SyntaxFactory.Identifier(method.Name)
//                             )
//                             .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
//                             .WithParameterList(
//                                 SyntaxFactory.ParameterList(
//                                     SyntaxFactory.SeparatedList(
//                                         method.Parameters.Select(
//                                             p =>
//                                                 SyntaxFactory
//                                                     .Parameter(SyntaxFactory.Identifier(p.Name))
//                                                     .WithType(
//                                                         SyntaxFactory.ParseTypeName(
//                                                             p.Type.ToDisplayString()
//                                                         )
//                                                     )
//                                         )
//                                     )
//                                 )
//                             )
//                             .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

//                         interfaceDeclaration = interfaceDeclaration.AddMembers(methodDeclaration);
//                     }
//                     else if (member is IPropertySymbol property)
//                     {
//                         var propertyDeclaration = SyntaxFactory
//                             .PropertyDeclaration(
//                                 SyntaxFactory.ParseTypeName(property.Type.ToDisplayString()),
//                                 SyntaxFactory.Identifier(property.Name)
//                             )
//                             .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
//                             .WithAccessorList(
//                                 SyntaxFactory.AccessorList(
//                                     SyntaxFactory.List(
//                                         new[]
//                                         {
//                                             SyntaxFactory
//                                                 .AccessorDeclaration(
//                                                     SyntaxKind.GetAccessorDeclaration
//                                                 )
//                                                 .WithSemicolonToken(
//                                                     SyntaxFactory.Token(SyntaxKind.SemicolonToken)
//                                                 ),
//                                             SyntaxFactory
//                                                 .AccessorDeclaration(
//                                                     SyntaxKind.SetAccessorDeclaration
//                                                 )
//                                                 .WithSemicolonToken(
//                                                     SyntaxFactory.Token(SyntaxKind.SemicolonToken)
//                                                 )
//                                         }
//                                     )
//                                 )
//                             );

//                         interfaceDeclaration = interfaceDeclaration.AddMembers(propertyDeclaration);
//                     }
//                 }

//                 syntaxFactory = syntaxFactory.AddMembers(interfaceDeclaration);
//                 var source = syntaxFactory.NormalizeWhitespace().ToFullString();

//                 context.AddSource($"{interfaceName}.cs", SourceText.From(source, Encoding.UTF8));
//             }
//         }

//         private static void Generate(
//             SourceProductionContext context,
//             ImmutableArray<(
//                 TypeDeclarationSyntax? TypeFromWhichTheMemberComes,
//                 INamedTypeSymbol? SymbolOfTypeFromWhichTheMemberComes
//             )> values
//         )
//         {
//             // declare all of the marker interfaces for interfaces having been decomposed
//             ImmutableArray<string> uniqueTypes = values
//                 .Select(
//                     value =>
//                         value.SymbolOfTypeFromWhichTheMemberComes.ToDisplayString(
//                             SymbolDisplayFormat.FullyQualifiedFormat
//                         )
//                 )
//                 .Distinct(StringComparer.Ordinal)
//                 .ToImmutableArray();
//             context.AddSource("uniqueTyps.cs", $"/* {Join(", ", uniqueTypes)} */");
//             foreach (string? uniqueType in uniqueTypes)
//             {
//                 context.AddSource(
//                     $"IDecomposedFrom{uniqueType}.g.cs",
//                     IDecomposedInterfaceDeclarationTemplate.Render(
//                         new { DecomposedFrom = uniqueType }
//                     )
//                 );
//             }

//             // declare all of the marker interfaces for methods having been decomposed
//             ImmutableArray<(INamedTypeSymbol? Type, string Method)> uniqueMembers = values
//                 .SelectMany(
//                     value =>
//                         value.SymbolOfTypeFromWhichTheMemberComes
//                             .GetMembers()
//                             .OfType<IMethodSymbol>()
//                             .Select(
//                                 method =>
//                                     (value.SymbolOfTypeFromWhichTheMemberComes, method.MetadataName)
//                             )
//                             .Distinct(
//                                 new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(
//                                     (
//                                         (INamedTypeSymbol? type, string method) a,
//                                         (INamedTypeSymbol? type, string method) b
//                                     ) => a.type == b.type && a.method == b.method
//                                 )
//                             )
//                 )
//                 .ToImmutableArray();
//             context.AddSource(
//                 "uniqueMembers.cs",
//                 $"/* {Join(", ", uniqueMembers.Select(mbr => mbr.Method))} */"
//             );
//             foreach ((INamedTypeSymbol? type, string method) in uniqueMembers)
//             {
//                 context.AddSource(
//                     $"IDecomposedFrom{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}.g.cs",
//                     IDecomposedInterfaceDeclarationTemplate.Render(
//                         new
//                         {
//                             DecomposedFrom = $"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}"
//                         }
//                     )
//                 );
//             }

//             // declare all of the marker interfaces for properties having been decomposed
//             uniqueMembers = values
//                 .SelectMany(
//                     value =>
//                         value.SymbolOfTypeFromWhichTheMemberComes
//                             .GetMembers()
//                             .OfType<IPropertySymbol>()
//                             .Select(
//                                 property =>
//                                     (
//                                         value.SymbolOfTypeFromWhichTheMemberComes,
//                                         property.MetadataName
//                                     )
//                             )
//                             .Distinct(
//                                 new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(
//                                     (
//                                         (INamedTypeSymbol? type, string property) a,
//                                         (INamedTypeSymbol? type, string property) b
//                                     ) => a.type == b.type && a.property == b.property
//                                 )
//                             )
//                 )
//                 .ToImmutableArray();
//             context.AddSource(
//                 "uniqueProperties.cs",
//                 $"/* {Join(", ", uniqueMembers.Select(member => member.Method))} */"
//             );
//             foreach ((INamedTypeSymbol? type, string method) in uniqueMembers)
//             {
//                 context.AddSource(
//                     $"IDecomposedFrom{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}.g.cs",
//                     IDecomposedInterfaceDeclarationTemplate.Render(
//                         new
//                         {
//                             DecomposedFrom = $"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}"
//                         }
//                     )
//                 );
//             }
//         }

//         private static bool IsEligibleMember(
//             SyntaxNode node,
//             Compilation compilationn,
//             CancellationToken cancellationToken = default
//         )
//         {
//             return node is MemberDeclarationSyntax memberDeclarationSyntax
//                 && memberDeclarationSyntax.Parent is TypeDeclarationSyntax typeDeclarationSyntax
//                 && typeDeclarationSyntax.Modifiers.Any(
//                     syntaxToken => syntaxToken.Equals(SyntaxKind.PartialKeyword)
//                 );
//         }

//         private static bool IsEligibleType(
//             SyntaxNode? node,
//             CancellationToken cancellationToken = default
//         )
//         {
//             return node is TypeDeclarationSyntax typeDeclarationSyntax
//                 || node.IsKind(SyntaxKind.AttributeSyntax);
//         }

//         private static INamedTypeSymbol ExtractTargetType(
//             TypeDeclarationSyntax? typeDeclarationSyntax,
//             Compilation compilation
//         )
//         {
//             if (typeDeclarationSyntax is ClassDeclarationSyntax or StructDeclarationSyntax)
//             {
//                 return compilation
//                         .GetSemanticModel(typeDeclarationSyntax.SyntaxTree)
//                         .GetDeclaredSymbol(typeDeclarationSyntax) as INamedTypeSymbol;
//             }
//             AttributeSyntax decomposableAttribute = typeDeclarationSyntax.AttributeLists
//                 .SelectMany(attributeList => attributeList.Attributes)
//                 .FirstOrDefault(
//                     attribute => attribute.Name.ToString() == DecomposableAttributeName
//                 );
//             return decomposableAttribute == null
//                 ? null
//                 : decomposableAttribute.ArgumentList?.Arguments.Count == 0
//                     ? compilation
//                         .GetSemanticModel(
//                             decomposableAttribute.ArgumentList?.Arguments.First().SyntaxTree
//                         )
//                         .GetDeclaredSymbol(decomposableAttribute.ArgumentList?.Arguments.First())
//                         as INamedTypeSymbol
//                     : decomposableAttribute.ArgumentList?.Arguments.Count == 1
//                     && decomposableAttribute.ArgumentList.Arguments.First().Expression
//                         is TypeOfExpressionSyntax typeOfExpressionSyntax
//                         ? Type.GetType(typeOfExpressionSyntax.Type.ToString())
//                         : throw new InvalidOperationException(
//                             $"The {DecomposableAttributeName} attribute must be applied to a type declaration or must have a single argument of type {typeof(Type).FullName}."
//                         );
//         }

//         private static void Generate(
//             SourceProductionContext context,
//             ImmutableArray<(
//                 TypeDeclarationSyntax? TypeFromWhichTheMemberComes,
//                 INamedTypeSymbol? SymbolOfTypeFromWhichTheMemberComes,
//                 ImmutableArray<MethodDeclarationSyntax?> Methods,
//                 ImmutableArray<PropertyDeclarationSyntax?> Properties
//             )> values
//         )
//         {
//             // declae all of the marker interfaces for interfaces having been decomposed
//             ImmutableArray<string> uniqueTypes = values
//                 .Select(
//                     value =>
//                         value.SymbolOfTypeFromWhichTheMemberComes.ToDisplayString(
//                             SymbolDisplayFormat.FullyQualifiedFormat
//                         )
//                 )
//                 .Distinct(StringComparer.Ordinal)
//                 .ToImmutableArray();
//             foreach (string? uniqueType in uniqueTypes)
//             {
//                 context.AddSource(
//                     $"IDecomposedFrom{uniqueType}.g.cs",
//                     IDecomposedInterfaceDeclarationTemplate.Render(
//                         new { DecomposedFrom = uniqueType }
//                     )
//                 );
//             }

//             // declare all of the marker interfaces for methods having been decomposed
//             ImmutableArray<(INamedTypeSymbol? Type, string Method)> uniqueMembers = values
//                 .SelectMany(
//                     value =>
//                         value.Methods
//                             .Select(
//                                 method =>
//                                     (
//                                         value.SymbolOfTypeFromWhichTheMemberComes,
//                                         method.Identifier.ValueText
//                                     )
//                             )
//                             .Distinct(
//                                 new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(
//                                     (
//                                         (INamedTypeSymbol? type, string method) a,
//                                         (INamedTypeSymbol? type, string method) b
//                                     ) => a.type?.Name == b.type.Name && a.method == b.method
//                                 )
//                             )
//                 )
//                 .ToImmutableArray();
//             foreach ((INamedTypeSymbol? Type, string Method) uniqueMember in uniqueMembers)
//             {
//                 context.AddSource(
//                     $"IDecomposedFrom{uniqueMember.Type?.Name ?? "Aonymous"}.{uniqueMember.Method}.g.cs",
//                     IDecomposedMarkerInterfaceDeclarationTemplate.Render(
//                         new DecomposedMemberModel(
//                             uniqueMember.Type.ToDisplayString(
//                                 SymbolDisplayFormat.FullyQualifiedFormat
//                             ),
//                             uniqueMember.Method
//                         )
//                     )
//                 );
//             }

//             // declare all of the marker interfaces for properties having been decomposed
//             ImmutableArray<(INamedTypeSymbol? Type, string Property)> uniqueProperties = values
//                 .SelectMany(
//                     value =>
//                         value.Properties
//                             .Select(
//                                 property =>
//                                     (
//                                         value.SymbolOfTypeFromWhichTheMemberComes,
//                                         property.Identifier.ValueText
//                                     )
//                             )
//                             .Distinct(
//                                 new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(
//                                     (
//                                         (INamedTypeSymbol? type, string property) a,
//                                         (INamedTypeSymbol? type, string property) b
//                                     ) => a.type?.Name == b.type.Name && a.property == b.property
//                                 )
//                             )
//                 )
//                 .ToImmutableArray();
//             foreach ((INamedTypeSymbol? Type, string Property) uniqueProperty in uniqueProperties)
//             {
//                 context.AddSource(
//                     $"IDecomposedFrom{uniqueProperty.Type?.Name ?? "Aonymous"}.{uniqueProperty.Property}.g.cs",
//                     IDecomposedMarkerInterfaceDeclarationTemplate.Render(
//                         new DecomposedMemberModel(
//                             uniqueProperty.Type.ToDisplayString(
//                                 SymbolDisplayFormat.FullyQualifiedFormat
//                             ),
//                             uniqueProperty.Property
//                         )
//                     )
//                 );
//             }

//             // declare all of the decomposed interfaces
//             foreach (
//                 (
//                     TypeDeclarationSyntax? TypeFromWhichTheMemberComes,
//                     INamedTypeSymbol? SymbolOfTypeFromWhichTheMemberComes,
//                     ImmutableArray<MethodDeclarationSyntax?> Methods,
//                     ImmutableArray<PropertyDeclarationSyntax?> Properties
//                 ) in values
//             )
//             {
//                 if (
//                     TypeFromWhichTheMemberComes is null
//                     || SymbolOfTypeFromWhichTheMemberComes is null
//                 )
//                 {
//                     continue;
//                 }

//                 foreach (MethodDeclarationSyntax? method in Methods)
//                 {
//                     if (method is null)
//                     {
//                         continue;
//                     }

//                     string returnType = method.ReturnType.ToFullString();
//                     context.AddSource(
//                         $"{SymbolOfTypeFromWhichTheMemberComes.Name}.{method.Identifier.ValueText}{(method.ConstraintClauses.Count() > 0 ? $"`<{method.ConstraintClauses.Count}>" : "")}.g.cs",
//                         DecomposedMethodDeclarationTemplate.Render(
//                             new DecomposedMethodModel(
//                                 returnType,
//                                 method.Identifier.ValueText,
//                                 method.ParameterList.Parameters
//                                     .Select(
//                                         parameter =>
//                                             new DecomposedParameterModel(
//                                                 parameter.Type.ToFullString(),
//                                                 parameter.Identifier.ValueText
//                                             )
//                                     )
//                                     .ToArray(),
//                                 method.ConstraintClauses
//                                     .SelectMany(
//                                         constraintClause =>
//                                             constraintClause.Constraints.Select(
//                                                 constraint =>
//                                                     new DecomposedTypeConstraintModel(
//                                                         constraintClause.Name.ToString(),
//                                                         constraint.IsKind(
//                                                             SyntaxKind.ClassConstraint
//                                                         )
//                                                             ? "class"
//                                                             : constraint.IsKind(
//                                                                 SyntaxKind.StructConstraint
//                                                             )
//                                                                 ? "struct"
//                                                                 : constraint.IsKind(
//                                                                     SyntaxKind.ConstructorConstraint
//                                                                 )
//                                                                     ? "new()"
//                                                                     : constraint.IsKind(
//                                                                         SyntaxKind.TypeConstraint
//                                                                     )
//                                                                         ? constraint.ToString()
//                                                                         : throw new NotSupportedException(
//                                                                             $"The constraint {constraint} is not supported."
//                                                                         )
//                                                     )
//                                             )
//                                     )
//                                     .ToArray()
//                             )
//                         )
//                     );
//                 }
//             }
//         }
//     }
// }

// // public void AddClass(Type classType)
// //         {
// //             var members = GetDecomposableMembers(classType);

// //             if (!members.Any())
// //                 return;

// //             var clsddName = $"{classType.Name}Decorator";
// //             var interfaceType = new CodeTypeDeclaration(interfaceName);
// //             interfaceType.IsInterface = true;

// //             foreach (var member in members)
// //             {
// //                 var memberType = member.MemberType == MemberTypes.Property
// //                     ? ((PropertyInfo)member).PropertyType
// //                     : ((FieldInfo)member).FieldType;

// //                 var memberName = member.Name.ToCamelCase();
// //                 var interfaceMember = new CodeMemberProperty
// //                 {
// //                     Name = memberName,
// //                     HasGet = true,
// //                     Type = new CodeTypeReference(memberType),
// //                 };
// //                 interfaceType.Members.Add(interfaceMember);
// //             }

// //             codeNamespace.Types.Add(interfaceType);
// //         }

// //         public override string ToString()
// //         {
// //             var provider = CodeDomProvider.CreateProvider("CSharp");
// //             var options = new CodeGeneratorOptions
// //             {
// //                 BracingStyle = "C",
// //                 IndentString = "    ",
// //             };

// //             using (var writer = new System.IO.StringWriter())
// //             {
// //                 provider.GenerateCodeFromCompileUnit(compileUnit, writer, options);
// //                 return writer.ToString();
// //             }
// //         }

// //         private static IEnumerable<MemberInfo> GetDecomposableMembers(Type type)
// //         {
// //             return type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
// //                 .Where(m => m.GetCustomAttribute<DecomposeAttribute>() != null);
// //         }
// //     }

// //     public static class StringExtensions
// //     {
// //         public static string ToCamelCase(this string value)
// //         {
// //             if (string.IsNullOrEmpty(value))
// //                 return value;
// //             return char.ToLowerInvariant(value[0]) + value.Substring(1);
// //         }
// //     }
// //     }
