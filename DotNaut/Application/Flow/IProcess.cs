namespace DotNaut.Application.Flow;

public interface IProcess<TInput, TProduct>
{
    TProduct Execute(TInput input);
}
