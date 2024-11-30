using Microsoft.Extensions.DependencyInjection;

namespace DotNaut.Application.Composition;

/// <summary>
/// TODO:Context can help to make DI container more flexible and replaceable.
/// </summary>
public interface ICompositionContext
{
	/// <remarks>
	/// TODO:IServiceCollection is temporary exposed, but probably it will be a specific
	/// implementation.
	/// </remarks>
	IServiceCollection Services { get; }
}
