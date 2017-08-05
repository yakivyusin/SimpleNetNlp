using SimpleNetNlp.Exceptions.Converters;
using SimpleNetNlp.Extensions;
using System;
using System.Collections.Generic;

namespace SimpleNetNlp
{
    public class Sentence
    {
        private ExceptionConverter exceptionConverter = new ExceptionConverter();
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
                try
                {
                    return nlpSentence
                            .lemmas()
                            .ToList<string>()
                            .AsReadOnly();
                }
                catch (Exception e)
                {
                    throw exceptionConverter.WrapException(e);
                }    
            }
        }
    }
}
