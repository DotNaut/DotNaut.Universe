// Copyright (c) DotNaut Ltd.
namespace DotNaut.Web.Sitemap;

public interface ISitemapScanner
{
	Task<IEnumerable<ISitemapUrl>> ScanAsync();
}
