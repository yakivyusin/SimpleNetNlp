namespace SimpleNetNlp.Exceptions;

/// <summary>
/// Thrown when library cannot find model file (specified at Message).
/// </summary>
public class MissingModelException : Exception
{
    internal MissingModelException(string message, Exception innerException) : base(message, innerException)
    {

    }
}
