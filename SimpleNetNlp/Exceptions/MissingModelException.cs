using System;

namespace SimpleNetNlp.Exceptions
{
    /// <summary>
    /// Thrown when library cannot find model file (specified at Message).
    /// </summary>
    public class MissingModelException : Exception
    {
        public MissingModelException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
