using System;
using System.Collections.Generic;

//using System.Linq;

namespace Kottans.LINQ
{
    public static class Enumerable
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            foreach (var item in source)
            {
                if (!predicate.Invoke(item)) return false;
            }
            return true;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
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

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
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
            var index = 0;
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

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            return WhereYieldResult(source, predicate);
        }

        private static IEnumerable<TSource> WhereYieldResult<TSource>(IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element)) yield return element;
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            return WhereYieldResult(source, predicate);
        }

        private static IEnumerable<TSource> WhereYieldResult<TSource>(IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;
            foreach (var element in source)
            {
                if (predicate(element, index)) yield return element;
                index ++;
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            using (var enumerator = source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current)) return enumerator.Current;
                }
                return enumerator.Current;
            }
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext()) return enumerator.Current;
            }
            return default(TSource);
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (predicate(element)) return element;
            }
            return default(TSource);
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            var result = default(TSource);
            var list = source as IList<TSource>;
            if (list != null)
            {
                var count = list.Count;
                if (count > 0) result = list[count - 1];
            }
            else
            {
                using (var enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext()) throw new InvalidOperationException();
                    while (enumerator.MoveNext())
                    {
                    }
                    result = enumerator.Current;
                }
            }
            return result;
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            var existsMatching = false;
            var result = default(TSource);
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    result = element;
                    existsMatching = true;
                }
            }
            if (!existsMatching) throw new InvalidOperationException();
            return result;
        }


        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            var list = source as IList<TSource>;
            if (list != null)
            {
                var count = list.Count;
                if (count > 0) return list[count - 1];
            }
            else
            {
                using (var enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        while (enumerator.MoveNext())
                        {
                        }
                        return enumerator.Current;
                    }
                }
            }
            return default(TSource);
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            var existsMatching = false;
            var result = default(TSource);
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    result = element;
                    existsMatching = true;
                }
            }
            if (existsMatching) return result;
            return default(TSource);
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext()) return true;
            }
            return false;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (predicate(element)) return true;
            }
            return false;
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            return source.Distinct(EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            if (source == null) throw new ArgumentNullException();
            if (comparer == null) return DistinctYieldResult(source, EqualityComparer<TSource>.Default);
            return DistinctYieldResult(source, comparer);
        }

        private static IEnumerable<TSource> DistinctYieldResult<TSource>(IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            var returned = new HashSet<TSource>(comparer);
            foreach (var element in source)
            {
                if (!returned.Contains(element))
                {
                    returned.Add(element);
                    yield return element;
                }
            }
        }

        public static IEnumerable<T> Empty<T>()
        {
            return EmptyEnumerable<T>.Instance;
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

        public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return Sum(source.Select(selector));
        }


        public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
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

        public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return Sum(source.Select(selector));
        }


        public static long? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
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

        public static decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return Sum(source.Select(selector));
        }


        public static decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
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

        public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return Sum(source.Select(selector));
        }


        public static float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
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

        public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return Sum(source.Select(selector));
        }


        public static double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return Sum(source.Select(selector));
        }

        public static IEnumerable<T> Repeat<T>(T toRepeat, int times)
        {
            if (times < 0) throw new ArgumentOutOfRangeException();
            return RepeatYieldResult(toRepeat, times);
        }

        private static IEnumerable<T> RepeatYieldResult<T>(T toRepeat, int times)
        {
            for (var i = 0; i < times; i++)
            {
                yield return toRepeat;
            }
        }

        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            return ReverseYiedResult(source);
        }

        private static IEnumerable<TSource> ReverseYiedResult<TSource>(IEnumerable<TSource> source)
        {
            var count = source.Count();
            var array = new TSource[count];
            var index = count - 1;
            foreach (var element in source)
            {
                array[index] = element;
                index--;
            }
            for (var i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return SelectManyYieldResult(source, selector);
        }

        private static IEnumerable<TResult> SelectManyYieldResult<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var element in source)
            {
                foreach (var subElement in selector(element))
                {
                    yield return subElement;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return SelectManyYieldResult(source, selector);
        }

        private static IEnumerable<TResult> SelectManyYieldResult<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TResult>> selector)
        {
            var index = 0;
            foreach (var element in source)
            {
                foreach (var subElement in selector(element, index))
                {
                    yield return subElement;
                }
                index++;
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult, TCollection>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> selector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return SelectManyYieldResult(source, selector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyYieldResult<TSource, TResult, TCollection>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> selector, Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (var element in source)
            {
                foreach (var subElement in selector(element))
                {
                    yield return resultSelector(element, subElement);
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult, TCollection>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> selector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException();
            if (selector == null) throw new ArgumentNullException();
            return SelectManyYieldResult(source, selector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyYieldResult<TSource, TResult, TCollection>(
            this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> selector, Func<TSource, TCollection, TResult> resultSelector)
        {
            var index = 0;
            foreach (var element in source)
            {
                foreach (var subElement in selector(element, index))
                {
                    yield return resultSelector(element, subElement);
                }
                index++;
            }
        }

        public static bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return SequenceEqual(first, second, EqualityComparer<T>.Default);
        }

        public static bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second,
            IEqualityComparer<T> comparer)
        {
            if (first == null) throw new ArgumentNullException();
            if (second == null) throw new ArgumentNullException();
            if (comparer == null) comparer = EqualityComparer<T>.Default;
            using (var enumeratorFirst = first.GetEnumerator())
            {
                using (var enumeratorSecond = second.GetEnumerator())
                {
                    var moveFirst = enumeratorFirst.MoveNext();
                    var moveSecond = enumeratorSecond.MoveNext();
                    while (moveFirst && moveSecond)
                    {
                        if (!comparer.Equals(enumeratorFirst.Current, enumeratorSecond.Current)) return false;
                        moveFirst = enumeratorFirst.MoveNext();
                        moveSecond = enumeratorSecond.MoveNext();
                    }
                    if (moveFirst || moveSecond) return false;
                }
            }
            return true;
        }

        private static class EmptyEnumerable<T>
        {
            public static readonly T[] Instance = new T[0];
        }
    }
}