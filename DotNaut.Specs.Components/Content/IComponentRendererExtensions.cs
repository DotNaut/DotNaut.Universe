using Microsoft.AspNetCore.Components;

namespace DotNaut.Content;

public static class IComponentRendererExtensions
{
	public static Task<string> RenderComponent<T>(
		this IComponentRenderer renderer,
		Dictionary<string, object?> dictionary
	) 
		where T : IComponent
		=> renderer.RenderComponent<T>(ParameterView.FromDictionary(dictionary))
	;

	public static Task<string> RenderComponent<T>(this IComponentRenderer renderer)
		where T : IComponent
		=> renderer.RenderComponent<T>(ParameterView.Empty)
	;

	public static Task<string> RenderFragment(this IComponentRenderer renderer, RenderFragment fragment)
	{
		Dictionary<string, object?> args = new()
		{
			{ nameof(RenderFragmentComponent.ChildContent), fragment }
		};

		return renderer.RenderComponent<RenderFragmentComponent>(args);
	}
}
