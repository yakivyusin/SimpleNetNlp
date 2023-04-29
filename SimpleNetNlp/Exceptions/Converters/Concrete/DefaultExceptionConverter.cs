namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class DefaultExceptionConverter : IExceptionConverter
{
    public bool CanConvert(Exception exception) => exception != null;

    public Exception Convert(Exception exception) => CanConvert(exception) ? new UnhandledLibraryException(exception) : null;
}
