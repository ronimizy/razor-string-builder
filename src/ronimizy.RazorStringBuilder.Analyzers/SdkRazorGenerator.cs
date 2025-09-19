// using Microsoft.AspNetCore.Razor.Language;
// using Microsoft.AspNetCore.Razor.Language.Components;
// using Microsoft.AspNetCore.Razor.Language.Extensions;
// using Microsoft.CodeAnalysis.Diagnostics;
// using Test.Phases;
//
// namespace RazorStringBuilder;
//
// public class SdkRazorGenerator : RazorSourceGeneratorBase
// {
//     protected override IRazorDocumentClassifierPass CreateClassifierPass(AnalyzerConfigOptions options)
//     {
//         return new CustomDocumentClassifierPass(options);
//     }
//
//     protected override void ConfigureEngineBuilder(RazorProjectEngineBuilder builder)
//     {
//         ImplementsDirective.Register(builder);
//         InheritsDirective.Register(builder);
//         NamespaceDirective.Register(builder);
//         AttributeDirective.Register(builder);
//
//         ComponentCodeDirective.Register(builder);
//         ComponentInjectDirective.Register(builder);
//         ComponentConstrainedTypeParamDirective.Register(builder);
//     }
// }