using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dgmjr.InterfaceGenerator.Decomposer;

[Generator]
public class TypeDecomposer : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Register the attribute we're interested in so that the generator is called when it's used  
        context.RegisterForSyntaxNotifications(() => new AttributeSyntaxReceiver());
    }

    public void Execute(IncrementalGeneratorExecutionContext context)
    {
        if (!(context.SyntaxReceiver is AttributeSyntaxReceiver attributeSyntaxReceiver))
            return;

        // Group the symbols by assembly  
        var symbolsByAssembly = attributeSyntaxReceiver.Symbols
            .GroupBy(symbol => symbol.ContainingAssembly);

        // Generate decomposed interfaces for each assembly  
        foreach (var symbolsInAssembly in symbolsByAssembly)
        {
            var compilation = context.Compilation.AddReferences(symbolsInAssembly.Key.ToMetadataReference());

            // Group the symbols by target type  
            var symbolsByTargetType = symbolsInAssembly
                .GroupBy(symbol => GetTargetType(compilation, symbol));

            // Generate decomposed interfaces for each target type  
            foreach (var symbolsForType in symbolsByTargetType)
            {
                var targetType = symbolsForType.Key;
                var interfaces = new List<ClassDeclarationSyntax>();

                // Generate an interface for each public property and method  
                foreach (var symbol in symbolsForType)
                {
                    switch (symbol)
                    {
                        case IPropertySymbol propertySymbol:
                            if (propertySymbol.IsReadOnly || propertySymbol.IsWriteOnly)
                                continue;
                            var interfaceName = GetInterfaceName(targetType, propertySymbol);
                            var interfaceSyntax = GenerateInterfaceSyntax(targetType, propertySymbol, interfaceName);
                            interfaces.Add(interfaceSyntax);
                            break;
                        case IMethodSymbol methodSymbol:
                            if (methodSymbol.IsAccessor())
                                continue;
                            var overloadedMethodSymbols = targetType.GetMembers(methodSymbol.Name)
                                .OfType<IMethodSymbol>()
                                .Where(m => SymbolEqualityComparer.Default.Equals(m.ReturnType, methodSymbol.ReturnType)
                                    && m.Parameters.SequenceEqual(methodSymbol.Parameters, ParameterEqualityComparer.Default));
                            foreach (var overloadedMethodSymbol in overloadedMethodSymbols)
                            {
                                var interfaceName = GetInterfaceName(targetType, overloadedMethodSymbol);
                                var interfaceSyntax = GenerateInterfaceSyntax(targetType, overloadedMethodSymbol, interfaceName);
                                interfaces.Add(interfaceSyntax);
                            }
                            break;
                    }
                }

                // Generate a marker interface for the target type  
                var markerInterfaceName = $"IDecomposedFrom<{targetType.Name}>";
                var markerInterfaceSyntax = SyntaxFactory.InterfaceDeclaration(markerInterfaceName)
                    .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(targetType.ToDisplayString())))
                    .NormalizeWhitespace();
                interfaces.Add(markerInterfaceSyntax);

                // Generate source code files for the interfaces  
                var namespaceName = GetNamespaceName(targetType, symbolsForType);
                foreach (var interfaceSyntax in interfaces)
                {
                    var fileName = $"I{targetType.Name}{interfaceSyntax.Identifier}Decomposed.g.cs";
                    var generatedCode = GenerateCode(namespaceName, interfaceSyntax);
                    context.AddSource(fileName, generatedCode);
                }
            }
        }
    }

    private static ITypeSymbol GetTargetType(Compilation compilation, ISymbol symbol)
    {
        var targetTypeAttribute = symbol.GetAttributes()
            .FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, compilation.GetTypeByMetadataName(typeof(DecomposeAttribute).FullName)));
        if (targetTypeAttribute != null && targetTypeAttribute.ConstructorArguments.Length > 0)
        {
            var targetTypeArg = targetTypeAttribute.ConstructorArguments[0];
            if (targetTypeArg.Value is ITypeSymbol targetType)
                return targetType;
        }
        return symbol.ContainingType;
    }

    private static string GetInterfaceName(ITypeSymbol targetType, ISymbol memberSymbol)
    {
        return $"I{targetType.Name}_{memberSymbol.Name}";
    }

    private static INamespaceSymbol GetNamespaceSymbol(ITypeSymbol targetType, IEnumerable<ISymbol> symbols)
    {
        var namespaceAttribute = symbols
            .SelectMany(s => s.GetAttributes())
            .FirstOrDefault(a => a.AttributeClass?.Name == "Decompose" && a.AttributeConstructor?.Parameters.Length > 0 && a.AttributeConstructor.Parameters[0].Type?.Name == "String" && (string)a.ConstructorArguments[0].Value == "@namespace");
        if (namespaceAttribute != null && namespaceAttribute.ConstructorArguments.Length > 1 && namespaceAttribute.ConstructorArguments[1].Value is string namespaceName)
            return targetType.ContainingNamespace.GetNamespace(namespaceName);
        else
            return targetType.ContainingNamespace;
    }

    private static string GetNamespaceName(ITypeSymbol targetType, IEnumerable<ISymbol> symbols)
    {
        return GetNamespaceSymbol(targetType, symbols).ToDisplayString();
    }

    private static InterfaceDeclarationSyntax GenerateInterfaceSyntax(ITypeSymbol targetType, IPropertySymbol propertySymbol, string interfaceName)
    {
        var propertyTypeSyntax = SyntaxFactory.ParseTypeName(propertySymbol.Type.ToDisplayString());
        var propertyDeclaration = SyntaxFactory.PropertyDeclaration(propertyTypeSyntax, propertySymbol.Name)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.GetKeyword), SyntaxFactory.Token(SyntaxKind.SetKeyword))
            .NormalizeWhitespace();
        return SyntaxFactory.InterfaceDeclaration(interfaceName)
            .AddMembers(propertyDeclaration)
            .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"IDecomposedFrom<{targetType.Name}>")))
            .NormalizeWhitespace();
    }

    private static InterfaceDeclarationSyntax GenerateInterfaceSyntax(ITypeSymbol targetType, IMethodSymbol methodSymbol, string interfaceName)
    {
        var returnTypeSyntax = SyntaxFactory.ParseTypeName(methodSymbol.ReturnType.ToDisplayString());
        var parameterListSyntax = SyntaxFactory.ParseParameterList(methodSymbol.Parameters.ToDisplayString());
        var methodDeclaration = SyntaxFactory.MethodDeclaration(returnTypeSyntax, methodSymbol.Name)
            .WithParameterList(parameterListSyntax)
            .NormalizeWhitespace();
        return SyntaxFactory.InterfaceDeclaration(interfaceName)
            .AddMembers(methodDeclaration)
            .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"IDecomposedFrom<{targetType.Name}>")))
            .NormalizeWhitespace();
    }

    private static string GenerateCode(string namespaceName, InterfaceDeclarationSyntax interfaceSyntax)
    {
        var interfaceDeclaration = interfaceSyntax
            .WithLeadingTrivia(SyntaxFactory.Comment("// <auto-generated/>"))
            .NormalizeWhitespace();
        var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(namespaceName))
            .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")))
            .AddMembers(interfaceDeclaration)
            .NormalizeWhitespace();
        var compilationUnit = SyntaxFactory.CompilationUnit()
            .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")))
            .AddMembers(namespaceDeclaration)
            .NormalizeWhitespace();
        return compilationUnit.ToFullString();
    }

    private sealed class AttributeSyntaxReceiver : ISyntaxReceiver
    {
        public List<ISymbol> Symbols = new();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is AttributeSyntax attributeSyntax &&
                attributeSyntax.Name is IdentifierNameSyntax identifierNameSyntax &&
                identifierNameSyntax.Identifier.ValueText == "Decompose")
            {
                var symbol = ModelExtensions.GetSymbolInfo(attributeSyntax, GeneratorExecutionContext.Compilation).Symbol;
                if (symbol != null)
                    Symbols.Add(symbol);
            }
        }
    }

    private sealed class ParameterEqualityComparer : IEqualityComparer<IParameterSymbol>
    {
        public static readonly ParameterEqualityComparer Default = new();

        public bool Equals(IParameterSymbol x, IParameterSymbol y)
        {
            return SymbolEqualityComparer.Default.Equals(x.Type, y.Type) && x.Name == y.Name;
        }

        public int GetHashCode(IParameterSymbol obj)
        {
            return SymbolEqualityComparer.Default.GetHashCode(obj.Type) ^ obj.Name.GetHashCode();
        }
    }

    private static class SymbolExtensions
    {
        public static bool IsAccessor(this IMethodSymbol methodSymbol)
        {
            return methodSymbol.MethodKind switch
            {
                MethodKind.PropertyGet => true,
                MethodKind.PropertySet => true,
                _ => false,
            };
        }
    }
}
