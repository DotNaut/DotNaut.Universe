// Copyright (c) DotNaut Ltd.
using System.Reflection;

namespace DotNaut.Web.Sitemap;

public class StaticSitemapScanner
	: ISitemapScanner
{
	private readonly IEnumerable<Assembly> _assemblies;

	public StaticSitemapScanner(params IEnumerable<Assembly> assemblies)
	{
		_assemblies = assemblies;
	}

	Task<IEnumerable<SitemapUrl>> ISitemapScanner.ScanAsync()
	{
		var urls = _assemblies
			.SelectMany(assembly => assembly.GetTypes())
			.Select(IStaticSitemapItem.Get)
			.Where(url => url != null)
			.Select(url => url!)
		;

		return Task.FromResult(urls);
	}
}

public class StaticSitemapScanner<T>
	: StaticSitemapScanner
{
	public StaticSitemapScanner()
		: base(typeof(T).Assembly)
	{

	}
}
