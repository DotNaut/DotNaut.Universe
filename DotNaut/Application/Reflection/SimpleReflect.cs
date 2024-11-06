using System.Reflection;

namespace DotNaut.Application.Reflection;

public class SimpleReflect<T>
    : IReflect<T>
{
    IEnumerable<PropertyInfo> IReflect<T>.GetProperties()
    {
        return typeof(T).GetProperties();
    }
}
