namespace System;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class GenerateInterfaceAttribute(Type? type = default) : Attribute
{
    public type Type { get; } = type;
}
