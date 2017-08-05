using System;

namespace SimpleNetNlp.Exceptions
{
    public class UnhandledLibraryException : Exception
    {
        public UnhandledLibraryException(Exception innerException) :
            base("An unexpected exception was thrown by Stanford CoreNLP", innerException)
        {

        }
    }
}
