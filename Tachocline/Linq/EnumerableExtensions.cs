using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Tachocline.Linq
{
    public static class EnumerableExtensions
    {
        public static void ForEach(this IEnumerable sequence, Action<object> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }
        
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }

        public static IEnumerable<TSource> Where<TSource, TException>(this IEnumerable<TSource> sequence, Predicate<TSource> predicate, Action<TException, TSource> exceptionHandler) where TException : Exception
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            if (exceptionHandler == null)
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
