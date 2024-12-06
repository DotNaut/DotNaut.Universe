using DotNaut.Application.Composition;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;

namespace DotNaut.Content;

public class RendererComposition
	: IComposition
{
	void IComposition.Compose(ICompositionContext context)
	{
		context
			.Services
			.AddScoped<HtmlRenderer>()
			.AddScoped<IComponentRenderer, ComponentRenderer>()
		;
	}
}
