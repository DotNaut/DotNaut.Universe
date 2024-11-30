namespace DotNaut.Content;

public class RouteDiscovery<TItem>
	: IRouteDiscovery<TItem>
{
	//TODO:Caching in some Reflect tool

	IEnumerable<RouteDiscoveryItem<TItem>> IRouteDiscovery<TItem>.Discover(Type rootType)
	{
		var result = rootType
			.Assembly
			.GetTypes()
			//TODO:Filter by ComponentBase or better cache/prebuild the list of components
			//TODO:Maybe prebuild with route attribute. Some IComponentDiscovery/Repository would be nice.
			.Where(type => typeof(TItem).IsAssignableFrom(type))
			.Where(type => type.FullName?.StartsWith($"{rootType.Namespace}.") ?? false)
			.Select(Activator.CreateInstance)
			.Where(instance => instance != null)
			.Select(instance => new RouteDiscoveryItem<TItem>(instance!))
		;

		return result;
	}
}
