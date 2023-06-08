/*
 * Composer.cs
 *
 *   Created: 2023-05-26-04:36:29
 *   Modified: 2023-05-26-04:56:56
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[Generator]
public class ComposedClassGenerator : IIncrementalGenerator
{
    private const string ImportAttributeTypeName = "System.Composition.ImportAttribute";
    private const string ExportAttributeTypeName = "System.Composition.ExportAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Register our interest in annotated types
        context.RegisterForSyntaxNotifications(() => new ExportSyntaxReceiver());
    }

    public void Execute(IncrementalGeneratorExecutionContext context)
    {
        // We need a compilation to analyze
        if (context.Compilation == null)
        {
            return;
        }

        // Find all annotated types in the syntax tree
        var syntaxReceiver = (ExportSyntaxReceiver)context.SyntaxReceiver;
        var annotatedTypes = syntaxReceiver.AnnotatedTypes;

        // Create a new class or interface for each annotated type
        foreach (var annotatedType in annotatedTypes)
        {
            // Extract the export attribute data from the annotated type
            var exportAttribute = annotatedType.AttributeLists
                .SelectMany(al => al.Attributes)
                .SingleOrDefault(a => a.Name.ToString() == ExportAttributeTypeName);

            if (exportAttribute == null)
            {
                continue;
            }

            // Get the type name and namespace of the annotated type
            var typeName = annotatedType.Identifier.Text;
            var typeNamespace = annotatedType.FirstAncestorOrSelf<NamespaceDeclarationSyntax>().Name.ToString();

            // Create the class or interface declaration
            MemberDeclarationSyntax typeDeclaration;
            if (annotatedType is InterfaceDeclarationSyntax)
            {
                typeDeclaration = SyntaxFactory.InterfaceDeclaration(typeName)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword));
            }
            else
            {
                typeDeclaration = SyntaxFactory.ClassDeclaration(typeName)
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword));
            }

            // Extract the import attribute data from the exported members of the annotated type
            foreach (var member in annotatedType.Members)
            {
                var importAttribute = member.AttributeLists
                    .SelectMany(al => al.Attributes)
                    .SingleOrDefault(a => a.Name.ToString() == ImportAttributeTypeName);

                if (importAttribute == null)
                {
                    continue;
                }

                // Get the member name and type
                var memberName = member.Identifier.Text;
                var memberType = GetMemberType(member);

                // Create the member declaration with an optional delegate implementation
                var memberDeclaration = SyntaxFactory.ParseMemberDeclaration($"{memberType} {memberName} {{ get; }}");
                if (member is MethodDeclarationSyntax methodDeclaration)
                {
                    var parameters = methodDeclaration.ParameterList.Parameters.Select(p => SyntaxFactory.Parameter(p.Identifier))
                        .ToArray();
                    var body = methodDeclaration.ExpressionBody?.Expression ?? methodDeclaration.Body?.Statements.FirstOrDefault()?.WithLeadingTrivia();
                    if (body != null)
                    {
                        var lambda = SyntaxFactory.ParenthesizedLambdaExpression(SyntaxFactory.ParameterList(parameters), body);
                        memberDeclaration = memberDeclaration.ReplaceNode(memberDeclaration.DescendantNodes().First(n => n.Kind() == SyntaxKind.GetAccessorDeclaration), SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, SyntaxFactory.ArrowExpressionClause(lambda)));
                    }
                }

                // Add the member to the type declaration
                typeDeclaration = typeDeclaration.AddMembers(memberDeclaration);

                // Add the partial declaration with import attribute to the type declaration
                var partialMemberDeclaration = memberDeclaration.WithoutModifiers().WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None));
                var partialDeclaration = importAttribute.WithNameEquals(SyntaxFactory.NameEquals(memberName))
                    .AddArgumentListArguments(SyntaxFactory.AttributeArgument(SyntaxFactory.TypeOfExpression(SyntaxFactory.ParseTypeName(memberType))));
                typeDeclaration = typeDeclaration.AddMembers(partialMemberDeclaration.WithAttributeLists(SyntaxFactory.SingletonList(SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(partialDeclaration)))));
            }

            // Generate the final type syntax tree
            var typeTree = SyntaxFactory.CompilationUnit()
                .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Composition")))
                .AddMembers(SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(typeNamespace))
                    .AddMembers(typeDeclaration));

            // Add the syntax tree to the generator context
            context.AddSource($"{typeName}.cs", typeTree.NormalizeWhitespace().ToFullString());
        }
    }

    private string GetMemberType(MemberDeclarationSyntax member)
    {
        switch (member)
        {
            case FieldDeclarationSyntax fieldDeclaration:
                return fieldDeclaration.Declaration.Type.ToString();
            case PropertyDeclarationSyntax propertyDeclaration:
                return propertyDeclaration.Type.ToString();
            case MethodDeclarationSyntax methodDeclaration:
                return methodDeclaration.ReturnType.ToString();
            default:
                throw new System.NotImplementedException($"Unhandled member type {member.GetType()}");
        }
    }

    private class ExportSyntaxReceiver : ISyntaxReceiver
    {
        public List<TypeDeclarationSyntax> AnnotatedTypes { get; } = new List<TypeDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax
                && typeDeclarationSyntax.AttributeLists.Count > 0
                && typeDeclarationSyntax.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == ExportAttributeTypeName))
            {
                AnnotatedTypes.Add(typeDeclarationSyntax);
            }
        }
    }
}
