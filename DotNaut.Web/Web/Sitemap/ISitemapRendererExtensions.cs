// Copyright (c) DotNaut Ltd.
using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace DotNaut.Web.Sitemap;

public static class ISitemapRendererExtensions
{
	public static async Task WriteAsync(
		this ISitemapRenderer renderer, 
		HttpContext context
	)
	{
		context.Response.ContentType = "application/xml";

		await using var responseStream = context.Response.BodyWriter.AsStream();
		using var xmlWriter = XmlWriter.Create(
			responseStream,
			new XmlWriterSettings
			{
				Async = true,
				Indent = true,
				Encoding = Encoding.UTF8,
			}
		);

		await renderer.WriteAsync(xmlWriter);
	}
}
