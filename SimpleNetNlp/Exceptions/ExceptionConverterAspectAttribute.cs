using MethodBoundaryAspect.Fody.Attributes;
using SimpleNetNlp.Exceptions.Converters;
using SimpleNetNlp.Exceptions.Converters.Concrete;

namespace SimpleNetNlp.Exceptions;

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
internal class ExceptionConverterAspectAttribute : OnMethodBoundaryAspect
{
    private readonly static IReadOnlyList<IExceptionConverter> _exceptionConverters = new List<IExceptionConverter>()
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

    public override void OnException(MethodExecutionArgs arg)
    {
        throw _exceptionConverters.First(x => x.CanConvert(arg.Exception)).Convert(arg.Exception);
    }
}
