namespace SimpleNetNlp.Exceptions.Converters.Concrete;

internal class NoOpExceptionConverter : IExceptionConverter
{
    public bool CanConvert(Exception exception) => true;

    public Exception Convert(Exception exception) => exception;
}
