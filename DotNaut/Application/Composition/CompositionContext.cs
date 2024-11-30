using Microsoft.Extensions.DependencyInjection;

namespace DotNaut.Application.Composition;

public class CompositionContext
	(IServiceCollection services)
	: ICompositionContext
{
	IServiceCollection ICompositionContext.Services => services;
}
