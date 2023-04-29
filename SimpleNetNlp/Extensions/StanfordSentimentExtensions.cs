using JavaSentimentClass = edu.stanford.nlp.simple.SentimentClass;

namespace SimpleNetNlp.Extensions;

/// <summary>
/// Contains extension methods for edu.stanford.nlp.simple.SentimentClass
/// </summary>
internal static class StanfordSentimentExtensions
{
    /// <summary>
    /// Convert value from edu.stanford.nlp.simple.SentimentClass to corresponding C# enum.
    /// </summary>
    /// <param name="sentiment">Value to convertion.</param>
    /// <returns>A converted value.</returns>
    internal static SentimentClass ToSentimentClass(this JavaSentimentClass sentiment)
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
}
