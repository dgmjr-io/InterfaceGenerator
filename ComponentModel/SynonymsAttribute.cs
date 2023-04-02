namespace System.ComponentModel.DataAnnotations;

public sealed class SynonymsAttribute : ValueAttribute<string[]>
{
    public SynonymsAttribute(params string[] synonyms)
        : base(synonyms)
    {
    }

    public string[] Synonyms => Value;
}
