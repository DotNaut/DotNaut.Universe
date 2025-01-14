using DotNaut.Ontology;
using Microsoft.AspNetCore.Components;

namespace DotNaut.Data.Sql;

public abstract class SqlObject
    : ComponentBase
    , ISqlSchemaObject
{
    public string EOL => Environment.NewLine;

    // TODO: Schema should be taken from the provider (ISqlConvention, etc). 
    //   But the whole procedure template can depends on the SQL provider. So it can be a part of this template as well.
    [Parameter]
    public string Schema { get; set; } = "dbo";

    [Parameter]
    public required string Name { get; set; }

    // TODO:Convention
    string INamed.Name => $"[{Schema}].[{Name}]";

    public string FullName => (this as INamed).Name;
}
