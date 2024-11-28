using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace DotNaut.Data.Map;

/// <remarks>
/// TODO: This is a very primitive mapping implementation, but it establishes the basic idea.
/// We can use IDataRecord as an abstraction which many mappers can be build around. Thus
/// we can use a variety of data sources like databases, Excel, CSV, etc. Unlike Dapper.
/// And we can use DI for the better design.
/// </remarks>
/// 
/// <example>
/// using var stream = File.OpenRead(...);
/// using var excel = ExcelReaderFactory.CreateOpenXmlReader(stream);
/// var map = new PropertyMap<RowSample>()
///     .Add("Column_Alpha", item => item.PropertyAlpha)
///     .Add("Column_Beta", item => item.PropertyBeta)
///     ...
///  ;
/// while (reader.Read())
/// {
///     var item = map.Create(reader);
///     Console.WriteLine(item);
/// }
/// </example>
public class PropertyMap<T>
{
	private readonly List<PropertyInfo> _props = new();

    public PropertyMap<T> Add<U>(string name, Expression<Func<T, U>> property)
    {
		var member = property.Body as MemberExpression;
		if (member == null)
		{
			//TODO:
			throw new ArgumentException("Expression should return a property", nameof(property));
		}

		var propertyInfo = member.Member as PropertyInfo;
		if (propertyInfo == null)
		{
			//TODO:
			throw new ArgumentException("Expression should return a property", nameof(property));
		}

        _props.Add(propertyInfo);

        return this;
    }

	public PropertyMap<T> Add(string name)
	{
		_props.Add(null);

		return this;
	}

	public T? Map(IDataRecord reader, T item)
    {
		var fields = reader.FieldCount;
		if (_props.Count < fields)
		{
			fields = _props.Count;
		}

		for (var index = 0; index < fields; index++)
        {
			var property = _props[index];
			if (property == null)
			{
				continue;
			}

			var value = reader.GetValue(index);

            if (value != null)
			{
				var converted = Convert.ChangeType(value, property.PropertyType);
				property.SetValue(item, converted);
			}
		}

        return item;
    }

    public T Create(IDataRecord reader)
    {
        var item = (T)Activator.CreateInstance(typeof(T));
        return Map(reader, item);
    }
}
