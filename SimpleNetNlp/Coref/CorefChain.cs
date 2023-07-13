using SimpleNetNlp.Exceptions;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp.Coref;

/// <summary>
/// Output of coref system. Each <see cref="CorefChain"/> represents a set of mentions in the text which should all correspond to the same actual entity.
/// There is a representative mention, which stores the best mention of an entity, and then there is a List of all mentions that are coreferent with that mention.
/// The <see cref="MentionMap"/> maps from pairs of a sentence number and a head word index to a <see cref="CorefMention"/>.
/// The <see cref="ChainId"/> is an arbitrary integer for the chain number.
/// </summary>
public class CorefChain : IEquatable<CorefChain>
{
    private readonly edu.stanford.nlp.coref.data.CorefChain _underlyingCorefChain;

    internal CorefChain(edu.stanford.nlp.coref.data.CorefChain underlyingCorefChain) => _underlyingCorefChain = underlyingCorefChain;

    /// <summary>
    /// The most representative mention in this cluster.
    /// </summary>
    public CorefMention RepresentativeMention => new(_underlyingCorefChain.getRepresentativeMention());

    /// <summary>
    /// Chain number.
    /// </summary>
    public int ChainId => _underlyingCorefChain.getChainID();

    /// <summary>
    /// All mentions, mapped by their position.
    /// </summary>
    public ILookup<(int SentenceNumber, int HeadIndex), CorefMention> MentionMap => _underlyingCorefChain
        .getMentionMap()
        .ToLookup(
            (edu.stanford.nlp.util.IntPair x) => x.ToTuple(),
            (edu.stanford.nlp.coref.data.CorefChain.CorefMention x) => new CorefMention(x));

    /// <summary>
    /// All mentions, in textual order.
    /// </summary>
    public IReadOnlyList<CorefMention> Mentions => _underlyingCorefChain
        .getMentionsInTextualOrder()
        .ToList<edu.stanford.nlp.coref.data.CorefChain.CorefMention, CorefMention>(x => new CorefMention(x))
        .AsReadOnly();

    /// <summary>
    /// Returns CorefMentions by position (sentence number, headIndex). Can be multiple mentions sharing headword.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<CorefMention> GetMentionsWithSameHead((int SentenceNumber, int HeadIndex) position) => _underlyingCorefChain
        .getMentionsWithSameHead(position.ToIntPair())
        .ToList<edu.stanford.nlp.coref.data.CorefChain.CorefMention, CorefMention>(x => new CorefMention(x))
        .AsReadOnly();

    /// <summary>
    /// Returns CorefMentions by position (sentence number, headIndex). Can be multiple mentions sharing headword.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<CorefMention> GetMentionsWithSameHead(int sentenceNumber, int headIndex) => _underlyingCorefChain
        .getMentionsWithSameHead(sentenceNumber, headIndex)
        .ToList<edu.stanford.nlp.coref.data.CorefChain.CorefMention, CorefMention>(x => new CorefMention(x))
        .AsReadOnly();

    /// <summary>
    /// Deletes the mention.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public void DeleteMention(CorefMention corefMention) => _underlyingCorefChain.deleteMention(corefMention);

    /// <inheritdoc/>
    public bool Equals(CorefChain other) => _underlyingCorefChain.equals(other?._underlyingCorefChain);

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as CorefChain);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingCorefChain.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingCorefChain.toString();

    /// <inheritdoc/>
    public static bool operator ==(CorefChain left, CorefChain right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(CorefChain left, CorefChain right) => !(left == right);
}
