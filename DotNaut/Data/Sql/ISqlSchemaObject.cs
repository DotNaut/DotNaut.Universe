// Copyright (c) DotNaut Ltd.
using DotNaut.Ontology;

namespace DotNaut.Data.Sql;

public interface ISqlSchemaObject
    : INamed
{
    string Schema { get; }
}
