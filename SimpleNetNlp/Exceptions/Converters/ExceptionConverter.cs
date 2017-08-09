using SimpleNetNlp.Exceptions.Converters.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNetNlp.Exceptions.Converters
{
    internal class ExceptionConverter
    {
        private List<IExceptionConverter> concreteConverters = new List<IExceptionConverter>()
        {
            new MissingPosTaggerConverter(),
            new MissingNerConverter(),
            new MissingParserConverter(),
            new MissingNaturalliConverter(),
            new DefaultExceptionConverter()
        };

        public Exception WrapException(Exception exception)
        {
            return concreteConverters
                .First(c => c.CanConvert(exception))
                .Convert(exception);
        }
    }
}
