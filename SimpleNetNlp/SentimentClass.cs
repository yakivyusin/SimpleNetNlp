namespace SimpleNetNlp;

/// <summary>
/// Enum to represent a sentiment class.
/// </summary>
public enum SentimentClass
{
    VeryPositive,
    Positive,
    Neutral,
    Negative,
    VeryNegative
}

public static class SentimentClassExtensions
{
    /// <summary>
    /// Returns <see langword="true"/> if <paramref name="sentiment"/> is positive (very or not).
    /// </summary>
    public static bool IsPosivite(this SentimentClass sentiment)
    {
        return sentiment == SentimentClass.VeryPositive || sentiment == SentimentClass.Positive;
    }

    /// <summary>
    /// Returns <see langword="true"/> if <paramref name="sentiment"/> is negative (very or not).
    /// </summary>
    public static bool IsNegative(this SentimentClass sentiment)
    {
        return sentiment == SentimentClass.VeryNegative || sentiment == SentimentClass.Negative;
    }

    /// <summary>
    /// Returns <see langword="true"/> if <paramref name="sentiment"/> is extreme (very positive or very negative).
    /// </summary>
    public static bool IsExtreme(this SentimentClass sentiment)
    {
        return sentiment == SentimentClass.VeryPositive || sentiment == SentimentClass.VeryNegative;
    }

    /// <summary>
    /// Returns <see langword="true"/> if <paramref name="sentiment"/> is mild.
    /// </summary>
    public static bool IsMild(this SentimentClass sentiment)
    {
        return !sentiment.IsExtreme();
    }
}
