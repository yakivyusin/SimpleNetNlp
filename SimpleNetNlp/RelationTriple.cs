using System.Globalization;

namespace SimpleNetNlp;

/// <summary>
/// A representation of a Relation Triple (Subject - Relation -> Object).
/// </summary>
public class RelationTriple
{
    /// <summary>
    /// Relation subject
    /// </summary>
    public string Subject { get; }

    /// <summary>
    /// Type of relation
    /// </summary>
    public string Relation { get; }

    /// <summary>
    /// Relation subject
    /// </summary>
    public string Object { get; }

    /// <summary>
    /// Confidence
    /// </summary>
    public double Confidence { get; }

    internal RelationTriple(edu.stanford.nlp.util.Quadruple quad)
    {
        Subject = quad.first().ToString();
        Relation = quad.second().ToString();
        Object = quad.third().ToString();
        Confidence = double.Parse(quad.fourth().ToString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
    }
}
