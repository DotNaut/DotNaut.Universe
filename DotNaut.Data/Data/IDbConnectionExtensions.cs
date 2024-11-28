using System.Data;

namespace DotNaut.Data;

public static class IDbConnectionExtensions
{
	public static void Execute(this IDbConnection connection, string commandText)
	{
		if (connection.State != ConnectionState.Open)
		{
			connection.Open();
		}

		using var command = connection.CreateCommand();
		command.CommandText = commandText;
		command.ExecuteNonQuery();
	}
}
