using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.HtmlRendering;

namespace DotNaut.Content;

public class ComponentRenderer
	: IComponentRenderer
{
	private readonly HtmlRenderer _htmlRenderer;
	public ComponentRenderer(HtmlRenderer htmlRenderer)
	{
		_htmlRenderer = htmlRenderer;
	}

	Task<string> IComponentRenderer.RenderComponent<T>(ParameterView parameters)
	{
		// Use the default dispatcher to invoke actions in the context of the 
		// static HTML renderer and return as a string
		return _htmlRenderer.Dispatcher.InvokeAsync(async () =>
		{
			HtmlRootComponent output = await _htmlRenderer.RenderComponentAsync<T>(parameters);
			return output.ToHtmlString();
		});
	}
}
