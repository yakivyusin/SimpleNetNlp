namespace SimpleNetNlp
{
    public class Sentence
    {
        private edu.stanford.nlp.simple.Sentence nlpSentence;

        public Sentence(string text)
        {
            nlpSentence = new edu.stanford.nlp.simple.Sentence(text);
        }

        internal Sentence(edu.stanford.nlp.simple.Sentence nlpSentence)
        {
            this.nlpSentence = nlpSentence;
        }
    }
}
