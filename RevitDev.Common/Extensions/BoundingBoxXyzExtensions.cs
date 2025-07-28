using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class BoundingBoxXyzExtensions
{
    private const double Tolerance = 1e-9;

    [Pure]
    public static XYZ ComputeCentroid(this BoundingBoxXYZ boundingBox)
    {
        return (boundingBox.Min + boundingBox.Max) / 2;
    }

    [Pure]
    public static XYZ[] ComputeLoopVertices(this BoundingBoxXYZ boundingBox)
    {
        return
        [
            new XYZ(boundingBox.Min.X, boundingBox.Min.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Min.X, boundingBox.Min.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Min.X, boundingBox.Max.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Min.X, boundingBox.Max.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Max.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Max.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Min.Z)
        ];
    }

    [Pure]
    public static double ComputeSurfaceArea(this BoundingBoxXYZ boundingBox)
    {
        var length = boundingBox.Max.X - boundingBox.Min.X;
        var width = boundingBox.Max.Y - boundingBox.Min.Y;
        var height = boundingBox.Max.Z - boundingBox.Min.Z;

        var area1 = length * width;
        var area2 = length * height;
        var area3 = width * height;

        return 2 * (area1 + area2 + area3);
    }

    [Pure]
    public static XYZ[] ComputeVertices(this BoundingBoxXYZ boundingBox)
    {
        return
        [
            new XYZ(boundingBox.Min.X, boundingBox.Min.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Min.X, boundingBox.Min.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Min.X, boundingBox.Max.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Min.X, boundingBox.Max.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Max.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Max.Y, boundingBox.Min.Z),
            new XYZ(boundingBox.Max.X, boundingBox.Max.Y, boundingBox.Max.Z)
        ];
    }

    [Pure]
    public static double ComputeVolume(this BoundingBoxXYZ boundingBox)
    {
        var length = boundingBox.Max.X - boundingBox.Min.X;
        var width = boundingBox.Max.Y - boundingBox.Min.Y;
        var height = boundingBox.Max.Z - boundingBox.Min.Z;

        return length * width * height;
    }

    [Pure]
    public static double GetHeight(this BoundingBoxXYZ boundingBox)
    {
        var minZ = boundingBox.Min.Z;
        var maxZ = boundingBox.Max.Z;
        return maxZ - minZ;
    }

    [Pure]
    public static double GetLength(this BoundingBoxXYZ boundingBox)
    {
        var loop = boundingBox.ComputeLoopVertices();
        var yDistance = loop[2].Y - loop[1].Y;
        var xDistance = loop[5].X - loop[2].X;
        return xDistance > yDistance ? xDistance : yDistance;
    }

    [Pure]
    public static double GetWidth(this BoundingBoxXYZ boundingBox)
    {
        var loop = boundingBox.ComputeLoopVertices();
        var yDistance = loop[2].Y - loop[1].Y;
        var xDistance = loop[5].X - loop[2].X;
        return xDistance < yDistance ? xDistance : yDistance;
    }


    [Pure]
    public static bool IsContain(this BoundingBoxXYZ source, XYZ point)
    {
        return IsContain(source, point, false);
    }

    [Pure]
    public static bool IsContain(this BoundingBoxXYZ source, XYZ point, bool strict)
    {
        if (!source.Transform.IsIdentity)
        {
            point = source.Transform.Inverse.OfPoint(point);
        }

        var insideX = strict
            ? point.X > source.Min.X + Tolerance && point.X < source.Max.X - Tolerance
            : point.X >= source.Min.X - Tolerance && point.X <= source.Max.X + Tolerance;

        var insideY = strict
            ? point.Y > source.Min.Y + Tolerance && point.Y < source.Max.Y - Tolerance
            : point.Y >= source.Min.Y - Tolerance && point.Y <= source.Max.Y + Tolerance;

        var insideZ = strict
            ? point.Z > source.Min.Z + Tolerance && point.Z < source.Max.Z - Tolerance
            : point.Z >= source.Min.Z - Tolerance && point.Z <= source.Max.Z + Tolerance;

        return insideX && insideY && insideZ;
    }

    [Pure]
    public static bool IsContain(this BoundingBoxXYZ source, BoundingBoxXYZ other)
    {
        return IsContain(source, other, false);
    }

    [Pure]
    public static bool IsContain(this BoundingBoxXYZ source, BoundingBoxXYZ other, bool strict)
    {
        var sourceMin = source.Transform.IsIdentity ? source.Min : source.Transform.OfPoint(source.Min);
        var sourceMax = source.Transform.IsIdentity ? source.Max : source.Transform.OfPoint(source.Max);
        var otherMin = other.Transform.IsIdentity ? other.Min : other.Transform.OfPoint(other.Min);
        var otherMax = other.Transform.IsIdentity ? other.Max : other.Transform.OfPoint(other.Max);

        var insideX = strict
            ? otherMin.X > sourceMin.X + Tolerance && otherMax.X < sourceMax.X - Tolerance
            : otherMin.X >= sourceMin.X - Tolerance && otherMax.X <= sourceMax.X + Tolerance;

        var insideY = strict
            ? otherMin.Y > sourceMin.Y + Tolerance && otherMax.Y < sourceMax.Y - Tolerance
            : otherMin.Y >= sourceMin.Y - Tolerance && otherMax.Y <= sourceMax.Y + Tolerance;

        var insideZ = strict
            ? otherMin.Z > sourceMin.Z + Tolerance && otherMax.Z < sourceMax.Z - Tolerance
            : otherMin.Z >= sourceMin.Z - Tolerance && otherMax.Z <= sourceMax.Z + Tolerance;

        return insideX && insideY && insideZ;
    }

    [Pure]
    public static bool IsOverlap(this BoundingBoxXYZ source, BoundingBoxXYZ other)
    {
        var sourceMin = source.Transform.IsIdentity ? source.Min : source.Transform.OfPoint(source.Min);
        var sourceMax = source.Transform.IsIdentity ? source.Max : source.Transform.OfPoint(source.Max);
        var otherMin = other.Transform.IsIdentity ? other.Min : other.Transform.OfPoint(other.Min);
        var otherMax = other.Transform.IsIdentity ? other.Max : other.Transform.OfPoint(other.Max);

        var overlapX = !(sourceMax.X < otherMin.X - Tolerance || sourceMin.X > otherMax.X + Tolerance);
        var overlapY = !(sourceMax.Y < otherMin.Y - Tolerance || sourceMin.Y > otherMax.Y + Tolerance);
        var overlapZ = !(sourceMax.Z < otherMin.Z - Tolerance || sourceMin.Z > otherMax.Z + Tolerance);

        return overlapX && overlapY && overlapZ;
    }
}