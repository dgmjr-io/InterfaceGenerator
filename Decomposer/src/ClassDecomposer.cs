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
using static Constants;


[Generator]
public class TypeDecomposer : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(
            ctx =>
                ctx.AddSource(
                    DecomposableAttributeFilename,
                    DecomposableAttributeDeclaration
                )
        );
        var sourceTypes = context.SyntaxProvider.ForAttributeWithMetadataName(
            AttributeFullName,
            Filter,
            (ctx, _) => ctx).Collect();

        context.RegisterSourceOutput(sourceTypes, Execute);

        context.RegisterPostInitializationOutput(
            ctx =>
                ctx.AddSource(
                    "Logs.g.cs",
                    SourceText.From(string.Join("\n", Log.Logs), Encoding.UTF8)
                )
        );
    }

    private static bool Filter(SyntaxNode node, CancellationToken _)
    {
        Log.Print($"Filtering {node.Kind()}");
        return node is TypeDeclarationSyntax tds && (tds.Kind() == SyntaxKind.ClassDeclaration || tds.Kind() == SyntaxKind.StructDeclaration || tds.Kind() == SyntaxKind.InterfaceDeclaration)
            && tds.AttributeLists.Any(
                al => al.Attributes.Any(
                    a => a.Name.ToString() is AttributeName or AttributeName + "Attribute"
                )
            );
    }

    private static void Execute(SourceProductionContext context, ImmutableArray<GeneratorAttributeSyntaxContext> attributeSyntaxContexts)
    {
        Log.Print($"Generating {attributeSyntaxContexts.Length} attribute syntax contexts");
        var codes = attributeSyntaxContexts.AsEnumerable().Select(GenerateInterfacesFromGeneratorAttributeSyntaxContext);
        foreach (var (sourceFileName, code) in codes)
        {
            context.AddSource(sourceFileName, code);
        }
    }

    private static (string, string) GenerateInterfacesFromGeneratorAttributeSyntaxContext(GeneratorAttributeSyntaxContext attributeSyntax)
    {
        var targetSymbol = attributeSyntax.TargetSymbol is INamedTypeSymbol ints ? ints : attributeSyntax.TargetSymbol;
        if (targetSymbol is INamedTypeSymbol)
        {
            return GenerateInterfacesFromNamedTypeSymbol(targetSymbol as INamedTypeSymbol);
        }
        return (targetSymbol.Name + SourceFileNameSuffix, $"// {targetSymbol.Name} is not a named type symbol");
    }

    private static (string, string) GenerateInterfacesFromNamedTypeSymbol(INamedTypeSymbol targetSymbol)
    {
        Log.Print($"Generating interfaces for {targetSymbol.Name}");

        var targetNamespace = targetSymbol.ContainingNamespace.ToDisplayString();
        var namespaceName = targetNamespace + NamespaceSuffix;
        var sourceFileName = targetSymbol.Name + SourceFileNameSuffix;
        Log.Print("Target namespace: " + targetNamespace);
        Log.Print("Namespace name: " + namespaceName);
        Log.Print("Source file name: " + targetSymbol.Name + SourceFileNameSuffix);

        var members = targetSymbol
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

        var interfaceDeclarationSyntaxTrees = new DefaultableDictionary<
            string,
            IList<InterfaceDeclarationSyntax>>(new List<InterfaceDeclarationSyntax>());

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
                                p.DeclaringSyntaxReferences
                                    .OfType<MemberDeclarationSyntax>()
                            )
                        )
                        .AddAttributeLists(GeneratedCodeAttribueSyntax)
                        .AddBaseListTypes(
                            SyntaxFactory.SimpleBaseType(
                                SyntaxFactory.ParseTypeName(
                                    $"IDecomposedFrom<{targetSymbol.Name}>"
                                )
                            )
                        )
                );
            }
            else if (
                member is IMethodSymbol meth
                && meth.CanBeReferencedByName
                && meth.DeclaredAccessibility == Accessibility.Public
                && !meth.IsAccessor()
            )
            {
                var methodSyntax = CSharpSyntaxTree.ParseText(
                    meth.ToDisplayString(SymbolDisplayFormat)
                );
                var methodSyntaxString = methodSyntax.ToString();
                if (!methodSyntaxString.Contains("*"))
                {
                    interfaceDeclarationSyntaxTrees[meth.Name].Add(
                        SyntaxFactory
                            .InterfaceDeclaration($"I{targetSymbol.Name}{member.Name}")
                            .WithMembers(
                                SyntaxFactory.List(
                                    meth.DeclaringSyntaxReferences
                                        .OfType<MemberDeclarationSyntax>()
                                )
                            )
                            .AddAttributeLists(GeneratedCodeAttribueSyntax)
                            .AddBaseListTypes(
                                SyntaxFactory.SimpleBaseType(
                                    SyntaxFactory.ParseTypeName(
                                        $"IDecomposedFrom<{targetSymbol.Name}>"
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
