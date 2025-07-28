using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

/// <summary>
///     Represent extension methods for the <see cref="Autodesk.Revit.DB.UnitUtils" /> class.
/// </summary>
public static class UnitUtilsExtensions
{
    [Pure]
    public static double FromDegrees(this double degrees)
    {
#if R2022
        return UnitUtils.ConvertToInternalUnits(degrees, UnitTypeId.Degrees);
#else
        return UnitUtils.ConvertToInternalUnits(degrees, DisplayUnitType.DUT_DECIMAL_DEGREES);
#endif
    }

    [Pure]
    public static double FromInches(this double inches)
    {
#if R2022
        return UnitUtils.ConvertToInternalUnits(inches, UnitTypeId.Inches);
#else
        return UnitUtils.ConvertToInternalUnits(inches, DisplayUnitType.DUT_DECIMAL_INCHES);
#endif
    }

    [Pure]
    public static double FromMeters(this double meters)
    {
#if R2022
        return UnitUtils.ConvertToInternalUnits(meters, UnitTypeId.Meters);
#else
        return UnitUtils.ConvertToInternalUnits(meters, DisplayUnitType.DUT_METERS);
#endif
    }

    [Pure]
    public static double FromMillimeters(this double millimeters)
    {
#if R2022
        return UnitUtils.ConvertToInternalUnits(millimeters, UnitTypeId.Millimeters);
#else
        return UnitUtils.ConvertToInternalUnits(millimeters, DisplayUnitType.DUT_MILLIMETERS);
#endif
    }

    [Pure]
#if R2022
    public static double FromUnit(this double value, ForgeTypeId unitId)
    {
        return UnitUtils.ConvertToInternalUnits(value, unitId);
    }
#else
    public static double FromUnit(this double value, DisplayUnitType unitId)
    {
        return UnitUtils.ConvertToInternalUnits(value, unitId);
    }
#endif

    [Pure]
    public static double ToDegrees(this double radians)
    {
#if R2022
        return UnitUtils.ConvertFromInternalUnits(radians, UnitTypeId.Degrees);
#else
        return UnitUtils.ConvertFromInternalUnits(radians, DisplayUnitType.DUT_DECIMAL_DEGREES);
#endif
    }

    [Pure]
    public static double ToInches(this double feet)
    {
#if R2022
        return UnitUtils.ConvertFromInternalUnits(feet, UnitTypeId.Inches);
#else
        return UnitUtils.ConvertFromInternalUnits(feet, DisplayUnitType.DUT_DECIMAL_INCHES);
#endif
    }

    [Pure]
    public static double ToMeters(this double feet)
    {
#if R2022
        return UnitUtils.ConvertFromInternalUnits(feet, UnitTypeId.Meters);
#else
        return UnitUtils.ConvertFromInternalUnits(feet, DisplayUnitType.DUT_METERS);
#endif
    }

    [Pure]
    public static double ToMillimeters(this double feet)
    {
#if R2022
        return UnitUtils.ConvertFromInternalUnits(feet, UnitTypeId.Millimeters);
#else
        return UnitUtils.ConvertFromInternalUnits(feet, DisplayUnitType.DUT_MILLIMETERS);
#endif
    }

    [Pure]
#if R2022
    public static double ToUnit(this double value, ForgeTypeId unitId)
    {
        return UnitUtils.ConvertFromInternalUnits(value, unitId);
    }
#else
    public static double ToUnit(this double value, DisplayUnitType unitId)
    {
        return UnitUtils.ConvertFromInternalUnits(value, unitId);
    }
#endif
}