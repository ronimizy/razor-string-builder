using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using ronimizy.Razor.Sdk;

namespace ronimizy.RazorStringBuilder.Analyzers.Custom;

public class CustomDocumentClassifierPass(RazorSdkProjectItem projectItem) : DocumentClassifierPassBase
{
    protected override bool IsMatch(
        RazorCodeDocument codeDocument,
        DocumentIntermediateNode documentNode)
    {
        return codeDocument.FileKind.IsComponent();
    }

    protected override CodeTarget CreateTarget(
        RazorCodeDocument codeDocument,
        RazorCodeGenerationOptions options)
    {
        return new CustomCodeTarget(options, TargetExtensions);
    }

    protected override string DocumentKind => "RazorStringBuilder";

    protected override void OnDocumentStructureCreated(
        RazorCodeDocument codeDocument,
        NamespaceDeclarationIntermediateNode ns,
        ClassDeclarationIntermediateNode cls,
        MethodDeclarationIntermediateNode method)
    {
        ns.Name = projectItem.HintNamespace;

        cls.Modifiers = cls.Modifiers.Add("public").Add("partial");
        cls.Name = projectItem.HintClassName;

        method.Modifiers = method.Modifiers.Add("public").Add("override");
        method.ReturnType = "void";
        method.Name = "Build";

        var methodParameter = new MethodParameter("builder", "global::System.Text.StringBuilder");
        method.Parameters = method.Parameters.Add(methodParameter);
    }
}
