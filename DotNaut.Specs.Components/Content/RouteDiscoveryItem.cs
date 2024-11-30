using Microsoft.AspNetCore.Components;

namespace DotNaut.Content;

public class RouteDiscoveryItem<TItem>
{
    public TItem Item { get; }
    public RouteAttribute? Route { get; }

	internal RouteDiscoveryItem(object instance)
	{
		Item = (TItem)instance;
		Route = instance
			.GetType()
			.GetCustomAttributes(false)
			.OfType<RouteAttribute>()
			.FirstOrDefault()
		;
	}
}
