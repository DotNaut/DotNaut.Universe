namespace DotNaut.Application.Composition;

/// <remarks>
/// TODO: Composition, besides its role for building an DI container, can be also responsible for
/// ogranazing CLI commands (command groups, e.g. <code>dotnet new list</code>), web application
/// routes (folders, e.g. "/accounts/cart").
/// </remarks>
public interface IComposition
{
	// TODO: ICompositionContext vs IServiceCollection?
	 void Compose(ICompositionContext context);
}
