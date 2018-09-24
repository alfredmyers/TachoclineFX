using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Tachocline
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string text, int maxLength, Func<char, bool> skip)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (maxLength <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "{nameof(maxLength)} must be greater or equal to one.");
            }
            Contract.EndContractBlock();

            int pos = 0;

            int length;
            do
            {
                var initialLength = Math.Min(text.Length - pos, maxLength);
                for (length = initialLength; initialLength == maxLength && length > 0 && skip(text[pos + length - 1]); length--)
                    ;

                if (length == 0)
                {
                    length = initialLength;
                }

                yield return text.Substring(pos, length);

                pos += length;
            } while (pos < text.Length);
        }
    }
}
