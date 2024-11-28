using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace DotNaut.Data;

/// TODO:Shareable property list management with <see cref="PropertyMap{T}"/>.
/// TODO:Not a good assembly to be in, including Microsoft.Data.SqlClient and Dapper dependencies.
public class BulkLoader<T>
{
	private readonly List<PropertyInfo> _props = new();
	private readonly DataTable _table;


	public BulkLoader()
	{
		_table = new DataTable();
	}

	public BulkLoader<T> Add<U>(Expression<Func<T, U>> property)
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

		var propertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) 
			?? propertyInfo.PropertyType
		;

		_table.Columns.Add(propertyInfo.Name, propertyType);

		return this;
	}

	public BulkLoader<T> Add(IEnumerable<T> items)
	{
		foreach (var item in items)
		{
			Add(item);
		}

		return this;
	}

	public BulkLoader<T> Add(T item)
	{
		var values = _props
			.Select(property => property.GetValue(item))
			.ToArray()
		;

		var row = _table.Rows.Add(values);

		return this;
	}

	public void Load(SqlConnection connection, string tableName)
	{
		using var command = connection.CreateCommand();
		connection.Execute($"TRUNCATE TABLE {tableName}");

		using SqlBulkCopy copy = new(connection);
		copy.DestinationTableName = tableName;
		copy.WriteToServer(_table);
	}
}
