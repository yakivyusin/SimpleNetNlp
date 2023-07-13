using SimpleNetNlp.Coref;
using SimpleNetNlp.Naturalli;

namespace SimpleNetNlp.Extensions;

internal static class JavaToCSharpExtensions
{
    #region Primitives

    internal static int ToInt(this java.lang.Integer integer)
    {
        ArgumentNullException.ThrowIfNull(integer);

        return int.Parse(integer.toString());
    }

    internal static (int, int) ToTuple(this edu.stanford.nlp.util.IntTuple tuple) => new(tuple.get(0), tuple.get(1));

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

    #region Map

    internal static ILookup<TNewKey, TNewElement> ToLookup<TKey, TElement, TNewKey, TNewElement>(this java.util.Map map, Func<TKey, TNewKey> keySelector, Func<TElement, TNewElement> elementSelector)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(keySelector);
        ArgumentNullException.ThrowIfNull(elementSelector);

        return map
            .entrySet()
            .ToList<java.util.Map.Entry>()
            .ToDictionary(x => (TKey)x.getKey(), x => ((java.lang.Iterable)x.getValue()).ToList<TElement>())
            .SelectMany(p => p.Value.Select(x => new { p.Key, Value = x }))
            .ToLookup(x => keySelector(x.Key), x => elementSelector(x.Value));
    }

    internal static Dictionary<TNewKey, TNewElement> ToDictionary<TKey, TElement, TNewKey, TNewElement>(this java.util.Map map, Func<TKey, TNewKey> keySelector, Func<TElement, TNewElement> elementSelector)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(keySelector);
        ArgumentNullException.ThrowIfNull(elementSelector);

        return map
            .entrySet()
            .ToList<java.util.Map.Entry>()
            .ToDictionary(x => keySelector((TKey)x.getKey()), x => elementSelector((TElement)x.getValue()));
    }

    #endregion

    #region Stanford CoreNLP

    internal static SentimentClass ToSentimentClass(this edu.stanford.nlp.simple.SentimentClass sentiment)
    {
        ArgumentNullException.ThrowIfNull(sentiment);

        return Enum.Parse<SentimentClass>(ToCamelCase(sentiment.name()));
    }

    internal static Monotonicity ToMonotonicity(this edu.stanford.nlp.naturalli.Monotonicity monotonicity)
    {
        ArgumentNullException.ThrowIfNull(monotonicity);

        return Enum.Parse<Monotonicity>(ToCamelCase(monotonicity.name()));
    }

    internal static MonotonicityType ToMonotonicityType(this edu.stanford.nlp.naturalli.MonotonicityType monotonicityType)
    {
        ArgumentNullException.ThrowIfNull(monotonicityType);

        return Enum.Parse<MonotonicityType>(ToCamelCase(monotonicityType.name()));
    }

    internal static MentionType ToMentionType(this edu.stanford.nlp.coref.data.Dictionaries.MentionType mentionType)
    {
        ArgumentNullException.ThrowIfNull(mentionType);

        return Enum.Parse<MentionType>(ToCamelCase(mentionType.name()));
    }

    internal static Number ToNumber(this edu.stanford.nlp.coref.data.Dictionaries.Number number)
    {
        ArgumentNullException.ThrowIfNull(number);

        return Enum.Parse<Number>(ToCamelCase(number.name()));
    }

    internal static Animacy ToAnimacy(this edu.stanford.nlp.coref.data.Dictionaries.Animacy animacy)
    {
        ArgumentNullException.ThrowIfNull(animacy);

        return Enum.Parse<Animacy>(ToCamelCase(animacy.name()));
    }

    internal static Gender ToGender(this edu.stanford.nlp.coref.data.Dictionaries.Gender gender)
    {
        ArgumentNullException.ThrowIfNull(gender);

        return Enum.Parse<Gender>(ToCamelCase(gender.name()));
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
