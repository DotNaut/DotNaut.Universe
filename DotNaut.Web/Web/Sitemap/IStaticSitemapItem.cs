// Copyright (c) DotNaut Ltd.
using System.Reflection;

namespace DotNaut.Web.Sitemap;

public interface IStaticSitemapItem
{
	static abstract SitemapUrl Sitemap { get; }

	public static SitemapUrl? Get(Type type)
	{
		if (type.IsInterface || type.IsAbstract)
		{
			return null;
		}

		if (!typeof(IStaticSitemapItem).IsAssignableFrom(type))
		{
			return null;
		}

		var method = GenericMethod.MakeGenericMethod(type);

		return (SitemapUrl?)method.Invoke(null, null);
	}

	private static SitemapUrl? GetGeneric<T>()
		where T : IStaticSitemapItem
	{
		return T.Sitemap;
	}

	private static readonly MethodInfo GenericMethod = typeof(IStaticSitemapItem)
		.GetMethod(nameof(GetGeneric), BindingFlags.NonPublic | BindingFlags.Static)!
	;
}
