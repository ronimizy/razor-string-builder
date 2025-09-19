using System;
using System.Text;
using CustomNamespace.Folder;

var query = new UpdateQuery { Data = "aa" };

var builder = new StringBuilder();
query.Build(builder);

Console.Clear();
Console.WriteLine(builder.ToString());
