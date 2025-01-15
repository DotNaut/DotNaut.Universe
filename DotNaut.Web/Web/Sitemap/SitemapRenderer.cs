// Copyright (c) DotNaut Ltd.
using System.Xml;

namespace DotNaut.Web.Sitemap;

public class SitemapRenderer
	: ISitemapRenderer
{
	private readonly SitemapOptions _options;
	private readonly ISitemapScanner _scanner;

	public SitemapRenderer(SitemapOptions options, ISitemapScanner scanner)
	{
		_options = options;
		_scanner = scanner;
	}

	public async Task WriteAsync(XmlWriter writer)
	{
		async Task WritePropertyAsync(string elementName, string? value)
		{
			if (value != null)
			{
				await writer.WriteElementStringAsync(null, elementName, null, value);
			}
		}

		await writer.WriteStartDocumentAsync();
		await writer.WriteStartElementAsync(null, "urlset", NamespaceInfo.SchemaNamespace);
		foreach (var url in await _scanner.ScanAsync())
		{
			if (url != null)
			{
				await writer.WriteStartElementAsync(null, "url", null);

				var uri = Uri.IsWellFormedUriString(url.Location, UriKind.Absolute)
					? new Uri(url.Location)
					: new Uri(_options.BaseUrl, url.Location)
				;

				await writer.WriteElementStringAsync(null, "loc", null, uri.ToString());

				await WritePropertyAsync(ISitemapUrl.XmlTagLastModified, url.LastModified?.ToString("yyyy-MM-dd"));
				await WritePropertyAsync(ISitemapUrl.XmlTagChangeFrequency, url.ChangeFrequency?.ToString().ToLowerInvariant());

				await writer.WriteEndElementAsync();
			}
		}
		await writer.WriteEndElementAsync();
		await writer.WriteEndDocumentAsync();
	}
}
