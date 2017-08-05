using System;

namespace SimpleNetNlp.Exceptions
{
    public class MissingModelException : Exception
    {
        public MissingModelException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
