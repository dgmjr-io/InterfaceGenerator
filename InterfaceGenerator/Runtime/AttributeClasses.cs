namespace System;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class GenerateInterfaceAttribute : Attribute
{
    public Type Type { get; }

    public GenerateInterfaceAttribute(Type type = null)
    {
        {
            Type = type;
        }
    }
}
