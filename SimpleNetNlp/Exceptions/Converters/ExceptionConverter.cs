using SimpleNetNlp.Exceptions.Converters.Concrete;

namespace SimpleNetNlp.Exceptions.Converters;

internal class ExceptionConverter : IExceptionConverter
{
    private readonly IReadOnlyList<IExceptionConverter> _concreteConverters = new List<IExceptionConverter>()
    {
        new MissingPosTaggerConverter(),
        new MissingNerConverter(),
        new MissingParserConverter(),
        new MissingNaturalliConverter(),
        new MissingLexParserConverter(),
        new MissingSentimentConverter(),
        new DefaultJavaExceptionConverter(),
        new NoOpExceptionConverter()
    };

    public bool CanConvert(Exception exception) => _concreteConverters.Any(x => x.CanConvert(exception));

    public Exception Convert(Exception exception) => _concreteConverters.First(x => x.CanConvert(exception)).Convert(exception);
}
