using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class MissingSentimentConverter : IExceptionConverter
    {
        private static readonly string sentimentDefaultError =
            "java.io.IOException: Unable to open \"edu/stanford/nlp/models/sentiment/sentiment.ser.gz\" as class path, filename or URL";

        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;
            if (!(exception is edu.stanford.nlp.io.RuntimeIOException)) return false;

            return exception.Message?.Equals(sentimentDefaultError) ?? false;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new MissingModelException("Missing Sentiment Model (please install SimpleNetNlp.Models.Sentiment)", exception);
        }
    }
}
