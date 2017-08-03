using SimpleNetNlp.Extensions;
using System.Collections.Generic;

namespace SimpleNetNlp
{
    public class Sentence
    {
        private edu.stanford.nlp.simple.Sentence nlpSentence;

        public Sentence(string text) : this(new edu.stanford.nlp.simple.Sentence(text))
        {
        }

        internal Sentence(edu.stanford.nlp.simple.Sentence nlpSentence)
        {
            this.nlpSentence = nlpSentence;
        }

        public IReadOnlyCollection<string> Lemmas
        {
            get
            {
                return nlpSentence
                        .lemmas()
                        .ToList<string>()
                        .AsReadOnly();    
            }
        }
    }
}
