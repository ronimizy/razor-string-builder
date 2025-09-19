using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace ronimizy.RazorStringBuilder.Analyzers.Custom;

public class CustomCodeTarget : DefaultCodeTarget
{
    public CustomCodeTarget(
        RazorCodeGenerationOptions options,
        IEnumerable<ICodeTargetExtension> extensions)
        : base(options, extensions) { }

    public override IntermediateNodeWriter CreateNodeWriter()
    {
        return new RazorStringBuilderNodeWriter();
    }
}
