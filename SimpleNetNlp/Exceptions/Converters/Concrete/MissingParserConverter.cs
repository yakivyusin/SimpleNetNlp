namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingParserConverter : IExceptionConverter
{
    private const string ParserDefaultError = "java.io.IOException: Unable to open \"edu/stanford/nlp/models/parser/nndep/english_UD.gz\" as class path, filename or URL";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message: ParserDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Parser Model (please install SimpleNetNlp.Models.Parser)", exception) :
        null;
}
