using DotNaut.Ontology;

namespace DotNaut.Data.Sql;

public interface ISqlSchemaObject
    : INamed
{
    string Name { get; }

    string Schema { get; }
}
