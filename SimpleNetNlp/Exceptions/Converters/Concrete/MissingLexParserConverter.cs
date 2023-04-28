namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingLexParserConverter : IExceptionConverter
{
    private const string LexParserDefaultError = "java.io.IOException: Unable to open \"edu/stanford/nlp/models/lexparser/englishPCFG.ser.gz\" as class path, filename or URL";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message: LexParserDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing LexParser Model (please install SimpleNetNlp.Models.LexParser)", exception) :
        null;
}
