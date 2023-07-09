using SimpleNetNlp.Extensions;

namespace SimpleNetNlp.Naturalli;

/// <summary>
/// A representation of a quantifier.
/// </summary>
public class Operator : IEquatable<Operator>
{
#pragma warning disable CS1591
    public static readonly Operator All = new(edu.stanford.nlp.naturalli.Operator.ALL);
    public static readonly Operator Every = new(edu.stanford.nlp.naturalli.Operator.EVERY);
    public static readonly Operator Any = new(edu.stanford.nlp.naturalli.Operator.ANY);
    public static readonly Operator Each = new(edu.stanford.nlp.naturalli.Operator.EACH);
    public static readonly Operator TheLotOf = new(edu.stanford.nlp.naturalli.Operator.THE_LOT_OF);
    public static readonly Operator AllOf = new(edu.stanford.nlp.naturalli.Operator.ALL_OF);
    public static readonly Operator EachOf = new(edu.stanford.nlp.naturalli.Operator.EACH_OF);
    public static readonly Operator ForAll = new(edu.stanford.nlp.naturalli.Operator.FOR_ALL);
    public static readonly Operator ForEach = new(edu.stanford.nlp.naturalli.Operator.FOR_EACH);
    public static readonly Operator ForEvery = new(edu.stanford.nlp.naturalli.Operator.FOR_EVERY);
    public static readonly Operator Everyone = new(edu.stanford.nlp.naturalli.Operator.EVERYONE);
    public static readonly Operator Num = new(edu.stanford.nlp.naturalli.Operator.NUM);
    public static readonly Operator NumNum = new(edu.stanford.nlp.naturalli.Operator.NUM_NUM);
    public static readonly Operator NumNumNum = new(edu.stanford.nlp.naturalli.Operator.NUM_NUM_NUM);
    public static readonly Operator NumNumNumNum = new(edu.stanford.nlp.naturalli.Operator.NUM_NUM_NUM_NUM);
    public static readonly Operator Few = new(edu.stanford.nlp.naturalli.Operator.FEW);
    public static readonly Operator ImplicitNamedEntity = new(edu.stanford.nlp.naturalli.Operator.IMPLICIT_NAMED_ENTITY);
    public static readonly Operator No = new(edu.stanford.nlp.naturalli.Operator.NO);
    public static readonly Operator Neither = new(edu.stanford.nlp.naturalli.Operator.NEITHER);
    public static readonly Operator NoOne = new(edu.stanford.nlp.naturalli.Operator.NO_ONE);
    public static readonly Operator Nobody = new(edu.stanford.nlp.naturalli.Operator.NOBODY);
    public static readonly Operator Not = new(edu.stanford.nlp.naturalli.Operator.NOT);
    public static readonly Operator But = new(edu.stanford.nlp.naturalli.Operator.BUT);
    public static readonly Operator Except = new(edu.stanford.nlp.naturalli.Operator.EXCEPT);
    public static readonly Operator UnaryNo = new(edu.stanford.nlp.naturalli.Operator.UNARY_NO);
    public static readonly Operator UnaryNot = new(edu.stanford.nlp.naturalli.Operator.UNARY_NOT);
    public static readonly Operator UnaryNoOne = new(edu.stanford.nlp.naturalli.Operator.UNARY_NO_ONE);
    public static readonly Operator UnaryNt = new(edu.stanford.nlp.naturalli.Operator.UNARY_NT);
    public static readonly Operator UnaryBut = new(edu.stanford.nlp.naturalli.Operator.UNARY_BUT);
    public static readonly Operator UnaryExcept = new(edu.stanford.nlp.naturalli.Operator.UNARY_EXCEPT);
    public static readonly Operator GeneralNegPolarity = new(edu.stanford.nlp.naturalli.Operator.GENERAL_NEG_POLARITY);
    public static readonly Operator Some = new(edu.stanford.nlp.naturalli.Operator.SOME);
    public static readonly Operator Several = new(edu.stanford.nlp.naturalli.Operator.SEVERAL);
    public static readonly Operator Either = new(edu.stanford.nlp.naturalli.Operator.EITHER);
    public static readonly Operator A = new(edu.stanford.nlp.naturalli.Operator.A);
    public static readonly Operator The = new(edu.stanford.nlp.naturalli.Operator.THE);
    public static readonly Operator LessThan = new(edu.stanford.nlp.naturalli.Operator.LESS_THAN);
    public static readonly Operator SomeOf = new(edu.stanford.nlp.naturalli.Operator.SOME_OF);
    public static readonly Operator OneOf = new(edu.stanford.nlp.naturalli.Operator.ONE_OF);
    public static readonly Operator AtLeast = new(edu.stanford.nlp.naturalli.Operator.AT_LEAST);
    public static readonly Operator AFew = new(edu.stanford.nlp.naturalli.Operator.A_FEW);
    public static readonly Operator AtLeastAFew = new(edu.stanford.nlp.naturalli.Operator.AT_LEAST_A_FEW);
    public static readonly Operator ThereBe = new(edu.stanford.nlp.naturalli.Operator.THERE_BE);
    public static readonly Operator ThereBeAFew = new(edu.stanford.nlp.naturalli.Operator.THERE_BE_A_FEW);
    public static readonly Operator ThereExist = new(edu.stanford.nlp.naturalli.Operator.THERE_EXIST);
    public static readonly Operator NumOf = new(edu.stanford.nlp.naturalli.Operator.NUM_OF);
    public static readonly Operator NotAll = new(edu.stanford.nlp.naturalli.Operator.NOT_ALL);
    public static readonly Operator NotEvery = new(edu.stanford.nlp.naturalli.Operator.NOT_EVERY);
    public static readonly Operator Most = new(edu.stanford.nlp.naturalli.Operator.MOST);
    public static readonly Operator More = new(edu.stanford.nlp.naturalli.Operator.MORE);
    public static readonly Operator Many = new(edu.stanford.nlp.naturalli.Operator.MANY);
    public static readonly Operator Enough = new(edu.stanford.nlp.naturalli.Operator.ENOUGH);
    public static readonly Operator MoreThan = new(edu.stanford.nlp.naturalli.Operator.MORE_THAN);
    public static readonly Operator LotsOf = new(edu.stanford.nlp.naturalli.Operator.LOTS_OF);
    public static readonly Operator PlentyOf = new(edu.stanford.nlp.naturalli.Operator.PLENTY_OF);
    public static readonly Operator HeapsOf = new(edu.stanford.nlp.naturalli.Operator.HEAPS_OF);
    public static readonly Operator ALoadOf = new(edu.stanford.nlp.naturalli.Operator.A_LOAD_OF);
    public static readonly Operator LoadsOf = new(edu.stanford.nlp.naturalli.Operator.LOADS_OF);
    public static readonly Operator TonsOf = new(edu.stanford.nlp.naturalli.Operator.TONS_OF);
    public static readonly Operator Both = new(edu.stanford.nlp.naturalli.Operator.BOTH);
    public static readonly Operator JustNum = new(edu.stanford.nlp.naturalli.Operator.JUST_NUM);
    public static readonly Operator OnlyNum = new(edu.stanford.nlp.naturalli.Operator.ONLY_NUM);
    public static readonly Operator AtMostNum = new(edu.stanford.nlp.naturalli.Operator.AT_MOST_NUM);
#pragma warning restore CS1591

    private readonly edu.stanford.nlp.naturalli.Operator _underlyingOperator;

    internal Operator(edu.stanford.nlp.naturalli.Operator underlyingOperator) => _underlyingOperator = underlyingOperator;

    /// <summary>
    /// The surface form.
    /// </summary>
    public string SurfaceForm => _underlyingOperator.surfaceForm;

    /// <summary>
    /// The monotonicity of the subject.
    /// </summary>
    public Monotonicity SubjectMonotonicity => _underlyingOperator.subjMono.ToMonotonicity();

    /// <summary>
    /// The monotonicity type of the subject.
    /// </summary>
    public MonotonicityType SubjectMonotonicityType => _underlyingOperator.subjType.ToMonotonicityType();

    /// <summary>
    /// The monotonicity of the object.
    /// </summary> 
    public Monotonicity ObjectMonotonicity => _underlyingOperator.objMono.ToMonotonicity();

    /// <summary>
    /// The monotonicity type of the object.
    /// </summary>
    public MonotonicityType ObjectMonotonicityType => _underlyingOperator.objType.ToMonotonicityType();

    /// <summary>
    /// The delete relation.
    /// </summary>
    public NaturalLogicRelation DeleteRelation => new(_underlyingOperator.deleteRelation);

    /// <summary>
    /// Is unary.
    /// </summary>
    public bool IsUnary => _underlyingOperator.isUnary();

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as Operator);

    /// <inheritdoc/>
    public bool Equals(Operator other) => _underlyingOperator.equals(other?._underlyingOperator);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingOperator.hashCode();

    /// <inheritdoc/>
    public override string ToString() => _underlyingOperator.toString();

    /// <inheritdoc/>
    public static bool operator ==(Operator left, Operator right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(Operator left, Operator right) => !(left == right);
}
