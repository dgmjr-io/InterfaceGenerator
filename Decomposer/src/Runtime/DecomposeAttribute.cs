[global::System.AttributeUsage(
    global::System.AttributeTargets.Class
        | global::System.AttributeTargets.Struct
        | global::System.AttributeTargets.Interface
        | global::System.AttributeTargets.Assembly
)]
public sealed class DecomposeAttribute : global::System.Attribute
{
    public DecomposeAttribute(string @namespace = null) { }

    public DecomposeAttribute(global::System.Type type, string @namespace = null) { }
}
