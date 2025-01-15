// Copyright (c) DotNaut Ltd.
using System.Xml;

namespace DotNaut.Web.Sitemap;

public interface ISitemapWriter
{
	Task WriteAsync(XmlWriter writer);
}
