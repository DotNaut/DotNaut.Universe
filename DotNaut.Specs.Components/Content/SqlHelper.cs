namespace DotNaut.Content;

/// <summary>
/// TODO:A big mess for a while (location, responsibility), but the first baby step.
/// </summary>
public class SqlHelper
{
    public static string ReadResourceAsString(Type type, string name)
    {
        using var stream = type.Assembly.GetManifestResourceStream(type, name);
        if (stream == null)
        {
            throw new ArgumentException($"Resource `{name}` not found for the {type.FullName}");
        }

        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}
