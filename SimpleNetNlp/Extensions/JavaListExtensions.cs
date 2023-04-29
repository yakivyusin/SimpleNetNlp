using JavaList = java.util.List;
using JavaCollection = java.util.Collection;

namespace SimpleNetNlp.Extensions;

/// <summary>
/// Contains extension methods for java.util.List
/// </summary>
internal static class JavaListExtensions
{
    /// <summary>
    /// Convert java.util.List to System.Collections.Generic.List of arbitrary type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The element type of the list.</typeparam>
    /// <param name="list">List to convertion.</param>
    /// <returns>A converted list.</returns>
    internal static List<T> ToList<T>(this JavaList list)
    {
        ArgumentNullException.ThrowIfNull(list);

        return Enumerate<T>(list).ToList();
    }

    /// <summary>
    /// Convert java.util.List that contains elements of type <typeparamref name="TSource"/>
    /// to System.Collections.Generic.List of arbitary type <typeparamref name="TTarget"/> based on <paramref name="convertingFunction"/>
    /// </summary>
    /// <typeparam name="TSource">The source type of the Java list elements.</typeparam>
    /// <typeparam name="TTarget">The target type.</typeparam>
    /// <param name="list">List to convertion.</param>
    /// <param name="convertingFunction">Function for converting <typeparamref name="TSource"/> element to <typeparamref name="TTarget"/></param>
    /// <returns>A converted list.</returns>
    internal static List<TTarget> ToList<TSource, TTarget>(this JavaList list, Func<TSource, TTarget> convertingFunction)
    {
        if (list == null) throw new NullReferenceException();

        return (list as JavaCollection).ToList(convertingFunction);
    }

    private static IEnumerable<T> Enumerate<T>(JavaList list)
    {
        var iterator = list.iterator();
        while (iterator.hasNext())
        {
            yield return (T)(iterator.next());
        }
    }
}
