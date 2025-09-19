// using System.Text;
// using CustomNamespace.folder;
//
// namespace MyNamespace;
//
// public partial class TableUpdate : RazorStringBuilder
// {
//     public override void Build(StringBuilder builder)
//     {
//         builder.Append("\nupdate table\nset updated_at = now()\n");
//         if (string.IsNullOrEmpty(Data) is false)
//         {
//             builder.Append("    ");
//             builder.Append(", data = :data\n");
//         }
//
//         builder.Append("where id = :id\n\n");
//     }
//
//     public required string? Data { get; set; }
// }
//
// public partial class TableUpdate { }
