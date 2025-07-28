using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class DrawUtils
{
    [Pure]
    public static DirectShape Visualize(this XYZ source, Document document)
    {
        var point = Point.Create(source);
        return document.CreateDirectShape(point);
    }

    [Pure]
    public static DirectShape Visualize(this IEnumerable<XYZ> source, Document document)
    {
        var coordinates = source as XYZ[] ?? source.ToArray();
        var points = coordinates.Select(x => Point.Create(x)).ToArray();
        return document.CreateDirectShape(points);
    }

    [Pure]
    public static DirectShape Visualize(this Curve source, Document document)
    {
        return document.CreateDirectShape(new List<GeometryObject> { source });
    }

    [Pure]
    public static DirectShape VisualizeAsPolygon(this IEnumerable<XYZ> loop, Document document)
    {
        var coordinates = loop as XYZ[] ?? loop.ToArray();
        var firstPoint = XYZ.Zero;
        var tempOrigin = XYZ.Zero;
        var isFirst = true;
        foreach (var coordinate in coordinates)
        {
            if (isFirst)
            {
                firstPoint = coordinate;
                isFirst = false;
            }
            else
            {
                var edge = coordinate.GetLineTo(tempOrigin);
                var ds = edge.Visualize(document);
            }

            tempOrigin = coordinate;
        }

        var lastEdge = tempOrigin.GetLineTo(firstPoint);
        return lastEdge.Visualize(document);
    }
}