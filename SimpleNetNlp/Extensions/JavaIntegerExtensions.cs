using System;

namespace SimpleNetNlp.Extensions
{
    /// <summary>
    /// Contains extension methods for java.lang.Integer
    /// </summary>
    internal static class JavaIntegerExtensions
    {
        /// <summary>
        /// Convert java.lang.Integer to plain C# int.
        /// </summary>
        /// <param name="integer">Integer to convertion.</param>
        /// <returns>A converted value.</returns>
        internal static int ToInt(this java.lang.Integer integer)
        {
            if (integer == null) throw new NullReferenceException();

            return int.Parse(integer.toString());
        }
    }
}
