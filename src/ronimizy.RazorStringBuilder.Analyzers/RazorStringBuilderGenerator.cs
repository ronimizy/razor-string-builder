using System.Linq;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using ronimizy.Razor.Sdk;
using ronimizy.RazorStringBuilder.Analyzers.Custom;

namespace ronimizy.RazorStringBuilder.Analyzers;

[Generator]
public class RazorStringBuilderGenerator : RazorSourceGeneratorBase
{
    protected override IRazorDocumentClassifierPass CreateClassifierPass(RazorSdkProjectItem projectItem)
        => new CustomDocumentClassifierPass(projectItem);

    protected override bool OnCodeDocumentCreated(
        RazorSdkProjectItem projectItem,
        RazorCodeDocument codeDocument,
        SyntaxNode syntaxNode,
        SourceProductionContext context)
    {
        return syntaxNode
            .DescendantNodes()
            .OfType<BaseTypeSyntax>()
            .Any(x => x.Type.ToString().EndsWith("RazorStringBuilderBase"));
    }
}

file static class Extensions
{
    public static string ToDisplayString(this AnalyzerConfigOptions options)
    {
        return string.Join(
            "\n",
            options.Keys.Select(key => $"{key}={(options.TryGetValue(key, out var value) ? value : "null")}"));
    }
}
