using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace ronimizy.RazorStringBuilder.Analyzers.Custom;

public class RazorStringBuilderNodeWriter : IntermediateNodeWriter
{
    public override void WriteUsingDirective(CodeRenderingContext context, UsingDirectiveIntermediateNode node)
        => context.CodeWriter.WriteUsing(node.Content);

    public override void WriteCSharpExpression(CodeRenderingContext context, CSharpExpressionIntermediateNode node)
        => WriteValue(context, node);

    public override void WriteMarkupElement(CodeRenderingContext context, MarkupElementIntermediateNode node)
        => WriteContent(context, node);

    public override void WriteMarkupBlock(CodeRenderingContext context, MarkupBlockIntermediateNode node)
        => WriteContent(context, node);

    public override void WriteCSharpCode(CodeRenderingContext context, CSharpCodeIntermediateNode node)
        => WriteCode(context, node);

    public override void WriteHtmlContent(CodeRenderingContext context, HtmlContentIntermediateNode node)
        => WriteContent(context, node);

    public override void WriteHtmlAttribute(CodeRenderingContext context, HtmlAttributeIntermediateNode node)
        => WriteContent(context, node);

    public override void WriteHtmlAttributeValue(CodeRenderingContext context, HtmlAttributeValueIntermediateNode node)
        => WriteContent(context, node);

    public override void WriteComponent(CodeRenderingContext context, ComponentIntermediateNode node)
        => context.CodeWriter.Write(node.TagName);

    public override void WriteComponentChildContent(
        CodeRenderingContext context,
        ComponentChildContentIntermediateNode node) { }

    public override void WriteCSharpExpressionAttributeValue(
        CodeRenderingContext context,
        CSharpExpressionAttributeValueIntermediateNode node) { }

    public override void WriteCSharpCodeAttributeValue(
        CodeRenderingContext context,
        CSharpCodeAttributeValueIntermediateNode node) { }

    public override void BeginWriterScope(CodeRenderingContext context, string writer) { }
    public override void EndWriterScope(CodeRenderingContext context) { }

    private static void WriteCode(CodeRenderingContext context, IntermediateNode node)
    {
        using (context.BuildLinePragma(node.Source, suppressLineDefaultAndHidden: true))
        {
            foreach (IntermediateNode child in node.Children)
            {
                if (child is CSharpIntermediateToken token)
                {
                    context.CodeWriter.Write(token.Content);
                }
                else
                {
                    context.RenderNode(child);
                }
            }

            context.CodeWriter.WriteLine();
        }
    }

    private static void WriteContent(CodeRenderingContext context, IntermediateNode node)
    {
        using (context.BuildLinePragma(node.Source, suppressLineDefaultAndHidden: true))
        {
            context.CodeWriter.Write("builder.Append(\"");

            foreach (IntermediateNode child in node.Children)
            {
                if (child is HtmlIntermediateToken token)
                {
                    context.CodeWriter.Write(token.Content.Replace("\n", "\\n"));
                }
            }

            context.CodeWriter.WriteLine("\");");
        }
    }

    private static void WriteValue(CodeRenderingContext context, IntermediateNode node)
    {
        using (context.BuildLinePragma(node.Source, suppressLineDefaultAndHidden: true))
        {
            context.CodeWriter.Write("builder.Append(");

            foreach (IntermediateNode child in node.Children)
            {
                if (child is CSharpIntermediateToken token)
                {
                    context.CodeWriter.Write(token.Content);
                }
                else
                {
                    context.RenderNode(child);
                }
            }

            context.CodeWriter.WriteLine(");");
        }
    }
}
