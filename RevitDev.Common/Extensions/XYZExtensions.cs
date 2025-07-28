using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Autodesk.Revit.DB;
using RevitDev.Common.Constants;

namespace RevitDev.Common.Extensions;

public static class XyzExtensions
{
    [Pure]
    public static bool AreCollinear(this XYZ p, XYZ q, XYZ r)
    {
        var v = q - p;
        var w = r - p;
        return v.IsCollinear(w);
    }

    [Pure]
    public static XYZ GetCenter(this XYZ source, XYZ point)
    {
        return (source + point) * 0.5;
    }

    [Pure]
    public static double GetDistanceTo(this XYZ source, Plane plane)
    {
        var point = source.ProjectOnTo(plane).ReturnOrThrowIfNull();
        return point.DistanceTo(source);
    }

    [Pure]
    public static Curve GetLineTo(this XYZ source, XYZ origin)
    {
        return Line.CreateBound(origin, source);
    }

    [Pure]
    public static XYZ GetPointAlongVector(this XYZ source, XYZ direction, double distance)
    {
        return source.Add(direction * distance);
    }

    [Pure]
    public static XYZ GetPointAlongVector(this XYZ source, XYZ direction)
    {
        return source.Add(direction);
    }

    [Pure]
    public static bool HasSameDirectionSign(this XYZ source, XYZ point)
    {
        if (source.IsZeroLength() || point.IsZeroLength())
        {
            return false;
        }

        return source.DotProduct(point) > 0;
    }

    [Pure]
    public static bool IsCollinear(this XYZ source, XYZ point)
    {
        return source.CrossProduct(point).IsZeroLength();
    }


    [Pure]
    public static bool IsInsideLoop(this XYZ? target, IEnumerable<XYZ>? loop)
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        if (loop == null)
        {
            throw new ArgumentNullException(nameof(loop));
        }

        var loopPoints = loop as XYZ[] ?? loop.ToArray();

        if (loopPoints.Length < 3)
        {
            return false;
        }

        if (loopPoints.ConvertToTransform() == null)
        {
            return false;
        }

        var polygonCs = loopPoints.ConvertToTransform().ReturnOrThrowIfNull();

        List<XYZ> projectedPolygon;

        XYZ projectedTestPoint;

        if (Math.Abs(polygonCs.BasisZ.Z) > Math.Abs(polygonCs.BasisZ.X) &&
            Math.Abs(polygonCs.BasisZ.Z) > Math.Abs(polygonCs.BasisZ.Y))
        {
            var xyPlane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, XYZ.Zero).ReturnOrThrowIfNull();
            projectedPolygon = loopPoints.Select(p => p.ProjectOnTo(xyPlane)).ToList();
            projectedTestPoint = target.ProjectOnTo(xyPlane);
        }
        else if (Math.Abs(polygonCs.BasisZ.X) > Math.Abs(polygonCs.BasisZ.Y))
        {
            var yzPlane = Plane.CreateByNormalAndOrigin(XYZ.BasisX, XYZ.Zero);
            projectedPolygon = loopPoints.Select(p => p.ProjectOnTo(yzPlane)).ToList();
            projectedTestPoint = target.ProjectOnTo(yzPlane);
        }
        else
        {
            var xzPlane = Plane.CreateByNormalAndOrigin(XYZ.BasisX, XYZ.Zero);
            projectedPolygon = loopPoints.Select(p => p.ProjectOnTo(xzPlane)).ToList();
            projectedTestPoint = target.ProjectOnTo(xzPlane);
        }

        return projectedTestPoint.IsInsideLoop2D(projectedPolygon);
    }

    public static bool IsParallelTo(this XYZ vector, XYZ checkedVector, double tolerance = CommonConst.Tolerance)
    {
        return Math.Abs(Math.Abs(vector.DotProduct(checkedVector)) - 1.0) < tolerance;
    }

    [Pure]
    public static bool IsPerpendicular(this XYZ vector1, XYZ vector2)
    {
        var a = vector1.GetLength();
        var b = vector2.GetLength();
        var c = Math.Abs(vector1.DotProduct(vector2));
        return a > CommonConst.Tolerance
               && b > CommonConst.Tolerance
               && c * c < CommonConst.Tolerance * CommonConst.Tolerance * a * a * b * b;
    }

    [Pure]
    public static bool IsVertical(this XYZ vector)
    {
        return vector.X.IsZero() && vector.Y.IsZero();
    }

    [Pure]
    public static bool IsVertical(this XYZ vector, double tolerance)
    {
        return vector.X.IsZero(tolerance) && vector.Y.IsZero(tolerance);
    }

    [Pure]
    public static XYZ ProjectOnTo(this XYZ source, Plane plane)
    {
        var normal = plane.Normal.Normalize();
        var num = -normal.DotProduct(source - plane.Origin) / normal.DotProduct(normal);
        return source + normal * num;
    }

    private static bool IsInsideLoop2D(this XYZ target, List<XYZ> loop)
    {
        var pointIsInside = false;

        var loopPoints = loop.Select(p => new XYZ(p.X, p.Y, 0.0)).ToArray();

        var currentPoint = new XYZ(target.X, target.Y, 0.0);
        var x = currentPoint.X;
        var y = currentPoint.Y;

        for (int i = 0, j = loopPoints.Length - 1; i < loopPoints.Length; j = i++)
        {
            var xi = loopPoints[i].X;
            var yi = loopPoints[i].Y;
            var xj = loopPoints[j].X;
            var yj = loopPoints[j].Y;

            var fc = yi > y != yj > y;
            var det = (xj - xi) * (y - yi) / (yj - yi) + xi;
            var sc = x <= det;

            if (fc && sc)
            {
                pointIsInside = !pointIsInside;
            }
        }

        return pointIsInside;
    }
}