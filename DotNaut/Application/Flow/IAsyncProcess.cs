namespace DotNaut.Application.Flow;

public interface IAsyncProcess<TInput, TProduct>
    // TODO:How is it better to abstract Task/ValueTask? They have not shared interface.
    : IProcess<TInput, Task<TProduct>>
{
    
}
