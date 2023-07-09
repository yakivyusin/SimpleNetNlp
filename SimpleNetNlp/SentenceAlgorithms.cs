using SimpleNetNlp.Exceptions;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp;

/// <summary>
/// A set of common utility algorithms for working with sentences (e.g., finding the head of a span).
/// </summary>
public class SentenceAlgorithms : IEquatable<SentenceAlgorithms>
{
    private readonly edu.stanford.nlp.simple.SentenceAlgorithms _underlyingSentenceAlgorithms;

    internal SentenceAlgorithms(edu.stanford.nlp.simple.SentenceAlgorithms underlyingSentenceAlgorithms)
    {
        _underlyingSentenceAlgorithms = underlyingSentenceAlgorithms;
    }

    /// <summary>
    /// Returns all the spans of a sentence with the <paramref name="selector"/> applied (e.g., <see cref="Sentence.Lemmas"/>).
    /// The <paramref name="maxLength"/> limits the maximum length of the spans.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IEnumerable<IReadOnlyList<T>> AllSpans<T>(Func<Sentence, IEnumerable<T>> selector, int maxLength) => _underlyingSentenceAlgorithms
        .allSpans(selector.ToJavaSelector(), maxLength)
        .ToEnumerable<java.util.List, IReadOnlyList<T>>(x => x.ToList<T>());

    /// <summary>
    /// Returns all the spans of a sentence with the <paramref name="selector"/> applied (e.g., <see cref="Sentence.Lemmas"/>).
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IEnumerable<IReadOnlyList<T>> AllSpans<T>(Func<Sentence, IEnumerable<T>> selector) => _underlyingSentenceAlgorithms
        .allSpans(selector.ToJavaSelector())
        .ToEnumerable<java.util.List, IReadOnlyList<T>>(x => x.ToList<T>());

    /// <summary>
    /// Returns all the word spans of a sentence. So, for example, a sentence "a b c" would return: [a], [b], [c], [a b], [b c], [a b c].
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IEnumerable<IReadOnlyList<string>> AllSpans() => _underlyingSentenceAlgorithms
        .allSpans()
        .ToEnumerable<java.util.List, IReadOnlyList<string>>(x => x.ToList<string>());

    /// <summary>
    /// Returns the index of the head word for a given span of the sentence, based off of the dependency parse.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser.</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public int HeadOfSpan(Range span) => _underlyingSentenceAlgorithms
        .headOfSpan(span.ToJavaSpan(_underlyingSentenceAlgorithms.sentence.length()));

    /// <summary>
    /// Selects the most common element of the given type in the given span of the sentence.
    /// <para>This is useful for, e.g., finding the most likely NER span of a given span, or the most likely POS tag of a given span.</para>
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public T ModeInSpan<T>(Range span, Func<Sentence, IEnumerable<T>> selector) => (T)_underlyingSentenceAlgorithms
        .modeInSpan(span.ToJavaSpan(_underlyingSentenceAlgorithms.sentence.length()), selector.ToJavaSelector());

    /// <summary>
    /// Returns a collection of keyphrases, defined as relevant noun phrases and verbs in the sentence. Each token of the sentence is consumed at most once.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger.</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public List<Range> KeyphraseSpans() => _underlyingSentenceAlgorithms
        .keyphraseSpans()
        .ToList<edu.stanford.nlp.ie.machinereading.structure.Span, Range>(x => x.start()..x.end());

    /// <summary>
    /// Get the keyphrases of the sentence, using the words of the sentence to convert a span into a keyphrase.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger.</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public List<string> Keyphrases() => _underlyingSentenceAlgorithms
        .keyphrases()
        .ToList<string>();

    /// <summary>
    /// Get the keyphrases of the sentence as a list of Strings.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger.</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public List<string> Keyphrases(Func<Sentence, IEnumerable<string>> selector) => _underlyingSentenceAlgorithms
        .keyphrases(selector.ToJavaSelector())
        .ToList<string>();

    /// <summary>
    /// Find the dependency path between two words in a sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser.</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public List<string> DependencyPathBetween(int startWordIndex, int endWordIndex) => _underlyingSentenceAlgorithms
        .dependencyPathBetween(startWordIndex, endWordIndex)
        .ToList<string>();

    /// <summary>
    /// Find the dependency path between two words in a sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser.</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public List<string> DependencyPathBetween(int startWordIndex, int endWordIndex, Func<Sentence, IEnumerable<string>> selector) => _underlyingSentenceAlgorithms
        .dependencyPathBetween(startWordIndex, endWordIndex, java.util.Optional.of(selector.ToJavaSelector()))
        .ToList<string>();

    /// <inheritdoc/>
    public bool Equals(SentenceAlgorithms other) => _underlyingSentenceAlgorithms.equals(other?._underlyingSentenceAlgorithms);

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as SentenceAlgorithms);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingSentenceAlgorithms.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingSentenceAlgorithms.toString();

    /// <inheritdoc/>
    public static bool operator ==(SentenceAlgorithms left, SentenceAlgorithms right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(SentenceAlgorithms left, SentenceAlgorithms right) => !(left == right);
}
