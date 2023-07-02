using System.Reflection;

namespace SimpleNetNlp.Extensions;

internal static class CoreNlpExtensions
{
    internal static java.util.Properties Properties(this edu.stanford.nlp.simple.Document document)
    {
        var fieldDefinition = typeof(edu.stanford.nlp.simple.Document).GetField("defaultProps", BindingFlags.Instance | BindingFlags.NonPublic);

        return (java.util.Properties)fieldDefinition.GetValue(document);
    }

    internal static java.util.Properties Properties(this edu.stanford.nlp.simple.Sentence sentence)
    {
        var fieldDefinition = typeof(edu.stanford.nlp.simple.Sentence).GetField("defaultProps", BindingFlags.Instance | BindingFlags.NonPublic);

        return (java.util.Properties)fieldDefinition.GetValue(sentence);
    }
}
