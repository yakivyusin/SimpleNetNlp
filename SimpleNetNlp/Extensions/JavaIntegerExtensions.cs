using JavaInt = java.lang.Integer;

namespace SimpleNetNlp.Extensions;

/// <summary>
/// Contains extension methods for java.lang.Integer
/// </summary>
internal static class JavaIntegerExtensions
{
    /// <summary>
    /// Convert java.lang.Integer to plain C# int.
    /// </summary>
    /// <param name="integer">Integer to convertion.</param>
    /// <returns>A converted value.</returns>
    internal static int ToInt(this JavaInt integer)
    {
        ArgumentNullException.ThrowIfNull(integer);

        return int.Parse(integer.toString());
    }
}
