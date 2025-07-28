using System;
using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class ElementExtensions
{
    [Pure]
    public static Parameter? FindParameter(this Element element, BuiltInParameter parameter)
    {
        var instanceParameter = element.get_Parameter(parameter);
        if (instanceParameter is not null)
        {
            return instanceParameter;
        }

        var elementTypeId = element.GetTypeId();
        if (elementTypeId == ElementId.InvalidElementId)
        {
            return null;
        }

        var elementType = element.Document.GetElement(elementTypeId);
        return elementType.get_Parameter(parameter);
    }

    [Pure]
    public static Parameter? FindParameter(this Element element, Definition definition)
    {
        var instanceParameter = element.get_Parameter(definition);
        if (instanceParameter is not null)
        {
            return instanceParameter;
        }

        var elementTypeId = element.GetTypeId();
        if (elementTypeId == ElementId.InvalidElementId)
        {
            return null;
        }

        var elementType = element.Document.GetElement(elementTypeId);
        return elementType.get_Parameter(definition);
    }

    [Pure]
    public static Parameter? FindParameter(this Element element, Guid guid)
    {
        var instanceParameter = element.get_Parameter(guid);
        if (instanceParameter is not null)
        {
            return instanceParameter;
        }

        var elementTypeId = element.GetTypeId();
        if (elementTypeId == ElementId.InvalidElementId)
        {
            return null;
        }

        var elementType = element.Document.GetElement(elementTypeId);
        return elementType.get_Parameter(guid);
    }

    [Pure]
    public static Parameter? FindParameter(this Element element, string parameter)
    {
        var instanceParameter = element.LookupParameter(parameter);
        if (instanceParameter is not null)
        {
            return instanceParameter;
        }

        var elementTypeId = element.GetTypeId();
        if (elementTypeId == ElementId.InvalidElementId)
        {
            return null;
        }

        var elementType = element.Document.GetElement(elementTypeId);
        return elementType.LookupParameter(parameter);
    }

    [Pure]
    public static BuiltInCategory? GetBuiltInCategory(this Element element)
    {
        var category = element.Category;

        if (category != null)
        {
            var id = category.Id.IntegerValue;
            if (Enum.IsDefined(typeof(BuiltInCategory), id))
            {
                return (BuiltInCategory)id;
            }
        }

        return null;
    }
}