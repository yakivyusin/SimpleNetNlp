using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class MissingNerConverter : IExceptionConverter
    {
        private static readonly string nerDefaultError =
            "java.io.IOException: Couldn't load classifier from edu/stanford/nlp/models/ner/english.all.3class.distsim.crf.ser.gz";

        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;
            if (!(exception is edu.stanford.nlp.io.RuntimeIOException)) return false;

            return exception.Message?.Equals(nerDefaultError) ?? false;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new MissingModelException("Missing Ner Model (please install SimpleNetNlp.Models.Ner)", exception);
        }
    }
}
