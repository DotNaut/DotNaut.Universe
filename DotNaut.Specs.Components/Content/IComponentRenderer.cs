using Microsoft.AspNetCore.Components;

namespace DotNaut.Content;

public interface IComponentRenderer
{
	Task<string> RenderComponent<T>(ParameterView parameters) where T : IComponent;
}
