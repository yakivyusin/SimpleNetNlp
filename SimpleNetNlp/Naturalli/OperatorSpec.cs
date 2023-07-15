namespace SimpleNetNlp.Naturalli;

/// <summary>
/// A representation of a quantifier scope.
/// </summary>
public class OperatorSpec : IEquatable<OperatorSpec>
{
    private readonly edu.stanford.nlp.naturalli.OperatorSpec _underlyingOperatorSpec;

    internal OperatorSpec(edu.stanford.nlp.naturalli.OperatorSpec underlyingOperatorSpec) => _underlyingOperatorSpec = underlyingOperatorSpec;

    /// <summary>
    /// The quantifier.
    /// </summary>
    public Operator OperatorInstance => new(_underlyingOperatorSpec.instance);

    /// <summary>
    /// The begin position of the quantifier.
    /// </summary>
    public int QuantifierBegin => _underlyingOperatorSpec.quantifierBegin;

    /// <summary>
    /// The end position of the quantifier.
    /// </summary>
    public int QuantifierEnd => _underlyingOperatorSpec.quantifierEnd;

    /// <summary>
    /// The length of the quantifier.
    /// </summary>
    public int QuantifierLength => _underlyingOperatorSpec.quantifierLength();

    /// <summary>
    /// The position of the quantifier head.
    /// </summary>
    public int QuantifierHead => _underlyingOperatorSpec.quantifierHead;

    /// <summary>
    /// The begin position of the subject.
    /// </summary>
    public int SubjectBegin => _underlyingOperatorSpec.subjectBegin;

    /// <summary>
    /// The end position of the subject.
    /// </summary>
    public int SubjectEnd => _underlyingOperatorSpec.subjectEnd;

    /// <summary>
    /// The begin position of the object.
    /// </summary>
    public int ObjectBegin => _underlyingOperatorSpec.objectBegin;

    /// <summary>
    /// The end position of the object.
    /// </summary>
    public int ObjectEnd => _underlyingOperatorSpec.objectEnd;

    /// <summary>
    /// Is explicit quantifier.
    /// </summary>
    public bool IsExplicit => _underlyingOperatorSpec.isExplicit();

    /// <summary>
    /// Is binary quantifier.
    /// </summary>
    public bool IsBinary => _underlyingOperatorSpec.isBinary();

    /// <summary>
    /// Merges two operator specs.
    /// </summary>
    public static OperatorSpec Merge(OperatorSpec x, OperatorSpec y) => new(edu.stanford.nlp.naturalli.OperatorSpec.merge(x._underlyingOperatorSpec, y._underlyingOperatorSpec));

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as OperatorSpec);

    /// <inheritdoc/>
    public bool Equals(OperatorSpec other) => _underlyingOperatorSpec.equals(other?._underlyingOperatorSpec);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingOperatorSpec.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingOperatorSpec.toString();

    /// <inheritdoc/>
    public static bool operator ==(OperatorSpec left, OperatorSpec right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(OperatorSpec left, OperatorSpec right) => !(left == right);
}
