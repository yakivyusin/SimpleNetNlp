using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class MissingPosTaggerConverter : IExceptionConverter
    {
        private static readonly string posModelPath =
            "Unable to open \"edu/stanford/nlp/models/pos-tagger/english-left3words/english-left3words-distsim.tagger\" as class path, filename or URL";

        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;
            if (!(exception is java.lang.RuntimeException)) return false;

            return exception.InnerException?.InnerException?.Message?.Contains(posModelPath) ?? false;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new MissingModelException("Missing Pos Tagger Model (please install SimpleNetNlp.Models.PosTagger)", exception);
        }
    }
}
