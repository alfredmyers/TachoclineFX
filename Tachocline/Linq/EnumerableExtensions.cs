using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Tachocline.Linq
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }

        public static TSource TryGetSingle<TSource>(this IEnumerable<TSource> source, out bool found)
        {
            var e = source.GetEnumerator();

            TSource result = default(TSource);
            found = e.MoveNext();

            if (found)
            {
                result = e.Current;
                found = !e.MoveNext();
            }

            return found ? result : default(TSource);
        }

        public static IEnumerable<TSource> Where<TSource, TException>(this IEnumerable<TSource> sequence, Predicate<TSource> predicate, Action<TException, TSource> exceptionHandler) where TException : Exception
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            if (exceptionHandler is null)
            {
                throw new ArgumentNullException(nameof(exceptionHandler));
            }

            foreach (TSource item in sequence)
            {
                bool shouldReturn = false;
                try
                {
                    shouldReturn = predicate(item);
                }
                catch (TException ex)
                {
                    exceptionHandler(ex, item);
                }

                if (shouldReturn)
                {
                    yield return item;
                }
            }
        }
    }
}
