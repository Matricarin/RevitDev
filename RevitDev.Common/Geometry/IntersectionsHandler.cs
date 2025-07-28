using System;
using RevitDev.Common.Constants;

namespace RevitDev.Common.Geometry;

public static class IntersectionsHandler
{
    /// <summary>
    ///     Returns true if the closed line segments [ (x1,y1)->(x2,y2) ] and [ (x3,y3)->(x4,y4) ] intersect.
    /// </summary>
    public static bool Intersect(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        var ax = x2 - x1;
        var bx = x3 - x4;

        double lowerX;
        double upperX;
        double upperY;
        double lowerY;

        if (Math.Abs(ax) < CommonConst.Tolerance)
        {
            lowerX = x2;
            upperX = x1;
        }
        else
        {
            upperX = x2;
            lowerX = x1;
        }

        if (Math.Abs(bx) > CommonConst.Tolerance)
        {
            if (upperX < x4 || x3 < lowerX)
            {
                return false;
            }
        }
        else if (upperX < x3 || x4 < lowerX)
        {
            return false;
        }

        var ay = y2 - y1;
        var by = y3 - y4;

        if (Math.Abs(ay) < CommonConst.Tolerance)
        {
            lowerY = y2;
            upperY = y1;
        }
        else
        {
            upperY = y2;
            lowerY = y1;
        }

        if (Math.Abs(by) > CommonConst.Tolerance)
        {
            if (upperY < y4 || y3 < lowerY)
            {
                return false;
            }
        }
        else if (upperY < y3 || y4 < lowerY)
        {
            return false;
        }

        var cx = x1 - x3;
        var cy = y1 - y3;
        var d = by * cx - bx * cy;
        var f = ay * bx - ax * by;

        if (Math.Abs(f) > CommonConst.Tolerance)
        {
            if (Math.Abs(d) < CommonConst.Tolerance || d > f)
            {
                return false;
            }
        }
        else if (Math.Abs(d) > CommonConst.Tolerance || d < f)
        {
            return false;
        }

        var e = ax * cy - ay * cx;

        if (f > CommonConst.Tolerance)
        {
            if (Math.Abs(e) < CommonConst.Tolerance || e > f)
            {
                return false;
            }
        }
        else if (Math.Abs(e) > CommonConst.Tolerance || e < f)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Returns true if the closed line segments intersect;
    ///     if so, outputs the intersection point in (ix,iy).
    /// </summary>
    public static bool Intersect(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4,
        out double ix, out double iy)
    {
        var ax = x2 - x1;
        var bx = x3 - x4;

        double lowerX;
        double upperX;
        double upperY;
        double lowerY;

        if (Math.Abs(ax) < CommonConst.Tolerance)
        {
            lowerX = x2;
            upperX = x1;
        }
        else
        {
            upperX = x2;
            lowerX = x1;
        }

        if (Math.Abs(bx) > CommonConst.Tolerance)
        {
            if (upperX < x4 || x3 < lowerX)
            {
                ix = 0;
                iy = 0;
                return false;
            }
        }
        else if (upperX < x3 || x4 < lowerX)
        {
            ix = 0;
            iy = 0;
            return false;
        }

        var ay = y2 - y1;
        var by = y3 - y4;

        if (Math.Abs(ay) < CommonConst.Tolerance)
        {
            lowerY = y2;
            upperY = y1;
        }
        else
        {
            upperY = y2;
            lowerY = y1;
        }

        if (Math.Abs(by) > CommonConst.Tolerance)
        {
            if (upperY < y4 || y3 < lowerY)
            {
                ix = 0;
                iy = 0;
                return false;
            }
        }
        else if (upperY < y3 || y4 < lowerY)
        {
            ix = 0;
            iy = 0;
            return false;
        }

        var cx = x1 - x3;
        var cy = y1 - y3;
        var d = by * cx - bx * cy;
        var f = ay * bx - ax * by;

        if (Math.Abs(f) > CommonConst.Tolerance)
        {
            if (Math.Abs(d) < CommonConst.Tolerance || d > f)
            {
                ix = 0;
                iy = 0;
                return false;
            }
        }
        else if (Math.Abs(d) > CommonConst.Tolerance || d < f)
        {
            ix = 0;
            iy = 0;
            return false;
        }

        var e = ax * cy - ay * cx;

        if (Math.Abs(f) > CommonConst.Tolerance)
        {
            if (Math.Abs(e) < CommonConst.Tolerance || e > f)
            {
                ix = 0;
                iy = 0;
                return false;
            }
        }
        else if (Math.Abs(e) > CommonConst.Tolerance || e < f)
        {
            ix = 0;
            iy = 0;
            return false;
        }

        var ratio = ax * -by - ay * -bx;

        if (Math.Abs(0.0 - ratio) < CommonConst.Tolerance)
        {
            ratio = (cy * -bx - cx * -by) / ratio;
            ix = x1 + ratio * ax;
            iy = y1 + ratio * ay;
        }
        else
        {
            if ((ax * -cy).Equals(-cx * ay))
            {
                ix = x3;
                iy = y3;
            }
            else
            {
                ix = x4;
                iy = y4;
            }
        }

        return true;
    }
}