using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace RevitDev.Common.Extensions;

public static class EnumeratorExtensions
{
    [Pure]
    public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator<T>? enumerator)
    {
        if (enumerator == null)
        {
            throw new ArgumentNullException();
        }

        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;

            if (item != null)
            {
                yield return item;
            }
            else
            {
                yield break;
            }
        }
    }
}