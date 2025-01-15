// Copyright (c) DotNaut Ltd.
using System.Xml;

namespace DotNaut.Web.Sitemap;

public interface ISitemapRenderer
{
	Task WriteAsync(XmlWriter writer);
}
