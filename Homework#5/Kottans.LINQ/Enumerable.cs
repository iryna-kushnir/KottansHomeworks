﻿using System;
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
            foreach (var element in source)
            {
                yield return selector.Invoke(element);
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
            return 0;
        }

        public static int Sum<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return 0;
        }


        public static int? Sum<T>(this IEnumerable<T> source, Func<T, int?> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return 0;
        }
    }
}