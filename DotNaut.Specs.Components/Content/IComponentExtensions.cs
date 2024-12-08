using Microsoft.AspNetCore.Components;

namespace DotNaut.Content;

public static class IComponentExtensions
{
	public static MarkupString Resource(this IComponent component, string name)
	{
		var type = component.GetType();

		using var stream = type.Assembly.GetManifestResourceStream(type, name);
		if (stream == null)
		{
			throw new ArgumentException($"Resource `{name}` not found for the {type.FullName}");
		}

		using var reader = new StreamReader(stream);

		return (MarkupString)reader.ReadToEnd();

	}
}
