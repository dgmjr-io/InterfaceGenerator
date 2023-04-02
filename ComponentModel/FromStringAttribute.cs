namespace System.ComponentModel.DataAnnotations;

/// <summary>
/// Marker attribute for properties of that can be created from a string.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class FromStringAttribute : Attribute {}
