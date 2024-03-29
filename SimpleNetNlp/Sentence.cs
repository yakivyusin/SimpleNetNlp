﻿using SimpleNetNlp.Coref;
using SimpleNetNlp.Exceptions;
using SimpleNetNlp.Extensions;
using SimpleNetNlp.Naturalli;

namespace SimpleNetNlp;

/// <summary>
/// A representation of a single Sentence.
/// </summary>
public class Sentence : IEquatable<Sentence>
{
    private readonly edu.stanford.nlp.simple.Sentence _underlyingSentence;

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
    /// <param name="underlyingSentence">The CoreNLP Sentence.</param>
    internal Sentence(edu.stanford.nlp.simple.Sentence underlyingSentence)
    {
        _underlyingSentence = underlyingSentence;
        _underlyingSentence.Properties().setProperty("ner.useSUTime", "0");
    }

    /// <summary>
    /// The begin position of each token in the sentence.
    /// </summary>
    public IReadOnlyList<int> CharacterOffsetBegin => _underlyingSentence
        .characterOffsetBegin()
        .ToList<java.lang.Integer, int>(x => x.ToInt())
        .AsReadOnly();

    /// <summary>
    /// The end position of each token in the sentence.
    /// </summary>
    public IReadOnlyList<int> CharacterOffsetEnd => _underlyingSentence
        .characterOffsetEnd()
        .ToList<java.lang.Integer, int>(x => x.ToInt())
        .AsReadOnly();

    /// <summary>
    /// The index of the sentence within the document.
    /// </summary>
    public int SentenceIndex => _underlyingSentence.sentenceIndex();

    /// <summary>
    /// The begin position (in tokens) of the sentence within the document.
    /// </summary>
    public int SentenceTokenOffsetBegin => _underlyingSentence.sentenceTokenOffsetBegin();

    /// <summary>
    /// The end position (in tokens) of the sentence within the document.
    /// </summary>
    public int SentenceTokenOffsetEnd => _underlyingSentence.sentenceTokenOffsetEnd();

    /// <summary>
    /// The words of the sentence.
    /// </summary>
    public IReadOnlyList<string> Words => _underlyingSentence
        .words()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// The original (unprocessed) words of the sentence.
    /// </summary>
    public IReadOnlyList<string> OriginalWords => _underlyingSentence
        .originalTexts()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Get the original (raw) text of this sentence.
    /// </summary>
    public string OriginalText => _underlyingSentence.text();

    /// <summary>
    /// Get the whitespace before each token in the sentence.
    /// </summary>
    public IReadOnlyList<string> Before => _underlyingSentence
        .before()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Get the whitespace after each token in the sentence.
    /// </summary>
    public IReadOnlyList<string> After => _underlyingSentence
        .after()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns the lemmas of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> Lemmas() => _underlyingSentence
        .lemmas()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns the named entity tags of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> NerTags() => _underlyingSentence
        .nerTags()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns the part of speech tags of the sentence, one for each token in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> PosTags() => _underlyingSentence
        .posTags()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns a collection of <see cref="RelationTriple"/> objects representing the OpenIE triples in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser, Naturalli</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<RelationTriple> OpenIe() => _underlyingSentence
        .openie()
        .ToList<edu.stanford.nlp.util.Quadruple, RelationTriple>(x => new RelationTriple(x))
        .AsReadOnly();

    /// <summary>
    /// Returns the governors of a sentence.
    /// <para>The resulting list is of the same size as the original sentence, with each element being either the governor index, or null if the node has no known governor.</para>
    /// <para>The root has index -1.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<int?> Governors() => _underlyingSentence
        .governors()
        .ToList<java.util.Optional, int?>(x => x.isPresent() ? (x.get() as java.lang.Integer).ToInt() : null)
        .AsReadOnly();

    /// <summary>
    /// Returns the incoming dependency labels of a sentence.
    /// <para>The resulting list is of the same size as the original sentence, with each element being either the incoming dependency label, or null.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> IncomingDependencyLabels() => _underlyingSentence
        .incomingDependencyLabels()
        .ToList<java.util.Optional, string>(x => x.isPresent() ? x.get() as string : null)
        .AsReadOnly();

    /// <summary>
    /// Returns the sentiment of this sentence (e.g., positive / negative). See the <see cref="SentimentClass"/> enum for possible values.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: LexParser, Sentiment</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public SentimentClass Sentiment() => _underlyingSentence
        .sentiment()
        .ToSentimentClass();

    /// <summary>
    /// Returns all mentions of any NER tag, as a list of surface forms.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> Mentions() => _underlyingSentence
        .mentions()
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns all mentions of the given NER tag, as a list of surface forms.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<string> Mentions(string nerTag) => _underlyingSentence
        .mentions(nerTag)
        .ToList<string>()
        .AsReadOnly();

    /// <summary>
    /// Returns a collection of <see cref="RelationTriple"/> objects representing the KBP triples in the sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner, Kbp, Parser, DeterministicCoref, Coref</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<RelationTriple> Kbp() => _underlyingSentence
        .kbp()
        .ToList<edu.stanford.nlp.util.Quadruple, RelationTriple>(x => new RelationTriple(x))
        .AsReadOnly();

    /// <summary>
    /// Returns a collection of the (possible) natural logic operators on each node of the sentence.
    /// <para>At each index, the list contains an operator spec if that index is the head word of an operator in the sentence.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<OperatorSpec> Operators() => _underlyingSentence
        .operators()
        .ToList<java.util.Optional, OperatorSpec>(x => x.isPresent() ? new(x.get() as edu.stanford.nlp.naturalli.OperatorSpec) : null)
        .AsReadOnly();

    /// <summary>
    /// Returns the coreference chain for just this sentence.
    /// <para>Note that this method is actually fairly computationally expensive to call, as it constructs and prunes the coreference data structure for the entire document.</para>
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Ner, Kbp, Parser, DeterministicCoref, Coref</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyDictionary<int, CorefChain> Coref() => _underlyingSentence
        .coref()
        .ToDictionary(
            (java.lang.Integer x) => x.ToInt(),
            (edu.stanford.nlp.coref.data.CorefChain x) => new CorefChain(x));

    /// <summary>
    /// Returns the Natural Logic notion of polarity for each token in a sentence.
    /// </summary>
    /// <exception cref="Exceptions.MissingModelException">Thrown when library cannot find model files: PosTagger, Parser</exception>
    /// <exception cref="Exceptions.UnhandledLibraryException">Thrown when an unexpected exception is caused by CoreNLP library.</exception>
    [ExceptionConverterAspect]
    public IReadOnlyList<Polarity> NaturalLogicPolarities() => _underlyingSentence
        .natlogPolarities()
        .ToList<edu.stanford.nlp.naturalli.Polarity, Polarity>(x => new(x))
        .AsReadOnly();

    /// <summary>
    /// Returns the <see cref="SentenceAlgorithms"/> instance for this sentence.
    /// </summary>
    public SentenceAlgorithms Algorithms => new(_underlyingSentence.algorithms());

    /// <inheritdoc/>
    public bool Equals(Sentence other) => _underlyingSentence.equals(other?._underlyingSentence);

    /// <inheritdoc/>
    public override string ToString() => _underlyingSentence.toString();

    /// <inheritdoc/>
    public override bool Equals(object obj) => Equals(obj as Sentence);

    /// <inheritdoc/>
    public override int GetHashCode() => _underlyingSentence.hashCode();

    /// <inheritdoc/>
    public static implicit operator edu.stanford.nlp.simple.Sentence(Sentence s) => s._underlyingSentence;

    /// <inheritdoc/>
    public static explicit operator Sentence(edu.stanford.nlp.simple.Sentence s) => new(s);

    /// <inheritdoc/>
    public static bool operator ==(Sentence left, Sentence right) => (left, right) switch
    {
        (null, null) => true,
        (null, _) => false,
        (_, _) => left.Equals(right)
    };

    /// <inheritdoc/>
    public static bool operator !=(Sentence left, Sentence right) => !(left == right);
}
