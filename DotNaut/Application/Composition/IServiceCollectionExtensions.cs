using Microsoft.Extensions.DependencyInjection;

namespace DotNaut.Application.Composition;

public static class IServiceCollectionExtensions
{
	public static IServiceCollection UseCompositions<T>(this IServiceCollection services)
	{
		var compositions = typeof(T)
			.Assembly
			.GetTypes()
			.Where(type => typeof(IComposition).IsAssignableFrom(type))
			.Select(Activator.CreateInstance)
			.OfType<IComposition>()
		;
		ICompositionContext context = new CompositionContext(services);

		foreach (var composition in compositions)
		{
			composition.Compose(context);
		}

		return services;
	}

	public static IServiceCollection UseComposition<T>(this IServiceCollection services)
		where T : IComposition, new()
	{
		var composition = new T();
		ICompositionContext context = new CompositionContext(services);
		composition.Compose(context);
		return services;
	}	
}
