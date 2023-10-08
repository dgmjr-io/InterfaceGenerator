using System.Text;
using Microsoft.CodeAnalysis.Text;

namespace InterfaceGenerator.Decomposer;

#if DEBUG
internal static class Log
{
    public static List<string> Logs { get; } = new();

    public static void Print(string msg) => Logs.Add("//\t" + msg);

    // More print methods ...

    public static void FlushLogs(GeneratorExecutionContext context)
    {
        context.AddSource("logs.g.cs", SourceText.From(Join("\n", Logs), Encoding.UTF8));
    }

    public static void FlushLogs(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(
            ctx => ctx.AddSource("logs.g.cs", SourceText.From(Join("\n", Logs), Encoding.UTF8))
        );
    }
}
#endif
