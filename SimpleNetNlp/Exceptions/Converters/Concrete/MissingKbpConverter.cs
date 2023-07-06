namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingKbpConverter : IExceptionConverter
{
    private const string KbpDefaultError = "Couldn't read TokensRegexNER from edu/stanford/nlp/models/kbp/english/gazetteers/regexner_caseless.tab";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message: KbpDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Kbp Model (please install SimpleNetNlp.Models.Kbp)", exception) :
        null;
}
