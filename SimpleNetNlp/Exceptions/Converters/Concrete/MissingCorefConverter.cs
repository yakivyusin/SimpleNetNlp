namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingCorefConverter : IExceptionConverter
{
    private const string CorefDefaultError = "java.io.IOException: Unable to open \"edu/stanford/nlp/models/coref/md-model-dep.ser.gz\" as class path, filename or URL";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message: CorefDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Coref Model (please install SimpleNetNlp.Models.Coref)", exception) :
        null;
}
