namespace Dgmjr.Tuples;
using System;

/// <summary>
/// The uri string tuple.
/// </summary>
public abstract class UriStringTuple : Tuple<uri?, string?>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UriStringTuple"/> class.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <param name="value">The value.</param>
    public UriStringTuple(uri? uri = default, string? value = default) : base(uri, value) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="UriStringTuple"/> class.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <param name="value">The value.</param>
    public UriStringTuple(Uri? uri = default, string? value = default) : base(uri?.ToString()?.CreateUri(false), value) { }
    /// <summary>
    /// Gets the uri.
    /// </summary>
    public uri? Uri => Item1;
    /// <summary>
    /// Initializes a new instance of the <see cref="UriStringTuple"/> class.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <param name="value">The value.</param>
    public UriStringTuple(string? uri = default, string? value = default) : this(uri?.ToUri(), value) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="UriStringTuple"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public UriStringTuple(UriStringTuple? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
#if NETSTANDARD2_0_OR_GREATER
    public UriStringTuple((uri?, string?)? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
    public UriStringTuple((string?, string?)? tuple = default) : this(tuple?.Item1, tuple?.Item2) { }
#endif
    /// <summary>
    /// Initializes a new instance of the <see cref="UriStringTuple"/> class.
    /// </summary>
    public UriStringTuple() : this(null as uri, null as string) { }
}

/// <summary>
/// The uri description tuple.
/// </summary>
public abstract class UriDescriptionTuple : UriStringTuple
{
    /// <summary>
    /// Gets the description.
    /// </summary>
    public virtual string? Description => Item2;
    /// <summary>
    /// Initializes a new instance of the <see cref="UriDescriptionTuple"/>
    /// class.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <param name="description">The description.</param>
    protected UriDescriptionTuple(uri? uri, string? description = default) : base(uri, description) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="UriDescriptionTuple"/>
    /// class.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <param name="description">The description.</param>
    protected UriDescriptionTuple(Uri? uri, string? description = default) : base(uri, description) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="UriDescriptionTuple"/>
    /// class.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <param name="description">The description.</param>
    protected UriDescriptionTuple(string uri, string? description = default) : this(uri.ToUri(), description) { }
#if NETSTANDARD2_0_OR_GREATER
    protected UriDescriptionTuple((uri?, string?)? tuple = default) : base(tuple?.Item1, tuple?.Item2) { }
    protected UriDescriptionTuple((string?, string?)? tuple = default) : base(tuple?.Item1, tuple?.Item2) { }

#endif
    public static implicit operator string?(UriDescriptionTuple tuple) => tuple.Uri.ToString();
    public static implicit operator uri?(UriDescriptionTuple tuple) => tuple.Uri;
}
