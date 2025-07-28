using System.Diagnostics.Contracts;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class ParameterExtensions
{
    public static void CopyParameterValue(this Parameter? fromParameter, Parameter? toParameter)
    {
        if (fromParameter == null || toParameter == null || toParameter.IsReadOnly)
        {
            return;
        }

        switch (fromParameter.StorageType)
        {
            case StorageType.Double:
                if (toParameter.StorageType == StorageType.Double)
                {
                    toParameter.Set(ConvertFromInternalUnits(fromParameter.AsDouble(), fromParameter));
                }
                else
                {
                    var asValueString = fromParameter.AsValueString() ?? string.Empty;
                    var firstOrDefault = asValueString.Split(' ').FirstOrDefault();
                    toParameter.Set(firstOrDefault);
                }

                break;
            case StorageType.ElementId:
                toParameter.Set(fromParameter.AsElementId());
                break;
            case StorageType.Integer:
#if R2020
                if (fromParameter.Definition.ParameterType == ParameterType.YesNo
                    && toParameter.StorageType == StorageType.String)
                {
                    toParameter.Set(fromParameter.AsValueString());
                }
#else
                if (fromParameter.Definition.GetDataType() == SpecTypeId.Number
                    && toParameter.StorageType == StorageType.String)
                    toParameter.Set(fromParameter.AsValueString());
#endif
                else
                {
                    toParameter.Set(fromParameter.AsInteger());
                }

                break;
            case StorageType.String:
                toParameter.Set(fromParameter.AsString());
                break;
            case StorageType.None:
                toParameter.SetValueString(fromParameter.AsValueString());
                break;
        }
    }

    [Pure]
    private static double ConvertFromInternalUnits(double value, Parameter parameter)
    {
#if R2020
        return UnitUtils.ConvertFromInternalUnits(value, parameter.DisplayUnitType);
#else
        return UnitUtils.ConvertFromInternalUnits(value, parameter.GetUnitTypeId());
#endif
    }

    [Pure]
    private static double ConvertToInternalUnits(double value, Parameter parameter)
    {
#if R2020
        return UnitUtils.ConvertToInternalUnits(value, parameter.DisplayUnitType);
#else
        return UnitUtils.ConvertToInternalUnits(value, parameter.GetUnitTypeId());
#endif
    }
}