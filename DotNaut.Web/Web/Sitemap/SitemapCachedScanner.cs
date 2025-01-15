// Copyright (c) DotNaut Ltd.

namespace DotNaut.Web.Sitemap;

public class SitemapCachedScanner(ISitemapScanner scanner)
	: ISitemapScanner
{
	private IEnumerable<SitemapUrl>? _cachedUrls;

	async Task<IEnumerable<SitemapUrl>> ISitemapScanner.ScanAsync()
	{
		return _cachedUrls = _cachedUrls ?? await scanner.ScanAsync();
	}
}
