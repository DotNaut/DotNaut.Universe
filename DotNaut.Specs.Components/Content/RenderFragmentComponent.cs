using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace DotNaut.Content;

public class RenderFragmentComponent
	: ComponentBase
{
	[Parameter]
	public required RenderFragment ChildContent { get; set; }

	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		builder.AddContent(0, ChildContent);
	}
}
