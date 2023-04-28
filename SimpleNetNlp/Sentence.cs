using SimpleNetNlp.Exceptions.Converters;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp;

/// <summary>
/// A representation of a single Sentence.
/// </summary>
public class Sentence
{
    private readonly IExceptionConverter _exceptionConverter = new ExceptionConverter();
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
    public IReadOnlyCollection<int> CharacterOffsetBegin => _underlyingSentence
        .characterOffsetBegin()
        .ToList<java.lang.Integer, int>(x => x.ToInt())
        .AsReadOnly();

    /// <summary>
    /// The end position of each token in the sentence.
    /// </summary>
    public IReadOnlyCollection<int> CharacterOffsetEnd => _underlyingSentence
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
    /// The lemmas of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public IReadOnlyCollection<string> Lemmas
    {
        get
        {
            try
            {
                return _underlyingSentence
                    .lemmas()
                    .ToList<string>()
                    .AsReadOnly();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }    
        }
    }

    /// <summary>
    /// The named entity tags of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public IReadOnlyCollection<string> NerTags
    {
        get
        {
            var props = new java.util.Properties();
            props.setProperty("ner.useSUTime", "0");

            try
            {
                return _underlyingSentence
                    .nerTags(props)
                    .ToList<string>()
                    .AsReadOnly();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }
        }
    }

    /// <summary>
    /// The part of speech tags of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public IReadOnlyCollection<string> PosTags
    {
        get
        {
            try
            {
                return _underlyingSentence
                    .posTags()
                    .ToList<string>()
                    .AsReadOnly();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }
        }
    }

    /// <summary>
    /// Get the OpenIE triples associated with this sentence. 
    /// <para>Returns a collection of RelationTriple objects representing the OpenIE triples in the sentence.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser, Naturalli</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public IReadOnlyCollection<RelationTriple> OpenIe
    {
        get
        {
            try
            {
                return _underlyingSentence
                    .openie()
                    .ToList<edu.stanford.nlp.util.Quadruple, RelationTriple>(x => new RelationTriple(x))
                    .AsReadOnly();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }
        }
    }

    /// <summary>
    /// Returns the governors of a sentence.
    /// <para>The resulting list is of the same size as the original sentence, with each element being either the governor index, or null if the node has no known governor.</para>
    /// <para>The root has index -1.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public IReadOnlyCollection<int?> Governors
    {
        get
        {
            try
            {
                return _underlyingSentence
                    .governors()
                    .ToList<java.util.Optional, int?>(x => x.isPresent() ? (x.get() as java.lang.Integer).ToInt() : null)
                    .AsReadOnly();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }
        }
    }

    /// <summary>
    /// Returns the incoming dependency labels of a sentence.
    /// <para>The resulting list is of the same size as the original sentence, with each element being either the incoming dependency label, or null.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public IReadOnlyCollection<string> IncomingDependencyLabels
    {
        get
        {
            try
            {
                return _underlyingSentence
                    .incomingDependencyLabels()
                    .ToList<java.util.Optional, string>(x => x.isPresent() ? x.get() as string : null)
                    .AsReadOnly();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }
        }
    }

    /// <summary>
    /// The sentiment of this sentence (e.g., positive / negative).
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: LexParser, Sentiment</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    public SentimentClass Sentiment
    {
        get
        {
            try
            {
                return _underlyingSentence
                    .sentiment()
                    .ToSentimentClass();
            }
            catch (Exception e)
            {
                throw _exceptionConverter.Convert(e);
            }
        }
    }

    /// <summary>
    /// The words of the sentence.
    /// </summary>
    public IReadOnlyCollection<string> Words => _underlyingSentence
        .words()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// The original (unprocessed) words of the sentence.
    /// </summary>
    public IReadOnlyCollection<string> OriginalWords => _underlyingSentence
        .originalTexts()
        .ToList<string>()
        .AsReadOnly();

    public override string ToString() => _underlyingSentence.toString();
}
