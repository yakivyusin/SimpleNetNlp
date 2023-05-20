namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class DefaultJavaExceptionConverter : IExceptionConverter
{
    public bool CanConvert(Exception exception) => exception switch
    {
        java.lang.Throwable => true,
        _ => false
    };

    public Exception Convert(Exception exception) => CanConvert(exception) ?
        new UnhandledLibraryException(exception) :
        null;
}
