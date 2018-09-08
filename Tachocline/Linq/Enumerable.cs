using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Tachocline.Linq
{
    public static class Enumerable
    {
        public static IEnumerable<TSource> Where<TSource, TException>(IEnumerable<TSource> sequence, Predicate<TSource> predicate, Action<TException, TSource> exceptionHandler) where TException : Exception
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
            Contract.EndContractBlock();

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
