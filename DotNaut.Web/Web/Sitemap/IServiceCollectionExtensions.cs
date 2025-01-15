// Copyright (c) DotNaut Ltd.
using Microsoft.Extensions.DependencyInjection;

namespace DotNaut.Web.Sitemap;

public static class IServiceCollectionExtensions
{
	public static IServiceCollection AddSitemap<TProgram>(
		this IServiceCollection services,
		string baseUrl
	)
	{
		services.AddSingleton<ISitemapRenderer, SitemapRenderer>();
		services.AddSingleton<ISitemapScanner, AssemblySitemapScanner<TProgram>>();
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
