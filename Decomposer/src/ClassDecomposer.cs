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

using static InterfaceGenerator.Decomposer.Constants;

using SourceHash = System.Collections.Immutable.ImmutableArray<byte>;
using SourceCodeTuple = (string Filename, string SourceCode);
using InterfaceGenerator.Decomposer.Models;
using static System.Text.Encoding;
using System.Runtime.InteropServices.ComTypes;

namespace InterfaceGenerator.Decomposer;

[Generator]
public class TypeDecomposer : IIncrementalGenerator
{
    private static IncrementalGeneratorInitializationContext InitializationContext;

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        InitializationContext = context;
        try
        {
            var sourceTypes = context.SyntaxProvider
                .ForAttributeWithMetadataName(AttributeFullName, Filter, (ctx, _) => ctx)
                .Collect();

            context.RegisterPostInitializationOutput(
                ctx =>
                    ctx.AddSource(DecomposableAttributeFilename, DecomposableAttributeDeclaration)
            );

            context.RegisterSourceOutput(sourceTypes, Execute);
        }
        finally
        {
            Log.FlushLogs(context);
        }
    }

    private static bool Filter(SyntaxNode node, CancellationToken _)
    {
        try
        {
            Log.Print($"Filtering {node.Kind()}");
            return node is TypeDeclarationSyntax tds
                && (
                    tds.Kind()
                    is SyntaxKind.ClassDeclaration
                        or SyntaxKind.StructDeclaration
                        or SyntaxKind.InterfaceDeclaration
                )
                && tds.AttributeLists.Any(
                    al =>
                        al.Attributes.Any(
                            a => a.Name.ToString() is AttributeName or AttributeFullName
                        )
                );
        }
        finally
        {
            Log.FlushLogs(InitializationContext);
        }
    }

    private static void Execute(
        SourceProductionContext context,
        ImmutableArray<GeneratorAttributeSyntaxContext> attributeSyntaxContexts
    )
    {
        try
        {
            Log.Print($"Generating {attributeSyntaxContexts.Length} attribute syntax contexts");
            var codes = attributeSyntaxContexts
                .AsEnumerable()
                .Select(
                    attributeSyntax =>
                        GenerateInterfacesFromGeneratorAttributeSyntaxContext(attributeSyntax)
                );
            foreach (var (sourceFileName, code) in codes)
            {
                context.AddSource(sourceFileName, code);
            }
        }
        finally
        {
            Log.FlushLogs(InitializationContext);
        }
    }

    private static SourceCodeTuple GenerateInterfacesFromGeneratorAttributeSyntaxContext(
        GeneratorAttributeSyntaxContext attributeSyntax
    )
    {
        var targetSymbol = attributeSyntax.TargetSymbol is INamedTypeSymbol ints
            ? ints
            : attributeSyntax.TargetSymbol;
        return (targetSymbol is INamedTypeSymbol)
            ? GenerateInterfacesFromNamedTypeSymbol(targetSymbol as INamedTypeSymbol)
            : (
                targetSymbol.Name + SourceFileNameSuffix,
                $"// {targetSymbol.Name} is not a named type symbol"
            );
    }

    private static SourceCodeTuple GenerateInterfacesFromNamedTypeSymbol(
        INamedTypeSymbol? targetType
    )
    {
        try
        {
            Log.Print($"Generating interfaces for {targetType?.Name}...");

            var targetNamespace = targetType?.ContainingNamespace.ToDisplayString();
            var namespaceName = targetNamespace + NamespaceSuffix;
            var sourceFileName = targetType?.Name + SourceFileNameSuffix;
            Log.Print("Target namespace: " + targetNamespace);
            Log.Print("Namespace name: " + namespaceName);
            Log.Print("Source file name: " + targetType?.Name + SourceFileNameSuffix);

            var decomposedType = new DecomposedType(targetType!);

            return (sourceFileName, DecomposedInterfaceDeclarationTemplate.Render(decomposedType));
        }
        finally
        {
            Log.FlushLogs(InitializationContext);
        }
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
