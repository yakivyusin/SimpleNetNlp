using SimpleNetNlp.Exceptions;

namespace SimpleNetNlp.Naturalli;

/// <summary>
/// A class intended to be attached to a lexical item, determining what mutations are valid on it while maintaining valid Natural Logic inference.
/// </summary>
public class Polarity : IEquatable<Polarity>
{
    private readonly edu.stanford.nlp.naturalli.Polarity _underlyingPolarity;

    internal Polarity(edu.stanford.nlp.naturalli.Polarity underlyingPolarity) => _underlyingPolarity = underlyingPolarity;

    /// <summary>
    /// This word has upward polarity.
    /// </summary>
    public bool IsUpwards => _underlyingPolarity.isUpwards();

    /// <summary>
    /// This word has downward polarity.
    /// </summary>
    public bool IsDownwards => _underlyingPolarity.isDownwards();

    /// <summary>
    /// Projects the given natural logic lexical relation on this word.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public NaturalLogicRelation ProjectLexicalRelation(NaturalLogicRelation lexicalRelation) => (NaturalLogicRelation)_underlyingPolarity.projectLexicalRelation(lexicalRelation);

    /// <summary>
    /// If <see langword="true"/>, applying this lexical relation to this word creates a sentence which is entailed by the original sentence.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public bool MaintainsTruth(NaturalLogicRelation lexicalRelation) => _underlyingPolarity.maintainsTruth(lexicalRelation);

    /// <summary>
    /// If <see langword="true"/>, applying this lexical relation to this word creates a sentence which is negated by the original sentence.
    /// </summary>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public bool NegatesTruth(NaturalLogicRelation lexicalRelation) => _underlyingPolarity.negatesTruth(lexicalRelation);

    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public bool MaintainsFalsehood(NaturalLogicRelation lexicalRelation) => _underlyingPolarity.maintainsFalsehood(lexicalRelation);

    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public bool NegatesFalsehood(NaturalLogicRelation lexicalRelation) => _underlyingPolarity.negatesFalsehood(lexicalRelation);

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as OperatorSpec);

    /// <inheritdoc/>
    public bool Equals(Polarity other) => _underlyingPolarity.equals(other?._underlyingPolarity);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingPolarity.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingPolarity.toString();

    /// <inheritdoc/>
    public static bool operator ==(Polarity left, Polarity right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(Polarity left, Polarity right) => !(left == right);
}
