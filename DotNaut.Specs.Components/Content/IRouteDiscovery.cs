namespace DotNaut.Content;

public interface IRouteDiscovery<TItem>
{
	public IEnumerable<RouteDiscoveryItem<TItem>> Discover(Type rootType);

	public IEnumerable<RouteDiscoveryItem<TItem>> Discover<TRoot>() => Discover(typeof(TRoot));
}
