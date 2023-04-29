namespace SimpleNetNlp.Exceptions;

/// <summary>
/// Thrown when an unexpected exception is caused by CoreNLP library.
/// </summary>
public class UnhandledLibraryException : Exception
{
    public UnhandledLibraryException(Exception innerException) : base("An unexpected exception was thrown by Stanford CoreNLP", innerException)
    {

    }
}
