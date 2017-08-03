using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNetNlp.Extensions
{
    internal static class JavaListExtensions
    {
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
