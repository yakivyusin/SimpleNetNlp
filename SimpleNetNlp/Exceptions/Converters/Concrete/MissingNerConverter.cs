namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingNerConverter : IExceptionConverter
{
    private const string NerDefaultError = "java.io.IOException: Couldn't load classifier from edu/stanford/nlp/models/ner/english.all.3class.distsim.crf.ser.gz";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message : NerDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Ner Model (please install SimpleNetNlp.Models.Ner)", exception) :
        null;
}
