using SimpleNetNlp.Extensions;

namespace SimpleNetNlp.Naturalli;

/// <summary>
/// A representation of a natural logic relation.
/// </summary>
public class NaturalLogicRelation : IEquatable<NaturalLogicRelation>
{
    /// <summary>
    /// A = B
    /// </summary>
    public static readonly NaturalLogicRelation Equivalent = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.EQUIVALENT);
    
    /// <summary>
    /// A \\subset B
    /// </summary>
    public static readonly NaturalLogicRelation ForwardEntailment = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.FORWARD_ENTAILMENT);

    /// <summary>
    /// A \\supset B
    /// </summary>
    public static readonly NaturalLogicRelation ReverseEntailment = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.REVERSE_ENTAILMENT);

    /// <summary>
    /// A \\intersect B = \\empty \\land A \\union B = D
    /// </summary>
    public static readonly NaturalLogicRelation Negation = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.NEGATION);

    /// <summary>
    /// A \\intersect B = \\empty
    /// </summary>
    public static readonly NaturalLogicRelation Alternation = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.ALTERNATION);

    /// <summary>
    /// A \\union B = D
    /// </summary>
    public static readonly NaturalLogicRelation Cover = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.COVER);
    
    /// <summary>
    /// A and B are independent
    /// </summary>
    public static readonly NaturalLogicRelation Independence = new(edu.stanford.nlp.naturalli.NaturalLogicRelation.INDEPENDENCE);

    private readonly edu.stanford.nlp.naturalli.NaturalLogicRelation _underlyingRelation;

    internal NaturalLogicRelation(edu.stanford.nlp.naturalli.NaturalLogicRelation underlyingRelation) => _underlyingRelation = underlyingRelation;

    /// <summary>
    /// A fixed index of this relation.
    /// </summary>
    public int FixedIndex => _underlyingRelation.fixedIndex;

    /// <summary>
    /// Determines whether this relation maintains the truth of a fact in a true context.
    /// </summary>
    public bool MaintainsTruth => _underlyingRelation.maintainsTruth;

    /// <summary>
    /// Determines whether this relation negates the truth of a fact in a true context.
    /// </summary>
    public bool NegatesTruth => _underlyingRelation.negatesTruth;

    /// <summary>
    /// Determines whether this relation maintains the falsehood of a false fact.
    /// </summary>
    public bool MaintainsFalsehood => _underlyingRelation.maintainsFalsehood;

    /// <summary>
    /// Determines whether this relation negates the truth of a fact in a false context.
    /// </summary>
    public bool NegatesFalsehood => _underlyingRelation.negatesFalsehood;

    /// <summary>
    /// Returns whether this is a known dependency arc.
    /// </summary>
    public static bool KnownDependencyArc(string dependencyLabel) => edu.stanford.nlp.naturalli.NaturalLogicRelation.knownDependencyArc(dependencyLabel);

    /// <summary>
    /// Returns the natural logic relation corresponding to the given dependency arc being inserted into a sentence.
    /// </summary>
    public static NaturalLogicRelation ForDependencyInsertion(string dependencyLabel) => new(edu.stanford.nlp.naturalli.NaturalLogicRelation.forDependencyInsertion(dependencyLabel));

    /// <summary>
    /// Returns the natural logic relation corresponding to the given dependency arc being inserted into a sentence.
    /// </summary>
    public static NaturalLogicRelation ForDependencyInsertion(string dependencyLabel, bool isSubject) => new(edu.stanford.nlp.naturalli.NaturalLogicRelation.forDependencyInsertion(dependencyLabel, isSubject));

    /// <summary>
    /// Returns the natural logic relation corresponding to the given dependency arc being inserted into a sentence.
    /// </summary>
    public static NaturalLogicRelation ForDependencyInsertion(string dependencyLabel, bool isSubject, string dependent) => new(edu.stanford.nlp.naturalli.NaturalLogicRelation.forDependencyInsertion(dependencyLabel, isSubject, dependent.NullableToOptional()));

    /// <summary>
    /// Returns the natural logic relation corresponding to the given dependency arc being deleted from a sentence.
    /// </summary>
    public static NaturalLogicRelation ForDependencyDeletion(string dependencyLabel) => new(edu.stanford.nlp.naturalli.NaturalLogicRelation.forDependencyDeletion(dependencyLabel));

    /// <summary>
    /// Returns the natural logic relation corresponding to the given dependency arc being deleted from a sentence.
    /// </summary>
    public static NaturalLogicRelation ForDependencyDeletion(string dependencyLabel, bool isSubject) => new(edu.stanford.nlp.naturalli.NaturalLogicRelation.forDependencyDeletion(dependencyLabel, isSubject));

    /// <summary>
    /// Returns the natural logic relation corresponding to the given dependency arc being deleted from a sentence.
    /// </summary>
    public static NaturalLogicRelation ForDependencyDeletion(string dependencyLabel, bool isSubject, string dependent) => new(edu.stanford.nlp.naturalli.NaturalLogicRelation.forDependencyDeletion(dependencyLabel, isSubject, dependent.NullableToOptional()));

    /// <summary>
    /// The MacCartney "join table" -- this determines the transitivity of entailment if we chain two relations together.
    /// </summary>
    public NaturalLogicRelation Join(NaturalLogicRelation other) => new(_underlyingRelation.join(other._underlyingRelation));

    /// <summary>
    /// Implements the finite state automata of composing the truth value of a sentence with a natural logic relation being applied.
    /// </summary>
    public bool? ApplyToTruthValue(bool initialTruthValue)
    {
        var value = _underlyingRelation.applyToTruthValue(initialTruthValue);

        if (value.isTrue())
        {
            return true;
        }
        else if (value.isFalse())
        {
            return false;
        }
        else
        {
            return null;
        }
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as NaturalLogicRelation);

    /// <inheritdoc/>
    public bool Equals(NaturalLogicRelation other) => _underlyingRelation.equals(other?._underlyingRelation);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingRelation.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingRelation.ToString();

    /// <inheritdoc/>
    public static bool operator ==(NaturalLogicRelation left, NaturalLogicRelation right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(NaturalLogicRelation left, NaturalLogicRelation right) => !(left == right);
}
