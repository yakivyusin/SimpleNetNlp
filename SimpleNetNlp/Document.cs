using SimpleNetNlp.Extensions;

namespace SimpleNetNlp;

/// <summary>
/// A representation of a Document. Most blobs of raw text should become documents.
/// </summary>
public class Document
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
        _sentences = new Lazy<List<Sentence>>(LoadSentences);
    }

    /// <summary>
    /// Get the sentences in this document, as a list.
    /// </summary>
    public List<Sentence> Sentences => _sentences.Value;

    public override string ToString() => _underlyingDocument.toString();

    private List<Sentence> LoadSentences() => _underlyingDocument
        .sentences()
        .ToList<edu.stanford.nlp.simple.Sentence, Sentence>(x => new Sentence(x));
}
