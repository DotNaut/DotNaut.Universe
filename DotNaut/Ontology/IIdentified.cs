// Copyright (c) DotNaut Ltd.
namespace DotNaut.Ontology;

/// <remarks>
/// Something with identified
/// </remarks>
public interface IIdentified<T>
{
    T Id { get; }
}
