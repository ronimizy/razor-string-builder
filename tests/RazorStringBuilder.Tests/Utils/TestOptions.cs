// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Test.Tests.Utils;

public class TestOptions : AnalyzerConfigOptions
{
    private readonly Dictionary<string, string> _values = [];

    public override bool TryGetValue(string key, [NotNullWhen(true)] out string? value)
    {
        return _values.TryGetValue(key, out value);
    }

    public string this[string key]
    {
        set => _values[key] = value;
    }

    public override IEnumerable<string> Keys => _values.Keys;
}
