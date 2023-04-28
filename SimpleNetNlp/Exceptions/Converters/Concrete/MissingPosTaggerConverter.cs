namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingPosTaggerConverter : IExceptionConverter
{
    private const string PosModelPath = "Unable to open \"edu/stanford/nlp/models/pos-tagger/english-left3words-distsim.tagger\" as class path, filename or URL";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { InnerException.Message : PosModelPath } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Pos Tagger Model (please install SimpleNetNlp.Models.PosTagger)", exception) :
        null;
}
