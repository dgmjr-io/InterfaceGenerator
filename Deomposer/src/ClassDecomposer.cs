using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


[Microsoft.CodeAnalysis.Gemerator]
public class DecomposableGenerator : IIncrementalGenerator
{
    public DecomposableGenerator(IncrementalGeneratorInitializationContext context)
    {
        var decomposableInterfaces = context.SyntaxProvider.SyntaxProvider.ForAttributeWithMetadataName(DecomposavbleAttributeName)
            .Where(x => x is InterfaceDeclarationSyntax)
            .Select(x => x as InterfaceDeclarationSyntax)
            .Where(x => x != null)
            .Select(x => x.Identifier.ValueText)
            .ToImmutableArray();

        decomposableClasses = context.SyntaxProvider.SyntaxProvider.ForAttributeWithMetadataName(DecomposavbleAttributeName)
                .Where(x => x is ClassDeclarationSyntax)
                .Select(x => x as ClassDeclarationSyntax)
                .Where(x => x != null)
                .Select(x => x.Identifier.ValueText)
                .ToImmutableArray();

        decomposableMethods = context.SyntaxProvider.SyntaxProvider.ForAttributeWithMetadataName(DecomposavbleAttributeName)
                .Where(x => x is ClassDeclarationSyntax)
                .Select(x => x as ClassDeclarationSyntax)
                .Where(x => x != null)
                .Select(x => x.Identifier.ValueText)
                .ToImmutableArray();
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        throw new NotImplementedException();
    }
}

// public void AddClass(Type classType)
//         {
//             var members = GetDecomposableMembers(classType);

//             if (!members.Any())
//                 return;

//             var interfaceName = $"{classType.Name}Decorator";
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
