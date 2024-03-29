﻿namespace SimpleNetNlp.Extensions;

internal static class CSharpToJavaExtensions
{
    internal static java.util.List ToJavaList<T>(this IEnumerable<T> enumerable) =>
        enumerable.Aggregate(
            new java.util.ArrayList(),
            (list, item) =>
            {
                list.add(item);
                return list;
            });

    internal static java.util.function.Function ToJavaSelector<T>(this Func<Sentence, IEnumerable<T>> func) => new FuncWrapper<edu.stanford.nlp.simple.Sentence, java.util.List>(s => func((Sentence)s).ToJavaList());

    internal static java.util.function.Function ToJavaSelector<T>(this Action<Sentence> action) => new FuncWrapper<edu.stanford.nlp.simple.Sentence, T>(s =>
    {
        action((Sentence)s);
        return default;
    });

    internal static edu.stanford.nlp.ie.machinereading.structure.Span ToJavaSpan(this Range range, int length) => new(
        range.Start.GetOffset(length),
        range.End.GetOffset(length));

    internal static java.util.Optional NullableToOptional(this object obj) => java.util.Optional.ofNullable(obj);

    internal static edu.stanford.nlp.util.IntPair ToIntPair(this (int, int) tuple) => new edu.stanford.nlp.util.IntPair(tuple.Item1, tuple.Item2);

    private class FuncWrapper<T, TReturn> : java.util.function.Function
    {
        private readonly Func<T, TReturn> _func;

        public FuncWrapper(Func<T, TReturn> func)
        {
            _func = func;
        }

        public java.util.function.Function andThen(java.util.function.Function after)
        {
            return java.util.function.Function.__DefaultMethods.andThen(this, after);
        }

        public object apply(object t)
        {
            return _func((T)t);
        }

        public java.util.function.Function compose(java.util.function.Function before)
        {
            return java.util.function.Function.__DefaultMethods.compose(this, before);
        }
    }
}