using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public static class UtilityExtensions
    {
        public static IEnumerable<TResult> CustomSelect<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
        {
            return enumerable.Select(item =>
            {
                var result = selector(item);
                Console.WriteLine("Processing item: {0} -> {1}", item, result);
                return result;
            });
        }
    }
}