// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Test.Tests.Utils;

public class TestOptionsProvider : AnalyzerConfigOptionsProvider
{
    private readonly Dictionary<AdditionalText, AnalyzerConfigOptions> _textOptions;
    private readonly Dictionary<SyntaxTree, AnalyzerConfigOptions> _treeOptions;

    public TestOptionsProvider(AnalyzerConfigOptions globalOptions)
    {
        GlobalOptions = globalOptions;

        _textOptions = [];
        _treeOptions = [];
    }

    public override AnalyzerConfigOptions GlobalOptions { get; }

    public override AnalyzerConfigOptions GetOptions(SyntaxTree tree)
    {
        return _treeOptions[tree];
    }

    public override AnalyzerConfigOptions GetOptions(AdditionalText textFile)
    {
        return _textOptions[textFile];
    }

    public AnalyzerConfigOptions this[SyntaxTree tree]
    {
        set => _treeOptions[tree] = value;
    }

    public AnalyzerConfigOptions this[AdditionalText text]
    {
        set => _textOptions[text] = value;
    }
}
