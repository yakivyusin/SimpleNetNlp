using System;
using System.Linq;

namespace SimpleNetNlp.Extensions
{
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
        internal static SentimentClass ToSentimentClass(this edu.stanford.nlp.simple.SentimentClass sentiment)
        {
            if (sentiment == null) throw new ArgumentNullException();

            SentimentClass result;
            if (Enum.TryParse(ToCamelCase(sentiment.name()), out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private static string ToCamelCase(string upperUnderscore)
        {
            return string.Join("", upperUnderscore
                                    .Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => x[0] + x.Substring(1, x.Length - 1).ToLowerInvariant()));
        }
    }
}
