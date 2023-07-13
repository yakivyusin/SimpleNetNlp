using SimpleNetNlp.Extensions;

namespace SimpleNetNlp.Coref;

/// <summary>
/// A representation of a mention for coref output. This is one instance of the entity referred to by a given <see cref="CorefChain"/>.
/// </summary>
public class CorefMention : IEquatable<CorefMention>
{
    private readonly edu.stanford.nlp.coref.data.CorefChain.CorefMention _underlyingCorefMention;

    internal CorefMention(edu.stanford.nlp.coref.data.CorefChain.CorefMention underlyingCorefMention) => _underlyingCorefMention = underlyingCorefMention;

    /// <summary>
    /// Mention type.
    /// </summary>
    public MentionType MentionType => _underlyingCorefMention.mentionType.ToMentionType();

    /// <summary>
    /// Number.
    /// </summary>
    public Number Number => _underlyingCorefMention.number.ToNumber();

    /// <summary>
    /// Animacy.
    /// </summary>
    public Animacy Animacy => _underlyingCorefMention.animacy.ToAnimacy();

    /// <summary>
    /// Gender.
    /// </summary>
    public Gender Gender => _underlyingCorefMention.gender.ToGender();

    /// <summary>
    /// Starting word number within the sentence, indexed from 1.
    /// </summary>
    public int StartIndex => _underlyingCorefMention.startIndex;

    /// <summary>
    /// One past the end word number within the sentence, indexed from 1.
    /// </summary>
    public int EndIndex => _underlyingCorefMention.endIndex;

    /// <summary>
    /// Head word of the mention.
    /// </summary>
    public int HeadIndex => _underlyingCorefMention.headIndex;

    /// <summary>
    /// Coref cluster id.
    /// </summary>
    public int CorefClusterId => _underlyingCorefMention.corefClusterID;

    /// <summary>
    /// Mention id.
    /// </summary>
    public int MentionId => _underlyingCorefMention.mentionID;

    /// <summary>
    /// Sentence number in the document containing this mention, indexed from 1.
    /// </summary>
    public int SentenceNumber => _underlyingCorefMention.sentNum;

    /// <summary>
    /// Position is a binary tuple of (sentence number, mention number in that sentence). This is used for indexing by mention.
    /// </summary>
    public (int SentenceNumber, int MentionNumber) Position => _underlyingCorefMention.position.ToTuple();

    /// <summary>
    /// Mention span.
    /// </summary>
    public string MentionSpan => _underlyingCorefMention.mentionSpan;

    /// <inheritdoc/>
    public bool Equals(CorefMention other) => _underlyingCorefMention.equals(other?._underlyingCorefMention);

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as CorefMention);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingCorefMention.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingCorefMention.ToString();

    /// <inheritdoc/>
    public static bool operator ==(CorefMention left, CorefMention right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(CorefMention left, CorefMention right) => !(left == right);

    /// <inheritdoc/>
    public static implicit operator edu.stanford.nlp.coref.data.CorefChain.CorefMention(CorefMention m) => m._underlyingCorefMention;
}
