using SimpleNetNlp.Exceptions.Converters;
using SimpleNetNlp.Extensions;
using System;
using System.Collections.Generic;

namespace SimpleNetNlp
{
    /// <summary>
    /// A representation of a single Sentence.
    /// </summary>
    public class Sentence
    {
        private ExceptionConverter exceptionConverter = new ExceptionConverter();
        private edu.stanford.nlp.simple.Sentence nlpSentence;

        /// <summary>
        /// Create a new sentence from the given text, assuming the entire text is just one sentence.
        /// </summary>
        /// <param name="text">The text of the sentence.</param>
        public Sentence(string text) : this(new edu.stanford.nlp.simple.Sentence(text))
        {
        }

        /// <summary>
        /// Create a new sentence directly from the given CoreNLP Sentence isntance.
        /// </summary>
        /// <param name="nlpSentence">The CoreNLP Sentence.</param>
        internal Sentence(edu.stanford.nlp.simple.Sentence nlpSentence)
        {
            this.nlpSentence = nlpSentence;
        }

        /// <summary>
        /// The lemmas of the sentence.
        /// </summary>
        /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
        /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
        /// <returns>A list of lemmatized words, one for each token in the sentence.</returns>
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

        /// <summary>
        /// The named entity tags of the sentence.
        /// </summary>
        /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner</exception>
        /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
        /// <returns>A list of named entity tags, one for each token in the sentence.</returns>
        public IReadOnlyCollection<string> NerTags
        {
            get
            {
                var props = new java.util.Properties();
                props.setProperty("ner.useSUTime", "0");
                try
                {
                    return nlpSentence
                            .nerTags(props)
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
