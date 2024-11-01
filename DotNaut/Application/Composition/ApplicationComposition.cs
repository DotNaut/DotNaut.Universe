namespace DotNaut.Application.Composition;

/// <remarks>
/// TODO:Experiment to define basic application skeleton.
/// </remarks>
public class ApplicationComposition
    : IComposition
{
    public required IComposition Security { get; init; }

    void IComposition.Compose(ICompositionContext context)
    {
        throw new NotImplementedException();
    }
}
