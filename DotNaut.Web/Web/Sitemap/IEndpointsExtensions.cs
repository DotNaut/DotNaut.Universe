// Copyright (c) DotNaut Ltd.
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DotNaut.Web.Sitemap;

public static class IEndpointsExtensions
{
	public static void MapSitemap<T>(this T endpoints)
		where T : IEndpointRouteBuilder
	{
		endpoints.MapGet(
			SitemapUrl.DefaultRoute,
			async (HttpContext context, ISitemapWriter renderer) => await renderer.WriteAsync(context)
		);
	}
}