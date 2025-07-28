using System;
using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;
using RevitDev.Common.Constants;

namespace RevitDev.Common.Extensions;

public static class LineExtensions
{
    [Pure]
    public static XYZ GetCenterPoint(this Line line)
    {
        return line.Evaluate(0.5, true);
    }

    [Pure]
    public static XYZ[] GetEndpoints(this Line line)
    {
        return new[]
        {
            line.GetEndPoint(0),
            line.GetEndPoint(1)
        };
    }

    [Pure]
    public static bool IsCollinear(this Line a, Line b)
    {
        var v = a.Direction;
        var w = b.Origin - a.Origin;
        return v.IsCollinear(b.Direction) && v.IsCollinear(w);
    }

    [Pure]
    public static bool IsLieOnSameStraightLine(this Line firstLine, Line secondLine,
        double tolerance = CommonConst.Tolerance)
    {
        // Если два отрезка не параллельны, то и дальнейшая проверка не требуется
        if (!firstLine.IsParallelTo(secondLine))
        {
            return false;
        }

        var firstLinePoints = firstLine.GetEndpoints();
        var secondLinePoints = secondLine.GetEndpoints();

        // Вектор первого отрезка будем использовать как эталон проверки.
        // Свойство Direction всегда содержит единичный вектор
        var fv = firstLine.Direction;

        // Нам требуется проверять попарно концевые точки первого отрезка с концевыми точками второго.
        // Это удобно сделать двумя итерациями
        foreach (var firstLinePoint in firstLinePoints)
        {
            foreach (var secondLinePoint in secondLinePoints)
            {
                // Если два отрезка будут будут иметь общую концевую точку, то проверка сработает не верно,
                // так как произведение векторов даст 0.0. Такие пары просто пропускаем
                if (Math.Abs(firstLinePoint.DistanceTo(secondLinePoint)) < tolerance)
                {
                    continue;
                }

                // Не важно из какой какую точку отнимать. Главное, привести к единичному вектору
                var v = (secondLinePoint - firstLinePoint).Normalize();

                // Если вектора не параллельны, то и отрезки не лежат на одной прямой
                if (!fv.IsParallelTo(v))
                {
                    return false;
                }
            }
        }

        // Если в предыдущих итерациях мы не вышли из метода, значит два отрезка лежат на одной прямой
        return true;
    }

    [Pure]
    public static bool IsParallelTo(this Line line, Line otherLine, double tolerance = CommonConst.Tolerance)
    {
        return Math.Abs(Math.Abs(line.Direction.DotProduct(otherLine.Direction)) - 1) < tolerance;
    }

    [Pure]
    public static bool IsParallelTo(this Line line, XYZ vector, double tolerance = CommonConst.Tolerance)
    {
        return Math.Abs(Math.Abs(line.Direction.DotProduct(vector.Normalize())) - 1) < tolerance;
    }

    [Pure]
    public static Line ProjectOnto(this Line line, Plane plane)
    {
        return Line.CreateBound(
            line.GetEndPoint(0).ProjectOnTo(plane),
            line.GetEndPoint(1).ProjectOnTo(plane));
    }
}