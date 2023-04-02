namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// For marking an item with a file extension.
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public sealed class FileExtensionAttribute : ValueAttribute<string[]>
{
    public FileExtensionAttribute(params string[] extensions) : base((extensions.Select(extension => (!extension.StartsWith(".") ? "." : "") + extension)).ToArray()) { }

    /// <summary>
    /// The extensions with the leading dot.
    /// </summary>
    /// <value><inheritdoc cref="Extension" path="/summary/node()"/></value>
    public string[] Extensions => Value;

    /// <summary>
    /// The first extension with the leading dot.
    /// </summary>
    /// <value><inheritdoc cref="Extension" path="/summary/node()"/></value>
    public string? Extension => Value?.FirstOrDefault();
}
