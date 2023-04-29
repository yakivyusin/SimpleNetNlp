namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class MissingSentimentConverter : IExceptionConverter
{
    private const string SentimentDefaultError = "java.io.IOException: Unable to open \"edu/stanford/nlp/models/sentiment/sentiment.ser.gz\" as class path, filename or URL";

    public bool CanConvert(Exception exception) => exception switch
    {
        edu.stanford.nlp.io.RuntimeIOException and { Message : SentimentDefaultError } => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new MissingModelException("Missing Sentiment Model (please install SimpleNetNlp.Models.Sentiment)", exception) :
        null;
}
