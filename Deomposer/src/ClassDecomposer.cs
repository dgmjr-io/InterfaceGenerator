using System.Collections.Immutable;
using Dgmjr.InterfaceGenerator.Decomposer.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Dgmjr.InterfaceGenerator.Decomposer.Constants;
namespace Dgmjr.InterfaceGenerator.Decomposer
{
    [Generator]
    public class DecomposableGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterPostInitializationOutput(ctx => ctx.AddSource(DecomposableAttributeName + ".g.cs", DecomposableAttributeDeclaration));

            IncrementalValueProvider<ImmutableArray<(TypeDeclarationSyntax?, INamedTypeSymbol?)>> decomposedTypes =
            context.SyntaxProvider.ForAttributeWithMetadataName(DecomposableAttributeName, 
                    IsEligibleType,
                    (generatorAttributeSyntaxContext, _) =>
                    (
                        generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax,
                        generatorAttributeSyntaxContext.TargetSymbol as INamedTypeSymbol
                    )).Collect();


            // fullyQualifiedMetadataName: DecomposableAttributeName,
            //     (node, _) => IsEligibleType((node, (node as TypeDeclarationSyntax).SemanticModel), _),
            //     generatorAttributeSyntaxContext => 
            //         (ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel),
            //         ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel).TargetSymbol as INamedTypeSymbol,
            //         (ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel).TargetNode as TypeDeclarationSyntax).Members.OfType<MethodDeclarationSyntax>().ToImmutableArray(),
            //         (ExtractTargetType(generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax, (generatorAttributeSyntaxContext.TargetNode as TypeDeclarationSyntax).SemanticModel).TargetNode as TypeDeclarationSyntax).Members.OfType<PropertyDeclarationSyntax>().ToImmutableArray()
            //     )).Collect();


            IncrementalValueProvider<ImmutableArray<(TypeDeclarationSyntax?, INamedTypeSymbol?, ImmutableArray<MethodDeclarationSyntax?>, ImmutableArray<PropertyDeclarationSyntax?>)>> decomposedMembers = context.SyntaxProvider.ForAttributeWithMetadataName(
                DecomposableAttributeName,
                IsEligibleMember,
                (generatorAttributeSyntaxContext, _) =>
                    (generatorAttributeSyntaxContext.TargetSymbol.ContainingType.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as TypeDeclarationSyntax,
                    generatorAttributeSyntaxContext.TargetSymbol.ContainingType.ContainingSymbol as INamedTypeSymbol,
                    new[] { generatorAttributeSyntaxContext.TargetNode as MethodDeclarationSyntax }.ToImmutableArray(),
                    new[] { generatorAttributeSyntaxContext.TargetNode as PropertyDeclarationSyntax }.ToImmutableArray())
                ).Collect();

            context.RegisterSourceOutput(decomposedTypes, Generate);
            context.RegisterSourceOutput(decomposedMembers, Generate);
        }

        private static void Generate(SourceProductionContext context, ImmutableArray<(TypeDeclarationSyntax? TypeFromWhichTheMemberComes, INamedTypeSymbol? SymbolOfTypeFromWhichTheMemberComes)> values)
        {
            // declare all of the marker interfaces for interfaces having been decomposed
            ImmutableArray<string> uniqueTypes = values.Select(value => value.SymbolOfTypeFromWhichTheMemberComes.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)).Distinct(StringComparer.Ordinal).ToImmutableArray();
            context.AddSource("uniqueTyps.cs", $"/* {Join(", ", uniqueTypes)} */");
            foreach (string? uniqueType in uniqueTypes)
            {
                context.AddSource($"IDecomposedFrom{uniqueType}.g.cs", IDecomposedInterfaceDeclarationTemplate.Render(new { DecomposedFrom = uniqueType }));
            }

            // declare all of the marker interfaces for methods having been decomposed
            ImmutableArray<(INamedTypeSymbol? Type, string Method)> uniqueMembers = values.SelectMany(value => value.SymbolOfTypeFromWhichTheMemberComes.GetMembers().OfType<IMethodSymbol>().Select(method => (value.SymbolOfTypeFromWhichTheMemberComes, method.MetadataName)).Distinct(new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(((INamedTypeSymbol? type, string method) a, (INamedTypeSymbol? type, string method) b) => a.type == b.type && a.method == b.method))).ToImmutableArray();
            context.AddSource("uniqueMembers.cs", $"/* {Join(", ", uniqueMembers.Select(mbr => mbr.Method))} */");
            foreach ((INamedTypeSymbol? type, string method) in uniqueMembers)
            {
                context.AddSource($"IDecomposedFrom{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}.g.cs", IDecomposedInterfaceDeclarationTemplate.Render(new { DecomposedFrom = $"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}" }));
            }

            // declare all of the marker interfaces for properties having been decomposed
            uniqueMembers = values.SelectMany(value => value.SymbolOfTypeFromWhichTheMemberComes.GetMembers().OfType<IPropertySymbol>().Select(property => (value.SymbolOfTypeFromWhichTheMemberComes, property.MetadataName)).Distinct(new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(((INamedTypeSymbol? type, string property) a, (INamedTypeSymbol? type, string property) b) => a.type == b.type && a.property == b.property))).ToImmutableArray();
            context.AddSource("uniqueProperties.cs", $"/* {Join(", ", uniqueMembers.Select(member => member.Method))} */");
            foreach ((INamedTypeSymbol? type, string method) in uniqueMembers)
            {
                context.AddSource($"IDecomposedFrom{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}.g.cs", IDecomposedInterfaceDeclarationTemplate.Render(new { DecomposedFrom = $"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}{method}" }));
            }
        }
        private static bool IsEligibleMember(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            return node is MemberDeclarationSyntax memberDeclarationSyntax
                && memberDeclarationSyntax.Parent is TypeDeclarationSyntax typeDeclarationSyntax
                && typeDeclarationSyntax.Modifiers.Any(syntaxToken => syntaxToken.Equals(SyntaxKind.PartialKeyword));
        }

        private static bool IsEligibleType(SyntaxNode? node, CancellationToken cancellationToken = default)
        {
            return node is TypeDeclarationSyntax typeDeclarationSyntax && ExtractTargetType(typeDeclarationSyntax) != null;
        }

        private static Type? ExtractTargetType(TypeDeclarationSyntax? typeDeclarationSyntax)
        {
            AttributeSyntax decomposableAttribute = typeDeclarationSyntax.AttributeLists.SelectMany(attributeList => attributeList.Attributes).FirstOrDefault(attribute => attribute.Name.ToString() == DecomposableAttributeName);
            return decomposableAttribute == null ? null :
            decomposableAttribute.ArgumentList?.Arguments.Count == 0 ?
            Type.GetType(typeDeclarationSyntax.TypeParameterList.Parameters.Single().Identifier.ValueText) :
            decomposableAttribute.ArgumentList?.Arguments.Count == 1 && decomposableAttribute.ArgumentList.Arguments.First().Expression is TypeOfExpressionSyntax typeOfExpressionSyntax
                ? Type.GetType(typeOfExpressionSyntax.Type.ToString())
                : throw new InvalidOperationException($"The {DecomposableAttributeName} attribute must be applied to a type declaration or must have a single argument of type {typeof(Type).FullName}.");
        }

        private static void Generate(SourceProductionContext context, ImmutableArray<(TypeDeclarationSyntax? TypeFromWhichTheMemberComes, INamedTypeSymbol? SymbolOfTypeFromWhichTheMemberComes, ImmutableArray<MethodDeclarationSyntax?> Methods, ImmutableArray<PropertyDeclarationSyntax?> Properties)> values)
        {
            // declae all of the marker interfaces for interfaces having been decomposed
            ImmutableArray<string> uniqueTypes = values.Select(value => value.SymbolOfTypeFromWhichTheMemberComes.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)).Distinct(StringComparer.Ordinal).ToImmutableArray();
            foreach (string? uniqueType in uniqueTypes)
            {
                context.AddSource($"IDecomposedFrom{uniqueType}.g.cs", IDecomposedInterfaceDeclarationTemplate.Render(new { DecomposedFrom = uniqueType }));
            }

            // declare all of the marker interfaces for methods having been decomposed
            ImmutableArray<(INamedTypeSymbol? Type, string Method)> uniqueMembers = values.SelectMany(value => value.Methods.Select(method => (value.SymbolOfTypeFromWhichTheMemberComes, method.Identifier.ValueText)).Distinct(new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(((INamedTypeSymbol? type, string method) a, (INamedTypeSymbol? type, string method) b) => a.type?.Name == b.type.Name && a.method == b.method))).ToImmutableArray();
            foreach ((INamedTypeSymbol? Type, string Method) uniqueMember in uniqueMembers)
            {
                context.AddSource($"IDecomposedFrom{uniqueMember.Type?.Name ?? "Aonymous"}.{uniqueMember.Method}.g.cs", IDecomposedMarkerInterfaceDeclarationTemplate.Render(new DecomposedMemberModel(uniqueMember.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat), uniqueMember.Method)));
            }

            // declare all of the marker interfaces for properties having been decomposed
            ImmutableArray<(INamedTypeSymbol? Type, string Property)> uniqueProperties = values.SelectMany(value => value.Properties.Select(property => (value.SymbolOfTypeFromWhichTheMemberComes, property.Identifier.ValueText)).Distinct(new LambdaEqualityComparer<(INamedTypeSymbol?, string)>(((INamedTypeSymbol? type, string property) a, (INamedTypeSymbol? type, string property) b) => a.type?.Name == b.type.Name && a.property == b.property))).ToImmutableArray();
            foreach ((INamedTypeSymbol? Type, string Property) uniqueProperty in uniqueProperties)
            {
                context.AddSource($"IDecomposedFrom{uniqueProperty.Type?.Name ?? "Aonymous"}.{uniqueProperty.Property}.g.cs", IDecomposedMarkerInterfaceDeclarationTemplate.Render(new DecomposedMemberModel(uniqueProperty.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat), uniqueProperty.Property)));
            }

            // declare all of the decomposed interfaces
            foreach ((TypeDeclarationSyntax? TypeFromWhichTheMemberComes, INamedTypeSymbol? SymbolOfTypeFromWhichTheMemberComes, ImmutableArray<MethodDeclarationSyntax?> Methods, ImmutableArray<PropertyDeclarationSyntax?> Properties) in values)
            {
                if (TypeFromWhichTheMemberComes is null || SymbolOfTypeFromWhichTheMemberComes is null)
                {
                    continue;
                }
                
                foreach(MethodDeclarationSyntax? method in Methods)
                {
                    if (method is null)
                    {
                        continue;
                    }

                    string returnType = method.ReturnType.ToFullString();
                    context.AddSource($"{SymbolOfTypeFromWhichTheMemberComes.Name}.{method.Identifier.ValueText}{(method.ConstraintClauses.Count() > 0 ? $"`<{method.ConstraintClauses.Count}>" : "")}.g.cs", 
                    DecomposedMethodDeclarationTemplate.Render(
                        new DecomposedMethodModel(
                            returnType, 
                            method.Identifier.ValueText, 
                            method.ParameterList.Parameters.Select(parameter => new DecomposedParameterModel(parameter.Type.ToFullString(), parameter.Identifier.ValueText)).ToArray(), 
                            method.ConstraintClauses.SelectMany(constraintClause => constraintClause.Constraints.Select(constraint => new DecomposedTypeConstraintModel(constraintClause.Name.ToString(), constraint.IsKind(SyntaxKind.ClassConstraint) ? "class" : constraint.IsKind(SyntaxKind.StructConstraint) ? "struct" : constraint.IsKind(SyntaxKind.ConstructorConstraint) ? "new()" : constraint.IsKind(SyntaxKind.TypeConstraint) ? constraint.ToString() : throw new NotSupportedException($"The constraint {constraint} is not supported.")))).ToArray())));
                }
            }
        }
    }
}

// public void AddClass(Type classType)
//         {
//             var members = GetDecomposableMembers(classType);

//             if (!members.Any())
//                 return;

//             var clsddName = $"{classType.Name}Decorator";
//             var interfaceType = new CodeTypeDeclaration(interfaceName);
//             interfaceType.IsInterface = true;

//             foreach (var member in members)
//             {
//                 var memberType = member.MemberType == MemberTypes.Property
//                     ? ((PropertyInfo)member).PropertyType
//                     : ((FieldInfo)member).FieldType;

//                 var memberName = member.Name.ToCamelCase();
//                 var interfaceMember = new CodeMemberProperty
//                 {
//                     Name = memberName,
//                     HasGet = true,
//                     Type = new CodeTypeReference(memberType),
//                 };
//                 interfaceType.Members.Add(interfaceMember);
//             }

//             codeNamespace.Types.Add(interfaceType);
//         }

//         public override string ToString()
//         {
//             var provider = CodeDomProvider.CreateProvider("CSharp");
//             var options = new CodeGeneratorOptions
//             {
//                 BracingStyle = "C",
//                 IndentString = "    ",
//             };

//             using (var writer = new System.IO.StringWriter())
//             {
//                 provider.GenerateCodeFromCompileUnit(compileUnit, writer, options);
//                 return writer.ToString();
//             }
//         }

//         private static IEnumerable<MemberInfo> GetDecomposableMembers(Type type)
//         {
//             return type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
//                 .Where(m => m.GetCustomAttribute<DecomposeAttribute>() != null);
//         }
//     }

//     public static class StringExtensions
//     {
//         public static string ToCamelCase(this string value)
//         {
//             if (string.IsNullOrEmpty(value))
//                 return value;
//             return char.ToLowerInvariant(value[0]) + value.Substring(1);
//         }
//     }
//     }
