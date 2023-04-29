namespace SimpleNetNlp.Exceptions.Converters;

internal interface IExceptionConverter
{
    bool CanConvert(Exception exception);
    Exception Convert(Exception exception);
}
