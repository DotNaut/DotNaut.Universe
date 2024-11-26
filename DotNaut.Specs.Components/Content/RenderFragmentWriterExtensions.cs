using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace DotNaut.Content;

public static class RenderFragmentWriterExtensions
{

	private static readonly FieldInfo? _fieldInfo = typeof(RenderTreeFrame)
		.GetField("_renderFragment", BindingFlags.NonPublic | BindingFlags.Instance)
	;

	public static void Write(this IRenderFragmentWriter writer, ComponentBase component, StreamWriter stream)
	{
		if (_fieldInfo == null)
		{
			throw new ApplicationException();
		}

		var fragment = _fieldInfo.GetValue(component) as RenderFragment;
		if (fragment == null)
		{
			throw new ApplicationException();
		}

		writer.Write(fragment, stream);
	}

	public static string Stringify(this IRenderFragmentWriter writer, RenderFragment fragment)
	{
		using var stream = new StringWriter();
		writer.Write(fragment, stream);
		return stream.ToString();
	}
}
