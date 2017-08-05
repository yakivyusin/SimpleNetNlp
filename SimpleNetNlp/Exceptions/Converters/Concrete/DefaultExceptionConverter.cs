using System;

namespace SimpleNetNlp.Exceptions.Converters.Concrete
{
    internal class DefaultExceptionConverter : IExceptionConverter
    {
        public bool CanConvert(Exception exception)
        {
            if (exception == null) return false;

            return true;
        }

        public Exception Convert(Exception exception)
        {
            if (!CanConvert(exception)) return null;

            return new UnhandledLibraryException(exception);
        }
    }
}
