// Copyright (c) DotNaut Ltd.
using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace DotNaut.Web.Sitemap;

public static class ISitemapRendererExtensions
{
	public static async Task WriteAsync<TProgram>(
		this ISitemapRenderer renderer, 
		HttpContext context,
		SitemapOptions options
	)
	{
		context.Response.ContentType = "application/xml";

		var urls = typeof(TProgram)
			.Assembly
			.GetTypes()
			.Where(type => typeof(ISitemapUrl).IsAssignableFrom(type))
			.Where(type => !type.IsInterface && !type.IsAbstract)
			.Select(type => Activator.CreateInstance(type) as ISitemapUrl)
			.Where(url => url != null)
			.Cast<ISitemapUrl>()
		;

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

		await renderer.WriteAsync(xmlWriter, options, urls);
	}
}
