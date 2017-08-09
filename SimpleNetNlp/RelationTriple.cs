using System.Globalization;

namespace SimpleNetNlp
{
    public class RelationTriple
    {
        private static NumberStyles numberStyles = NumberStyles.AllowDecimalPoint
            | NumberStyles.AllowLeadingSign;

        public string Subject { get; set; }
        public string Relation { get; set; }
        public string Object { get; set; }
        public double Confidence { get; set; }

        internal RelationTriple(edu.stanford.nlp.util.Quadruple quad)
        {
            Subject = quad.first().ToString();
            Relation = quad.second().ToString();
            Object = quad.third().ToString();
            Confidence = double.Parse(quad.fourth().ToString(), numberStyles, CultureInfo.InvariantCulture);
        }
    }
}
