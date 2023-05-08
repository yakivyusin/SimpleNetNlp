using SimpleNetNlp.Exceptions;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp;

/// <summary>
/// A representation of a single Sentence.
/// </summary>
public class Sentence : IEquatable<Sentence>
{
    private readonly edu.stanford.nlp.simple.Sentence _underlyingSentence;

    /// <summary>
    /// Create a new sentence from the given text, assuming the entire text is just one sentence.
    /// </summary>
    /// <param name="text">The text of the sentence.</param>
    public Sentence(string text) : this(new edu.stanford.nlp.simple.Sentence(text))
    {
    }

    /// <summary>
    /// Create a new sentence directly from the given CoreNLP Sentence isntance.
    /// </summary>
    /// <param name="underlyingSentence">The CoreNLP Sentence.</param>
    internal Sentence(edu.stanford.nlp.simple.Sentence underlyingSentence)
    {
        _underlyingSentence = underlyingSentence;
    }

    /// <summary>
    /// The begin position of each token in the sentence.
    /// </summary>
    public IReadOnlyList<int> CharacterOffsetBegin => _underlyingSentence
        .characterOffsetBegin()
        .ToList<java.lang.Integer, int>(x => x.ToInt())
        .AsReadOnly();

    /// <summary>
    /// The end position of each token in the sentence.
    /// </summary>
    public IReadOnlyList<int> CharacterOffsetEnd => _underlyingSentence
        .characterOffsetEnd()
        .ToList<java.lang.Integer, int>(x => x.ToInt())
        .AsReadOnly();

    /// <summary>
    /// The index of the sentence within the document.
    /// </summary>
    public int SentenceIndex => _underlyingSentence.sentenceIndex();

    /// <summary>
    /// The begin position (in tokens) of the sentence within the document.
    /// </summary>
    public int SentenceTokenOffsetBegin => _underlyingSentence.sentenceTokenOffsetBegin();

    /// <summary>
    /// The end position (in tokens) of the sentence within the document.
    /// </summary>
    public int SentenceTokenOffsetEnd => _underlyingSentence.sentenceTokenOffsetEnd();

    /// <summary>
    /// The words of the sentence.
    /// </summary>
    public IReadOnlyList<string> Words => _underlyingSentence
        .words()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// The original (unprocessed) words of the sentence.
    /// </summary>
    public IReadOnlyList<string> OriginalWords => _underlyingSentence
        .originalTexts()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns the lemmas of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> Lemmas() => _underlyingSentence
        .lemmas()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns the named entity tags of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> NerTags()
    {
        var props = new java.util.Properties();
        props.setProperty("ner.useSUTime", "0");

        return _underlyingSentence
            .nerTags(props)
            .ToList<string>()
            .AsReadOnly();
    }

    /// <summary>
    /// Returns the part of speech tags of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> PosTags() => _underlyingSentence
        .posTags()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns a collection of <see cref="RelationTriple"/> objects representing the OpenIE triples in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser, Naturalli</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<RelationTriple> OpenIe() => _underlyingSentence
        .openie()
        .ToList<edu.stanford.nlp.util.Quadruple, RelationTriple>(x => new RelationTriple(x))
        .AsReadOnly();

    /// <summary>
    /// Returns the governors of a sentence.
    /// <para>The resulting list is of the same size as the original sentence, with each element being either the governor index, or null if the node has no known governor.</para>
    /// <para>The root has index -1.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<int?> Governors() => _underlyingSentence
        .governors()
        .ToList<java.util.Optional, int?>(x => x.isPresent() ? (x.get() as java.lang.Integer).ToInt() : null)
        .AsReadOnly();

    /// <summary>
    /// Returns the incoming dependency labels of a sentence.
    /// <para>The resulting list is of the same size as the original sentence, with each element being either the incoming dependency label, or null.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> IncomingDependencyLabels() => _underlyingSentence
        .incomingDependencyLabels()
        .ToList<java.util.Optional, string>(x => x.isPresent() ? x.get() as string : null)
        .AsReadOnly();

    /// <summary>
    /// Returns the sentiment of this sentence (e.g., positive / negative). See the <see cref="SentimentClass"/> enum for possible values.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: LexParser, Sentiment</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public SentimentClass Sentiment() => _underlyingSentence
        .sentiment()
        .ToSentimentClass();

    /// <inheritdoc/>
    public bool Equals(Sentence other) => _underlyingSentence.equals(other?._underlyingSentence);

    /// <inheritdoc/>
    public override string ToString() => _underlyingSentence.toString();

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as Sentence);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingSentence.hashCode();
}
