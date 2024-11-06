using System.Reflection;

namespace DotNaut.Application.Reflection;

/// <summary>
/// TODO:
/// </summary>
/// <typeparam name="T"></typeparam>
/// 
/// <remarks>
/// This implementation of reflection is DI-friendly and allow to transparently add features
/// to the reflection process like caching for example.
/// </remarks>
public interface IReflect<T>
{
    IEnumerable<PropertyInfo> GetProperties();
}
