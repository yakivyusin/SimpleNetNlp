using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class MissingNaturalliConverter : IExceptionConverter
    {
        private static readonly string naturalliDefaultError =
            "Could not load clause splitter model at edu/stanford/nlp/models/naturalli/clauseSearcherModel.ser.gz";

        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;
            if (!(exception is edu.stanford.nlp.io.RuntimeIOException)) return false;

            return exception.Message?.Equals(naturalliDefaultError) ?? false;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new MissingModelException("Missing Naturalli Model (please install SimpleNetNlp.Models.Naturalli)", exception);
        }
    }
}
