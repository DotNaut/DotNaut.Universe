// Copyright (c) DotNaut Ltd.
using DotNaut.Application.Flow;

namespace DotNaut.Data.Sql;

public interface ISqlConvention<TRequest, TProduct>
    : IProcess<TRequest, TProduct>
{

}

public interface ISqlConvention<TRequest>
    : IProcess<TRequest, string>
{

}
