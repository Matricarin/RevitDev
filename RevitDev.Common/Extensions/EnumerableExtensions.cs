using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class EnumerableExtensions
{
    [Pure]
    public static Transform? ConvertToTransform(this IEnumerable<XYZ> points)
    {
        var enumerable = points as XYZ[] ?? points.ToArray();
        Transform transform = null;

        for (var i = 1; i < enumerable.Length; i++)
        {
            var x = (enumerable[i] - enumerable[i - 1]).ReturnOrThrowIfNull();
            var y = (enumerable[i] - enumerable[i + 1]).ReturnOrThrowIfNull();
            var z = x.CrossProduct(y).ReturnOrThrowIfNull();

            if (x.AngleTo(y) == 0.0)
            {
                continue;
            }

            transform = Transform.Identity;
            transform.Origin = enumerable[i];
            transform.BasisX = x;
            transform.BasisY = y;
            transform.BasisZ = z;
        }

        return transform;
    }

    [Pure]
    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T>? source)
    {
        if (source == null)
        {
            throw new ArgumentNullException();
        }

        var buffer = default(T);
        var buffered = false;

        foreach (var item in source)
        {
            if (buffered)
            {
                if (buffer != null)
                {
                    yield return buffer;
                }
            }

            buffer = item;
            buffered = true;
        }
    }
}