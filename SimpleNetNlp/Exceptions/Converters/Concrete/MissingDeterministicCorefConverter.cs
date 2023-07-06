namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingDeterministicCorefConverter : IExceptionConverter
{
    private const string DeterministicCorefDefaultError = "java.io.IOException: Unable to open \"edu/stanford/nlp/models/dcoref/demonyms.txt\" as class path, filename or URL";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message: DeterministicCorefDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing DeterministicCoref Model (please install SimpleNetNlp.Models.DeterministicCoref)", exception) :
        null;
}
