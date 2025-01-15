// Copyright (c) DotNaut Ltd.
using System.Reflection;

namespace DotNaut.Web.Sitemap;

public class AssemblySitemapScanner
	: ISitemapScanner
{
	private readonly IEnumerable<Assembly> _assemblies;

	public AssemblySitemapScanner(params IEnumerable<Assembly> assemblies)
	{
		_assemblies = assemblies;
	}

	Task<IEnumerable<ISitemapUrl>> ISitemapScanner.ScanAsync()
	{
		var urls = _assemblies
			.SelectMany(assembly => assembly.GetTypes())
			.Where(type => typeof(ISitemapUrl).IsAssignableFrom(type))
			.Where(type => !type.IsInterface && !type.IsAbstract)
			.Select(type => Activator.CreateInstance(type) as ISitemapUrl)
			.Where(url => url != null)
			.Cast<ISitemapUrl>()
		;

		return Task.FromResult(urls);
	}
}

public class AssemblySitemapScanner<T>
	: AssemblySitemapScanner
{
	public AssemblySitemapScanner()
		: base(typeof(T).Assembly)
	{

	}
}
