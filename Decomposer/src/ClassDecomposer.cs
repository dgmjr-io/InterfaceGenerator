using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

using static Dgmjr.InterfaceGenerator.Decomposer.Constants;

using SourceHash = System.Collections.Immutable.ImmutableArray<byte>;
namespace Dgmjr.InterfaceGenerator.Decomposer;

[Generator]
public class TypeDecomposer : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        try
        {
            var sourceTypes = context.SyntaxProvider.ForAttributeWithMetadataName(
                AttributeFullName,
                Filter,
                (ctx, _) => ctx).Collect();

            context.RegisterSourceOutput(sourceTypes, Execute);
        }
        finally
        {
            context.RegisterPostInitializationOutput(
                ctx =>
                    ctx.AddSource(
                        "Logs.g.cs",
                        SourceText.From(Join("\n", Log.Logs), Encoding.UTF8)
                    )
            );
        }
    }

    private static bool Filter(SyntaxNode node, CancellationToken _)
    {
        Log.Print($"Filtering {node.Kind()}");
        return node is TypeDeclarationSyntax tds && (tds.Kind() is SyntaxKind.ClassDeclaration or SyntaxKind.StructDeclaration or SyntaxKind.InterfaceDeclaration)
            && tds.AttributeLists.Any(
                al => al.Attributes.Any(
                    a => a.Name.ToString() is AttributeName or AttributeFullName
                )
            );
    }

    private static void Execute(SourceProductionContext context, ImmutableArray<GeneratorAttributeSyntaxContext> attributeSyntaxContexts)
    {
        Log.Print($"Generating {attributeSyntaxContexts.Length} attribute syntax contexts");
        var codes = attributeSyntaxContexts.AsEnumerable().Select(attributeSyntax => GenerateInterfacesFromGeneratorAttributeSyntaxContext(attributeSyntax, context));
        foreach (var (sourceFileName, code) in codes)
        {
            context.AddSource(sourceFileName, code);
        }
    }

    private static (string, string) GenerateInterfacesFromGeneratorAttributeSyntaxContext(GeneratorAttributeSyntaxContext attributeSyntax, SourceProductionContext context)
    {
        var targetSymbol = attributeSyntax.TargetSymbol is INamedTypeSymbol ints ? ints : attributeSyntax.TargetSymbol;
        return (targetSymbol is INamedTypeSymbol) ? GenerateInterfacesFromNamedTypeSymbol(targetSymbol as INamedTypeSymbol, context) : (targetSymbol.Name + SourceFileNameSuffix, $"// {targetSymbol.Name} is not a named type symbol");
    }

    private static (string, string) GenerateInterfacesFromNamedTypeSymbol(INamedTypeSymbol? targetType, SourceProductionContext context)
    {
        Log.Print($"Generating interfaces for {targetType.Name}...");

        var targetNamespace = targetType?.ContainingNamespace.ToDisplayString();
        var namespaceName = targetNamespace + NamespaceSuffix;
        var sourceFileName = targetType?.Name + SourceFileNameSuffix;
        Log.Print("Target namespace: " + targetNamespace);
        Log.Print("Namespace name: " + namespaceName);
        Log.Print("Source file name: " + targetType?.Name + SourceFileNameSuffix);

        var members = targetType?
            .GetMembers()
            .Where(m => m.Kind is SymbolKind.Method or SymbolKind.Property)
            .Where(m => m.DeclaredAccessibility == Accessibility.Public && !(
                        m is IPropertySymbol property
                        && (
                            property.IsIndexer
                            || property.IsReadOnly
                            || property.IsWriteOnly
                        )
                    )
            )
            .ToList();

        context.AddSource($"Members-{targetType?.ContainingType?.Name}-{Guid.NewGuid().ToString().Substring(0, 4)}.g.cs", $"/* {string.Join("\n", members.Select(m => $"{m.Name}: {string.Join("\n", m.DeclaringSyntaxReferences.Select(syntax => syntax))}"))} */");

        var interfaceDeclarationSyntaxTrees = new DefaultableDictionary<string, IList<InterfaceDeclarationSyntax>>(new List<InterfaceDeclarationSyntax>());

        foreach (var member in members.AsEnumerable())
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

            if (member is IPropertySymbol p && p.DeclaredAccessibility is Accessibility.Public)
            {
                var memberDeclarationSyntax = SyntaxFactory
                        .InterfaceDeclaration($"I{targetType?.Name}{member.Name}")
                        .WithMembers(
                            SyntaxFactory.List<MemberDeclarationSyntax>(
                                new[] { SyntaxFactory.ParseMemberDeclaration(p.ToDisplayString())! }
                            )
                        )
                        .AddAttributeLists(GeneratedCodeAttributesSyntax)
                        .AddBaseListTypes(
                            SyntaxFactory.SimpleBaseType(
                                SyntaxFactory.ParseTypeName(
                                    $"IDecomposed<{targetType?.Name}>"
                        .        )
                            )
                        );
                Log.Print(memberDeclarationSyntax.ToString());
                interfaceDeclarationSyntaxTrees[$"{targetType?.Name}{member.Name}"].Add(memberDeclarationSyntax);
            }
            else if (
                member is IMethodSymbol meth
                && meth.CanBeReferencedByName
                && meth.DeclaredAccessibility == Accessibility.Public
                && !meth.IsAccessor()
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
                            .InterfaceDeclaration($"I{targetType?.Name}{member.Name}")
                            .WithMembers(
                                SyntaxFactory.List(
                                    meth.DeclaringSyntaxReferences
                                        .OfType<MemberDeclarationSyntax>()
                                )
                            )
                            .AddAttributeLists(GeneratedCodeAttributesSyntax)
                            .AddBaseListTypes(
                                SyntaxFactory.SimpleBaseType(
                                    SyntaxFactory.ParseTypeName(
                                        $"IDecomposedFrom<{targetType?.Name}>"
                                    )
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

        return (sourceFileName, baseNamespaceDeclarationSyntax.NormalizeWhitespace().ToFullString());
    }
}

internal static class IsAccessorExtension
{
    public static bool IsAccessor(this IMethodSymbol method)
    {
        return method.MethodKind switch
        {
            MethodKind.PropertyGet => true,
            MethodKind.PropertySet => true,
            _ => false,
        };
    }
}
