using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNetNlp.Extensions
{
    /// <summary>
    /// Contains extension methods for java.util.List
    /// </summary>
    internal static class JavaListExtensions
    {
        /// <summary>
        /// Convert java.util.List to System.Collections.Generic.List of arbitrary type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The element type of the list.</typeparam>
        /// <param name="list">List to convertion.</param>
        /// <returns>A converted list.</returns>
        internal static List<T> ToList<T>(this java.util.List list)
        {
            if (list == null) throw new NullReferenceException();

            return Enumerate<T>(list).ToList();
        }

        private static IEnumerable<T> Enumerate<T>(java.util.List list)
        {
            var iterator = list.iterator();
            while (iterator.hasNext())
            {
                yield return (T)(iterator.next());
            }
        }
    }
}
