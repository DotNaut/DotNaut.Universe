// Copyright (c) DotNaut Ltd.
namespace DotNaut.Web.Sitemap;

/// <summary>
/// Sitemap URL info
/// </summary>
public class SitemapUrl
{
	public const string DefaultRoute = "/sitemap.xml";

	/// <summary>
	/// Location URL
	/// </summary>
	/// <remarks>
	/// <para>
	/// URL of the page. This URL must begin with the protocol (such as http) and end with 
	/// a trailing slash, if your web server requires it. This value must be less than 
	/// 2,048 characters.
	/// </para>
	/// <para>
	/// TODO:Would be nice to demo how it can be used in Razor pages.
	/// </para>
	/// </remarks>
	public required string Location { get; set; }

	/// <summary>
	/// Lat modification of the page
	/// </summary>
	/// <remarks>
	/// <para>
	/// The date of last modification of the page. This date should be in 
	/// <a href="https://www.w3.org/TR/NOTE-datetime">W3C Datetime format</a>.
	/// This format allows you to omit the time portion, if desired, and use  YYYY-MM-DD.
	/// </para>
	/// <para>
	/// Note that the date must be set to the date the linked page was last modified, not when the 
	/// sitemap is generated.
	/// </para>
	/// <para>
	/// Note also that this tag is separate from the If-Modified-Since (304) header the server can 
	/// return, and search engines may use the information from both sources differently.
	/// </para>
	/// </remarks>
	public DateTime? LastModified { get; set; }

	/// <summary>
	/// Change frequency
	/// </summary>
	/// <remarks>
	/// <para>
	/// How frequently the page is likely to change. This value provides general information 
	/// to search engines and may not correlate exactly to how often they crawl the page.
	/// </para>
	/// <para>
	/// The value "always" should be used to describe documents that change each time they are 
	/// accessed. The value "never" should be used to describe archived URLs.
	/// </para>
	/// <para>
	/// Please note that the value of this tag is considered a hint and not a command.
	/// Even though search engine crawlers may consider this information when making decisions, 
	/// they may crawl pages marked "hourly" less frequently than that, and they may crawl 
	/// pages marked "yearly" more frequently than that. Crawlers may periodically crawl pages 
	/// marked "never" so that they can handle unexpected changes to those pages.
	/// </para>
	/// </remarks>
	public SitemapChangeFrequency? ChangeFrequency { get; set; }

	/// <summary>
	/// Priority
	/// </summary>
	/// 
	/// <remarks>
	/// <para>
	/// The priority of this URL relative to other URLs on your site. Valid values range from 
	/// 0.0 to 1.0. This value does not affect how your pages are compared to pages on other 
	/// sites—it only lets the search engines know which pages you deem most important for the
	/// crawlers.
	/// </para>
	/// <para>
	/// The default priority of a page is 0.5.
	/// </para>
	/// <para>
	/// Please note that the priority you assign to a page is not likely to influence the position 
	/// of your URLs in a search engine's result pages. Search engines may use this information 
	/// when selecting between URLs on the same site, so you can use this tag to increase the 
	/// likelihood that your most important pages are present in a search index.
	/// </para>
	/// <para>
	/// Also, please note that assigning a high priority to all of the URLs on your site is not 
	/// likely to help you.Since the priority is relative, it is only used to select between URLs 
	/// on your site.
	/// </para>
	/// </remarks>
	public double? Priority { get; set; }

	public static implicit operator SitemapUrl((string Location, string LastModified) sitemap) => new()
	{
		Location = sitemap.Location,
		LastModified = DateTime.Parse(sitemap.LastModified)
	};
}
