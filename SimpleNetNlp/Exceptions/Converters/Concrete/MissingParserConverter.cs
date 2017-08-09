using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class MissingParserConverter : IExceptionConverter
    {
        private static readonly string parserDefaultError =
            "java.io.IOException: Unable to open \"edu/stanford/nlp/models/parser/nndep/english_UD.gz\" as class path, filename or URL";

        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;
            if (!(exception is edu.stanford.nlp.io.RuntimeIOException)) return false;

            return exception.Message?.Equals(parserDefaultError) ?? false;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new MissingModelException("Missing Parser Model (please install SimpleNetNlp.Models.Parser)", exception);
        }
    }
}
