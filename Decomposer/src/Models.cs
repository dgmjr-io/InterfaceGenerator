using System.Reflection;
/*
 * Models.cs
 *
 *   Created: 2023-04-08-03:02:41
 *   Modified: 2023-04-08-03:02:41
 *
 *   Author: David G. Moore, Jr. <david@io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Reflection.Metadata;
using DecomposedMethodTuple = (
    string Name,
    InterfaceGenerator.Decomposer.Models.DecomposedMethod[] Methods
);
using DecomposedPropertyTuple = (
    string Name,
    InterfaceGenerator.Decomposer.Models.DecomposedProperty[] Properties
);
using DecomposedMemberTuple = (
    string Name,
    string ContainingType,
    string Namespace,
    string[] Declarations
);

namespace InterfaceGenerator.Decomposer.Models
{
    public record struct DecomposedType(INamedTypeSymbol Type)
    {
        public string Namespace => Type.ContainingNamespace.ToDisplayString();
    public string Name => Type.MetadataName;
    public DecomposedMethodTuple[] Methods =>
        Type.GetMembers()
            .Where(member => member is IMethodSymbol method && method.IsAccessor())
            .Select(method => new DecomposedMethod((method as IMethodSymbol)!))
            .GroupBy(method => method.Name, StringComparer.OrdinalIgnoreCase)
            .Select(group => (group.Key, group.ToArray()))
            .ToArray();
    public DecomposedPropertyTuple[] Properties =>
        Type.GetMembers()
            .Where(member => member is IPropertySymbol)
            .Select(property => new DecomposedProperty((property as IPropertySymbol)!))
            .GroupBy(method => method.Name, StringComparer.OrdinalIgnoreCase)
            .Select(group => (group.Key, group.ToArray()))
            .ToArray();

    public DecomposedMemberTuple[] Members
    {
        get
        {
            var @this = this;
            return Methods
                .Select(
                    method =>
                        (
                            method.Name,
                            @this.Type.MetadataName,
                            @this.Type.ContainingNamespace.ToDisplayString(),
                            method.Methods
                                .Select(declaration => declaration.Declaration)
                                .ToArray()
                        )
                )
                .Concat(
                    Properties.Select(
                        property =>
                            (
                                property.Name,
                                @this.Type.ContainingType.MetadataName,
                                @this.Type.ContainingNamespace.ToDisplayString(),
                                property.Properties
                                    .Select(declaration => declaration.Declaration)
                                    .ToArray()
                            )
                    )
                )
                .ToArray();
        }
    }
}

public record struct DecomposedMethod(IMethodSymbol Method)
    {
        public string Namespace => Method.ContainingType.ContainingNamespace.ToDisplayString();
public string ContainingType => Method.ContainingType.MetadataName;
public string Name => Method.Name;
public string ReturnType => Method.ReturnType.ToDisplayString();
public string Declaration => Method.ToDisplayString(Constants.SymbolDisplayFormat);
    }

    public record struct DecomposedProperty(IPropertySymbol Property)
    {
        public string Namespace => Property.ContainingType.ContainingNamespace.ToDisplayString();
public string ContainingType => Property.ContainingType.MetadataName;
public string Name => Property.Name;
public string Type => Property.Type.ToDisplayString();
public string Declaration => Property.ToDisplayString(Constants.SymbolDisplayFormat);
    }
}
