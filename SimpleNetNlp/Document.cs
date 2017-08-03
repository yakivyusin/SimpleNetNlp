using System.Collections.Generic;
using System.Linq;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp
{
    public class Document
    {
        private edu.stanford.nlp.simple.Document nlpDoc;
        private List<Sentence> sentences;

        public Document(string text)
        {
            nlpDoc = new edu.stanford.nlp.simple.Document(text);
        }

        public List<Sentence> Sentences
        {
            get
            {
                if (sentences == null)
                {
                    sentences = nlpDoc
                                    .sentences()
                                    .ToList<edu.stanford.nlp.simple.Sentence>()
                                    .Select(x => new Sentence(x))
                                    .ToList();
                }
                return sentences;
            }
        }
    }
}
