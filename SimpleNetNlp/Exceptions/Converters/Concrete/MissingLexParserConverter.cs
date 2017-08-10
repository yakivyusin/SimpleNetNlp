using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class MissingLexParserConverter : IExceptionConverter
    {
        private static readonly string lexParserDefaultError =
            "java.io.IOException: Unable to open \"edu/stanford/nlp/models/lexparser/englishPCFG.ser.gz\" as class path, filename or URL";

        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;
            if (!(exception is edu.stanford.nlp.io.RuntimeIOException)) return false;

            return exception.Message?.Equals(lexParserDefaultError) ?? false;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new MissingModelException("Missing LexParser Model (please install SimpleNetNlp.Models.LexParser)", exception);
        }
    }
}
