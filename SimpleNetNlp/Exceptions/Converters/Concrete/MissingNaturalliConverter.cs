namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingNaturalliConverter : IExceptionConverter
{
    private const string NaturalliDefaultError = "Could not load clause splitter model at edu/stanford/nlp/models/naturalli/clauseSearcherModel.ser.gz";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message : NaturalliDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Naturalli Model (please install SimpleNetNlp.Models.Naturalli)", exception) :
        null;
}
