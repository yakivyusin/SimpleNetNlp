using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNetNlp.Extensions
{
    /// <summary>
    /// Contains extension methods for java.util.Collection
    /// </summary>
    internal static class JavaCollectionExtensions
    {
        /// <summary>
        /// Convert java.util.Collection that contains elements of type <typeparamref name="TSource"/>
        /// to System.Collections.Generic.List of arbitary type <typeparamref name="TTarget"/> based on <paramref name="convertingFunction"/>
        /// </summary>
        /// <typeparam name="TSource">The source type of the Java collection elements.</typeparam>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="collection">Collection to convertion.</param>
        /// <param name="convertingFunction">Function for converting <typeparamref name="TSource"/> element to <typeparamref name="TTarget"/></param>
        /// <returns>A converted list.</returns>
        internal static List<TTarget> ToList<TSource, TTarget>(this java.util.Collection collection, Func<TSource, TTarget> convertingFunction)
        {
            if (collection == null) throw new NullReferenceException();

            return Enumerate(collection, convertingFunction).ToList();
        }

        private static IEnumerable<TTarget> Enumerate<TSource, TTarget>(java.util.Collection collection, Func<TSource, TTarget> convertingFunction)
        {
            var iterator = collection.iterator();
            while (iterator.hasNext())
            {
                yield return convertingFunction((TSource)iterator.next());
            }
        }
    }
}
