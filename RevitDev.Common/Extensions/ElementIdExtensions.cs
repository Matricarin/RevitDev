using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class ElementIdExtensions
{
    [Pure]
    public static bool AreEquals(this ElementId elementId, BuiltInCategory category)
    {
        return elementId.IntegerValue == (int)category;
    }

    [Pure]
    public static bool AreEquals(this ElementId elementId, BuiltInParameter parameter)
    {
        return elementId.IntegerValue == (int)parameter;
    }

    [Pure]
    public static int GetIdValue(this ElementId elementId)
    {
        return elementId.IntegerValue;
    }

    [Pure]
    public static Element? ToElement(this ElementId id, Document document)
    {
        return document.GetElement(id);
    }

    [Pure]
    public static T? ToElement<T>(this ElementId id, Document document) where T : Element
    {
        return (T?)document.GetElement(id);
    }

    [Pure]
    public static IList<Element> ToElements(this ICollection<ElementId> elementIds, Document document)
    {
        if (elementIds.Count == 0)
        {
            return [];
        }

        var elementTypes = new FilteredElementCollector(document, elementIds).WhereElementIsElementType();
        var elementInstances = new FilteredElementCollector(document, elementIds).WhereElementIsNotElementType();
        return elementTypes.UnionWith(elementInstances).ToElements();
    }

    [Pure]
    public static IList<T> ToElements<T>(this ICollection<ElementId> elementIds, Document document) where T : Element
    {
        if (elementIds.Count == 0)
        {
            return [];
        }

        var elementTypes = new FilteredElementCollector(document, elementIds).WhereElementIsElementType();
        var elementInstances = new FilteredElementCollector(document, elementIds).WhereElementIsNotElementType();
        return elementTypes.UnionWith(elementInstances).Cast<T>().ToList();
    }

    [Pure]
    public static IList<Element> ToOrderedElements(this ICollection<ElementId> elementIds, Document document)
    {
        if (elementIds.Count == 0)
        {
            return [];
        }

        var elements = elementIds.ToElements(document);
        var elementDictionary = elements.ToDictionary(element => element.Id);

        var orderedElements = new List<Element>(elementIds.Count);
        foreach (var id in elementIds)
        {
            orderedElements.Add(elementDictionary[id]);
        }

        return orderedElements;
    }

    [Pure]
    public static IList<T> ToOrderedElements<T>(this ICollection<ElementId> elementIds, Document document)
        where T : Element
    {
        if (elementIds.Count == 0)
        {
            return [];
        }

        var elements = elementIds.ToElements<T>(document);
        var elementDictionary = elements.ToDictionary(element => element.Id);

        var orderedElements = new List<T>(elementIds.Count);
        foreach (var id in elementIds)
        {
            orderedElements.Add(elementDictionary[id]);
        }

        return orderedElements;
    }
}