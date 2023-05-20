namespace SimpleNetNlp.Extensions;

internal static class JavaToCSharpExtensions
{
    #region Primitives

    internal static int ToInt(this java.lang.Integer integer)
    {
        ArgumentNullException.ThrowIfNull(integer);

        return int.Parse(integer.toString());
    }

    #endregion

    #region Iterable

    internal static List<T> ToList<T>(this java.lang.Iterable iterable) => iterable.ToEnumerable<T>().ToList();

    internal static List<TTarget> ToList<TSource, TTarget>(this java.lang.Iterable iterable, Func<TSource, TTarget> selector) => iterable.ToEnumerable(selector).ToList();

    internal static IEnumerable<T> ToEnumerable<T>(this java.lang.Iterable iterable)
    {
        ArgumentNullException.ThrowIfNull(iterable);

        return iterable.ToEnumerable<T, T>(x => x);
    }

    internal static IEnumerable<TTarget> ToEnumerable<TSource, TTarget>(this java.lang.Iterable iterable, Func<TSource, TTarget> selector)
    {
        ArgumentNullException.ThrowIfNull(iterable);
        ArgumentNullException.ThrowIfNull(selector);

        var iterator = iterable.iterator();

        while (iterator.hasNext())
        {
            yield return selector((TSource)iterator.next());
        }
    }

    #endregion

    #region Stanford CoreNLP

    internal static SentimentClass ToSentimentClass(this edu.stanford.nlp.simple.SentimentClass sentiment)
    {
        ArgumentNullException.ThrowIfNull(sentiment);

        return Enum.Parse<SentimentClass>(ToCamelCase(sentiment.name()));
    }

    private static string ToCamelCase(string upperUnderscore)
    {
        return string.Join(
            "",
            upperUnderscore
                .Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x[0] + x[1..].ToLowerInvariant()));
    }

    #endregion
}
