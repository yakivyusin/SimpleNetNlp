namespace SimpleNetNlp
{
    /// <summary>
    /// Enum to represent a sentiment value.
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
        public static bool IsPosivite(this SentimentClass sentiment)
        {
            return sentiment == SentimentClass.VeryPositive || sentiment == SentimentClass.Positive;
        }

        public static bool IsNegative(this SentimentClass sentiment)
        {
            return sentiment == SentimentClass.VeryNegative || sentiment == SentimentClass.Negative;
        }

        public static bool IsExtreme(this SentimentClass sentiment)
        {
            return sentiment == SentimentClass.VeryPositive || sentiment == SentimentClass.VeryNegative;
        }

        public static bool IsMild(this SentimentClass sentiment)
        {
            return !sentiment.IsExtreme();
        }
    }
}
