# RazorStringBuilder

![NuGet Version](https://img.shields.io/nuget/v/ronimizy.RazorStringBuilder)

### UpdateQuery.razor

```razorhtmldialect
@inherits ronimizy.RazorStringBuilder.RazorStringBuilderBase

update table
set updated_at = now()
@if (string.IsNullOrEmpty(Data) is false)
{
    @:, data = '@Data'
}
where id = :id

@code {
    public required string? Data { get; set; }
}
```