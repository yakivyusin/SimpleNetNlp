using SimpleNetNlp.Exceptions;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp;

/// <summary>
/// A representation of a Document. Most blobs of raw text should become documents.
/// </summary>
public class Document : IEquatable<Document>
{
    private readonly edu.stanford.nlp.simple.Document _underlyingDocument;
    private readonly Lazy<List<Sentence>> _sentences;

    /// <summary>
    /// Create a new document from the passed in text.
    /// </summary>
    /// <param name="text">The text of the document.</param>
    public Document(string text)
    {
        _underlyingDocument = new edu.stanford.nlp.simple.Document(text);
        _underlyingDocument.Properties().setProperty("ner.useSUTime", "0");
        _sentences = new Lazy<List<Sentence>>(LoadSentences);
    }

    /// <summary>
    /// Get the sentences in this document, as a list.
    /// </summary>
    public List<Sentence> Sentences => _sentences.Value;

    /// <summary>
    /// Get the original (raw) text of this document.
    /// </summary>
    public string OriginalText => _underlyingDocument.text();

    /// <summary>
    /// Returns an indented JSON dump of this document.
    /// <para>Optionally, you can also specify a number of <paramref name="actions"/> to call on the document before dumping it to JSON. This allows the user to ensure that certain annotations have been computed before the document is dumped.</para>
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public string ToJson(params Action<Sentence>[] actions) => ToJson(true, actions);

    /// <summary>
    /// Returns a JSON dump of this document (indented or not).
    /// <para>Optionally, you can also specify a number of <paramref name="actions"/> to call on the document before dumping it to JSON. This allows the user to ensure that certain annotations have been computed before the document is dumped.</para>
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public string ToJson(bool indentation, params Action<Sentence>[] actions) => indentation ?
        _underlyingDocument.json(actions.Select(a => a.ToJavaSelector<object>()).ToArray()) :
        _underlyingDocument.jsonMinified(actions.Select(a => a.ToJavaSelector<object>()).ToArray());

    /// <summary>
    /// Returns an indented XML dump of this document.
    /// <para>Optionally, you can also specify a number of <paramref name="actions"/> to call on the document before dumping it to XML. This allows the user to ensure that certain annotations have been computed before the document is dumped.</para>
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public string ToXml(params Action<Sentence>[] actions) => ToXml(true, actions);

    /// <summary>
    /// Returns a XML dump of this document (indented or not).
    /// <para>Optionally, you can also specify a number of <paramref name="actions"/> to call on the document before dumping it to XML. This allows the user to ensure that certain annotations have been computed before the document is dumped.</para>
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public string ToXml(bool indentation, params Action<Sentence>[] actions) => indentation ?
        _underlyingDocument.xml(actions.Select(a => a.ToJavaSelector<object>()).ToArray()) :
        _underlyingDocument.xmlMinified(actions.Select(a => a.ToJavaSelector<object>()).ToArray());

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingDocument.hashCode();

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as Document);

    /// <inheritdoc/>
    public bool Equals(Document other) => _underlyingDocument.equals(other?._underlyingDocument);

    /// <inheritdoc/>
    public override string ToString() => _underlyingDocument.toString();

    /// <inheritdoc/>
    public static bool operator ==(Document left, Document right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(Document left, Document right) => !(left == right);

    private List<Sentence> LoadSentences() => _underlyingDocument
        .sentences()
        .ToList<edu.stanford.nlp.simple.Sentence, Sentence>(x => new Sentence(x));
}
