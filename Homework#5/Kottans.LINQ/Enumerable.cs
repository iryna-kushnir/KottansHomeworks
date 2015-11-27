using System;
using System.Collections.Generic;

//using System.Linq;

namespace Kottans.LINQ
{
    public static class Enumerable
    {
        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            foreach (var item in source)
            {
                if (!predicate.Invoke(item)) return false;
            }
            return true;
        }

        public static int Count<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException();
            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                        count++;
                }
            }
            return count;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                checked
                {
                    while (enumerator.MoveNext())
                        if (predicate.Invoke(enumerator.Current)) count++;
                }
            }
            return count;
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return SelectYieldResult(source, selector);
        }

        private static IEnumerable<TResult> SelectYieldResult<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector.Invoke(element);
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return SelectYieldResult(source, selector);
        }

        private static IEnumerable<TResult> SelectYieldResult<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            int index = 0;
            foreach (var element in source)
            {
                yield return selector.Invoke(element, index);
                index++;
            }
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null) throw new ArgumentNullException();
            if (second == null) throw new ArgumentNullException();
            foreach (var element in first)
            {
                yield return element;
            }
            foreach (var element in second)
            {
                yield return element;
            }
        }

        public static int Sum(this IEnumerable<int> source)
        {
            if (source == null) throw new ArgumentNullException();
            var result = 0;
            foreach (var element in source)
            {
                checked
                {
                    result += element;
                }
            }
            return result;
        }

        public static int? Sum(this IEnumerable<int?> source)
        {
            if (source == null) throw new ArgumentNullException();
            int? result = 0;
            foreach (var element in source)
            {
                checked
                {
                    if (element != null) result += element;
                }
            }
            return result;
        }

        public static int Sum<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            return Sum(source.Select(selector));
        }


        public static int? Sum<T>(this IEnumerable<T> source, Func<T, int?> selector)
        {
            return Sum(source.Select(selector));
        }

        public static long Sum(this IEnumerable<long> source)
        {
            if (source == null) throw new ArgumentNullException();
            long result = 0;
            foreach (var element in source)
            {
                checked
                {
                    result += element;
                }
            }
            return result;
        }

        public static long? Sum(this IEnumerable<long?> source)
        {
            if (source == null) throw new ArgumentNullException();
            long? result = 0;
            foreach (var element in source)
            {
                checked
                {
                    if (element != null) result += element;
                }
            }
            return result;
        }

        public static long Sum<T>(this IEnumerable<T> source, Func<T, long> selector)
        {
            return Sum(source.Select(selector));
        }


        public static long? Sum<T>(this IEnumerable<T> source, Func<T, long?> selector)
        {
            return Sum(source.Select(selector));
        }

        public static decimal Sum(this IEnumerable<decimal> source)
        {
            if (source == null) throw new ArgumentNullException();
            decimal result = 0;
            foreach (var element in source)
            {
                checked
                {
                    result += element;
                }
            }
            return result;
        }

        public static decimal? Sum(this IEnumerable<decimal?> source)
        {
            if (source == null) throw new ArgumentNullException();
            decimal? result = 0;
            foreach (var element in source)
            {
                checked
                {
                    if (element != null) result += element;
                }
            }
            return result;
        }

        public static decimal Sum<T>(this IEnumerable<T> source, Func<T, decimal> selector)
        {
            return Sum(source.Select(selector));
        }


        public static decimal? Sum<T>(this IEnumerable<T> source, Func<T, decimal?> selector)
        {
            return Sum(source.Select(selector));
        }

        public static float Sum(this IEnumerable<float> source)
        {
            if (source == null) throw new ArgumentNullException();
            double result = 0;
            foreach (var element in source)
            {
                checked
                {
                    result += element;
                }
            }
            return (float) result;
        }

        public static float? Sum(this IEnumerable<float?> source)
        {
            if (source == null) throw new ArgumentNullException();
            double? result = 0;
            foreach (var element in source)
            {
                checked
                {
                    if (element != null) result += element;
                }
            }
            return (float?) result;
        }

        public static float Sum<T>(this IEnumerable<T> source, Func<T, float> selector)
        {
            return Sum(source.Select(selector));
        }


        public static float? Sum<T>(this IEnumerable<T> source, Func<T, float?> selector)
        {
            return Sum(source.Select(selector));
        }

        public static double Sum(this IEnumerable<double> source)
        {
            if (source == null) throw new ArgumentNullException();
            double result = 0;
            foreach (var element in source)
            {
                checked
                {
                    result += element;
                }
            }
            return result;
        }

        public static double? Sum(this IEnumerable<double?> source)
        {
            if (source == null) throw new ArgumentNullException();
            double? result = 0;
            foreach (var element in source)
            {
                checked
                {
                    if (element != null) result += element;
                }
            }
            return result;
        }

        public static double Sum<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            return Sum(source.Select(selector));
        }


        public static double? Sum<T>(this IEnumerable<T> source, Func<T, double?> selector)
        {
            return Sum(source.Select(selector));
        }
    }
}