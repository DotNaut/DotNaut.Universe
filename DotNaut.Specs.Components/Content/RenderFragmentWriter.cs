using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components;

namespace DotNaut.Content;

/// <summary>
/// TODO:This implementation is merely a hack.
/// </summary>
public class RenderFragmentWriter
	: IRenderFragmentWriter
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0006", Justification = "Experimental implementation.")]
	public void Write(RenderFragment fragment, TextWriter writer)
	{
		var builder = new RenderTreeBuilder();
		fragment.Invoke(builder);

		var frames = builder.GetFrames().Array;
		foreach (var frame in frames)
		{
			switch (frame.FrameType)
			{
				//TODO:I had an implementation in StanEgo sources.
				case RenderTreeFrameType.Text:
					writer.Write(frame.TextContent);
					break;
				// case RenderTreeFrameType.Element:
				//     writer.Write($"<{frame.ElementName}>");
				//     Write(frame, writer);
				//     writer.Write($"</{frame.ElementName}>");
				//     break;
				// case RenderTreeFrameType.Component:
				//     writer.Write($"<{frame.ComponentType.FullName}>");
				//     Write(frame, writer);
				//     writer.Write($"</{frame.ComponentType.FullName}>");
				//     break;
				case RenderTreeFrameType.None:
					break;
				default:
					throw new NotSupportedException($"Frame type {frame.FrameType} not supported");
			}
		}
	}
}
