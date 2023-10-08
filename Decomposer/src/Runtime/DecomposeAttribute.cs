#nullable enable
[AttributeUsage(
    AttributeTargets.Class
        | AttributeTargets.Struct
        | AttributeTargets.Interface
        | AttributeTargets.Assembly
)]
public sealed class DecomposeAttribute(type type, string? @namespace = default) : Attribute
{
    public DecomposeAttribute(string? @namespace = default)
        : this(default!, @namespace) { }

    public type Type => type;
    public string? Namespace => @namespace;
}
