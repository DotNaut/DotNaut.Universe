namespace DotNaut.Data.Sql;

/// <remarks>
/// <para>
/// TODO:From the ISO/IEC 9075-1 (4.4 SQL data types) we can take that SQL types
/// are <see cref="ISqlSchemaObject"/>. Each type may have some type-specific
/// params (varchar has length, numeric has precision and scale, etc.), always
/// has NULL value and with some additional constraints (like NOT NULL, UNIQUE, etc.)
/// they become a <see cref="ISqlDomain"/>.
/// </para>
/// 
/// <para>
/// But for our purpose it would be nice to have some abstract types (non-schema objects)
/// or types defined by requirements. Usually we have some basis type right in the
/// .NET and some constraints like numeric range 1..1000 or enum or money. Such
/// definitions can be mapped to the most effective type in the specific DBMS.
/// </para>
/// 
/// <para>
/// One of the good samples is a possibility to employ some non-used value as a NULL,
/// because NULLable types are usually expensive (bitmap of at least one byte size
/// in SQL Server, additional nullability column and files for Clickhouse, etc).
/// But in the most of cases we do not use all values of the type. For instance,
/// when using 4-bytes signed integer, we'll barely use -2,147,483,648 or 
/// 2,147,483,647.
/// </para>
/// </remarks>
public interface ISqlType
{

}
