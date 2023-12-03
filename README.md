# SimpleNetNlp [![NuGet](https://img.shields.io/nuget/v/SimpleNetNlp.svg)](https://www.nuget.org/packages/SimpleNetNlp/) [![Made in Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)
SimpleNetNlp is a simple, C#-way wrapper for [Stanford CoreNLP](https://github.com/stanfordnlp/CoreNLP/) that based on [Stanford.NLP.NET](https://github.com/sergey-tihon/Stanford.NLP.NET).

## Quick Start
Just install the main SimpleNetNlp package and the model packages you need...
```
    Install-Package SimpleNetNlp
    Install-Package SimpleNetNlp.Models.PosTagger
```
...and use it.
```C#
using SimpleNetNlp;
...
var sentence = new Sentence("Your sentence should go here.");
var words = sentence.Words;
var lemmas = sentence.Lemmas();
var pos = sentence.PosTags();
```

## Features
1. **Simple.** SimpleNetNlp is based on [Simple CoreNLP API](https://stanfordnlp.github.io/CoreNLP/simple.html) that provides a simple API for users who do not need a lot of customization. If you want to start working with NLP as fast and easily as possible, and do not care about the details of the behaviors of the algorithms, this package is perfect for you.
2. **C#-way.** SimpleNetNlp provides a 100% C# API without Java classes. Use the Force of LINQ and other C# magic, Luke!
3. **Clean Namespaces.**. IKVM.NET and Stanford.NLP.NET are delivered as content, so available namespaces in your project aren't littered with Java namespaces. 
4. **Model Packages.** The large 'Stanford CoreNLP Models' Java package is split into [small Nuget packages](https://github.com/yakivyusin/SimpleNetNlp.Models), one per feature. Just install individual models for your task.

## Versioning
The first three digits of the version of any package match the version of Stanford CoreNLP in use. The last fourth digit is used for numbering the own package releases. With the transition to the new version of Stanford CoreNLP, this digit is reset to 0. E.g., v.3.8.0.7 is the 8th release with Stanford CoreNLP v.3.8.0 used.

Since only one digit is used for the library's own releases, its change can mean major changes as well. When updating the used library version, please always refer to the release notes.

The first three digits of the installed main SimpleNetNlp package and model packages must match (ie, use the same version of Stanford CoreNLP). The fourth digits may not match because each package can be released and updated separately, but for model packages among releases with the same three digits, it is recommended to use the versions with the highest fourth digits.

## NLP Methods <-> Model Packages
Different NLP features require different model packages to be installed, in addition to the main SimpleNetNlp package.

All properties and methods of standard C# interfaces (like `Equals()` or `ToString()`) don't require additional model packages - you can start using them immediately without any worries.

When you call a method without installing the required model packages, the `SimpleNetNlp.Exceptions.MissingModelException` exception will be thrown.
The model-dependent APIs are listed below. In addition, each method has a description of the required model packages in XML-doc.

### `Document` class
| Method | Packages |
|--------|----------|
| `Coref()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Ner?label=SimpleNetNlp.Models.Ner)](https://www.nuget.org/packages/SimpleNetNlp.Models.Ner/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Kbp?label=SimpleNetNlp.Models.Kbp)](https://www.nuget.org/packages/SimpleNetNlp.Models.Kbp/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.DeterministicCoref?label=SimpleNetNlp.Models.DeterministicCoref)](https://www.nuget.org/packages/SimpleNetNlp.Models.DeterministicCoref/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Coref?label=SimpleNetNlp.Models.Coref)](https://www.nuget.org/packages/SimpleNetNlp.Models.Coref/) |

### `Sentence` class
| Method | Packages |
|--------|----------|
| `Lemmas()` |  [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/) |
| `NerTags()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Ner?label=SimpleNetNlp.Models.Ner)](https://www.nuget.org/packages/SimpleNetNlp.Models.Ner/) |
| `PosTags()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/) |
| `OpenIe()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Naturalli?label=SimpleNetNlp.Models.Naturalli)](https://www.nuget.org/packages/SimpleNetNlp.Models.Naturalli/) |
| `Governors()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/) |
| `IncomingDependencyLabels()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/) |
| `Sentiment()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.LexParser?label=SimpleNetNlp.Models.LexParser)](https://www.nuget.org/packages/SimpleNetNlp.Models.LexParser/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Sentiment?label=SimpleNetNlp.Models.Sentiment)](https://www.nuget.org/packages/SimpleNetNlp.Models.Sentiment/) |
| `Mentions()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Ner?label=SimpleNetNlp.Models.Ner)](https://www.nuget.org/packages/SimpleNetNlp.Models.Ner/) |
| `Kbp()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Ner?label=SimpleNetNlp.Models.Ner)](https://www.nuget.org/packages/SimpleNetNlp.Models.Ner/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Kbp?label=SimpleNetNlp.Models.Kbp)](https://www.nuget.org/packages/SimpleNetNlp.Models.Kbp/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.DeterministicCoref?label=SimpleNetNlp.Models.DeterministicCoref)](https://www.nuget.org/packages/SimpleNetNlp.Models.DeterministicCoref/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Coref?label=SimpleNetNlp.Models.Coref)](https://www.nuget.org/packages/SimpleNetNlp.Models.Coref/) |
| `Coref()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Ner?label=SimpleNetNlp.Models.Ner)](https://www.nuget.org/packages/SimpleNetNlp.Models.Ner/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Kbp?label=SimpleNetNlp.Models.Kbp)](https://www.nuget.org/packages/SimpleNetNlp.Models.Kbp/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.DeterministicCoref?label=SimpleNetNlp.Models.DeterministicCoref)](https://www.nuget.org/packages/SimpleNetNlp.Models.DeterministicCoref/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Coref?label=SimpleNetNlp.Models.Coref)](https://www.nuget.org/packages/SimpleNetNlp.Models.Coref/) |
| `Operators()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/) |
| `NaturalLogicPolarities()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/) |

### `SentenceAlgorithms` class
| Method | Packages |
|--------|----------|
| `HeadOfSpan()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/) |
| `KeyphraseSpans()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/) |
| `Keyphrases()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/) |
| `DependencyPathBetween()` | [![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.PosTagger?label=SimpleNetNlp.Models.PosTagger)](https://www.nuget.org/packages/SimpleNetNlp.Models.PosTagger/)<br>[![Nuget](https://img.shields.io/nuget/v/SimpleNetNlp.Models.Parser?label=SimpleNetNlp.Models.Parser)](https://www.nuget.org/packages/SimpleNetNlp.Models.Parser/) |