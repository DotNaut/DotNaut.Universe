// Copyright (c) DotNaut Ltd.
using Microsoft.Extensions.DependencyInjection;

namespace DotNaut.Web.Sitemap;

public static class IServiceCollectionExtensions
{
	public static IServiceCollection AddStaticSitemap<TProgram>(
		this IServiceCollection services,
		string baseUrl
	)
	{
		var scanner = new StaticSitemapScanner<TProgram>();
		var cached = new SitemapCachedScanner(scanner);

		services.AddSingleton<ISitemapScanner>(cached);
		services.AddSingleton<ISitemapWriter, SitemapWriter>();

		// TODO:
		// Better to create an IOptions<SitemapOptions> and inject it.
		// Is this a global setting for the site?
		services.AddSingleton(new SitemapOptions()
		{ 
			BaseUrl = new Uri(baseUrl)
		});

		return services;
	}
}
