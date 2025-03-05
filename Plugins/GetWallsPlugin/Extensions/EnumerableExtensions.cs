using System.Collections;
using System.Collections.Generic;

namespace GetWallsPlugin.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator? enumerator)
    {
        if (enumerator.IsNull())
        {
            yield break;
        }

        while (enumerator!.MoveNext())
        {
            if (enumerator.Current is T item)
            {
                yield return item;
            }
        }
    }
}