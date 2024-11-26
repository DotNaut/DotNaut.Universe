using Microsoft.AspNetCore.Components;

namespace DotNaut.Content;

public interface IRenderFragmentWriter
{
	void Write(RenderFragment fragment, TextWriter writer);
}
