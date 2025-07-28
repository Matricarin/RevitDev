using System;
using System.Diagnostics.Contracts;
using RevitDev.Common.Constants;

namespace RevitDev.Common.Extensions;

public static class DoubleExtensions
{
    [Pure]
    public static double ConvertDegreesToRadians(this double degrees)
    {
        return degrees / CommonConst.DegreesInRadian;
    }

    [Pure]
    public static double ConvertRadiansToDegrees(this double radians)
    {
        return radians * CommonConst.DegreesInRadian;
    }

    [Pure]
    public static bool IsEqualOrGreater(this double value, double otherValue, double precision = CommonConst.Tolerance)
    {
        return value.IsEqualTo(otherValue, precision) || value > otherValue;
    }

    [Pure]
    public static bool IsEqualOrLess(this double value, double otherValue, double precision = CommonConst.Tolerance)
    {
        return value.IsEqualTo(otherValue, precision) || value < otherValue;
    }

    [Pure]
    public static bool IsEqualTo(this double value, double otherValue, double precision = CommonConst.Tolerance)
    {
        return Math.Abs(value - otherValue) < precision;
    }

    [Pure]
    public static bool IsZero(this double value, double precision = CommonConst.Tolerance)
    {
        return value.IsEqualTo(0D, precision);
    }

    [Pure]
    public static double Round(this double value, int digits = CommonConst.RoundDefaultDigits)
    {
        return Math.Round(value, digits, MidpointRounding.AwayFromZero);
    }
}