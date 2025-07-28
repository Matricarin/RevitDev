using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class FilteredElementCollectorExtensions
{
    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, BuiltInCategory category)
    {
        foreach (var element in CollectInstances(document, category))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        foreach (var element in CollectInstances(document, category, filter))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        foreach (var element in CollectInstances(document, category, filters))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document)
    {
        foreach (var element in CollectInstances(document))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementFilter filter)
    {
        foreach (var element in CollectInstances(document, filter))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document,
        IEnumerable<ElementFilter> filters)
    {
        foreach (var element in CollectInstances(document, filters))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, BuiltInCategory category)
        where T : Element
    {
        var elements = CollectInstances(document, category).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, BuiltInCategory category,
        ElementFilter filter) where T : Element
    {
        var elements = CollectInstances(document, category, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }


    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectInstances(document, category, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document) where T : Element
    {
        var elements = CollectInstances(document).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }


    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementFilter filter)
        where T : Element
    {
        var elements = CollectInstances(document, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectInstances(document, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementId viewId,
        BuiltInCategory category)
    {
        foreach (var element in CollectInstances(document, viewId, category))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementId viewId,
        BuiltInCategory category, ElementFilter filter)
    {
        foreach (var element in CollectInstances(document, viewId, category, filter))
        {
            yield return element.Id;
        }
    }


    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementId viewId,
        BuiltInCategory category, IEnumerable<ElementFilter> filters)
    {
        foreach (var element in CollectInstances(document, viewId, category, filters))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementId viewId)
    {
        foreach (var element in CollectInstances(document, viewId))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementId viewId,
        ElementFilter filter)
    {
        foreach (var element in CollectInstances(document, viewId, filter))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds(this Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters)
    {
        foreach (var element in CollectInstances(document, viewId, filters))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementId viewId,
        BuiltInCategory category) where T : Element
    {
        var elements = CollectInstances(document, viewId, category).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementId viewId,
        BuiltInCategory category, ElementFilter filter) where T : Element
    {
        var elements = CollectInstances(document, viewId, category, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementId viewId,
        BuiltInCategory category, IEnumerable<ElementFilter> filters)
        where T : Element
    {
        var elements = CollectInstances(document, viewId, category, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementId viewId)
        where T : Element
    {
        var elements = CollectInstances(document, viewId).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementId viewId,
        ElementFilter filter) where T : Element
    {
        var elements = CollectInstances(document, viewId, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateInstanceIds<T>(this Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectInstances(document, viewId, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance.Id;
        }
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, BuiltInCategory category)
    {
        return CollectInstances(document, category);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectInstances(document, category, filter);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, category, filters);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document)
    {
        return CollectInstances(document);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementFilter filter)
    {
        return CollectInstances(document, filter);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, filters);
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, BuiltInCategory category)
        where T : Element
    {
        var elements = CollectInstances(document, category).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, BuiltInCategory category,
        ElementFilter filter) where T : Element
    {
        var elements = CollectInstances(document, category, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectInstances(document, category, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, IEnumerable<ElementFilter> filters)
        where T : Element
    {
        var elements = CollectInstances(document, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementId viewId,
        BuiltInCategory category)
    {
        return CollectInstances(document, viewId, category);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementId viewId,
        BuiltInCategory category, ElementFilter filter)
    {
        return CollectInstances(document, viewId, category, filter);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementId viewId,
        BuiltInCategory category, IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, viewId, category, filters);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementId viewId)
    {
        return CollectInstances(document, viewId);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementId viewId,
        ElementFilter filter)
    {
        return CollectInstances(document, viewId, filter);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateInstances(this Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, viewId, filters);
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, ElementId viewId,
        BuiltInCategory category) where T : Element
    {
        var elements = CollectInstances(document, viewId, category).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, ElementId viewId,
        BuiltInCategory category, ElementFilter filter) where T : Element
    {
        var elements = CollectInstances(document, viewId, category, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, ElementId viewId,
        BuiltInCategory category, IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectInstances(document, viewId, category, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, ElementId viewId) where T : Element
    {
        var elements = CollectInstances(document, viewId).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, ElementId viewId, ElementFilter filter)
        where T : Element
    {
        var elements = CollectInstances(document, viewId, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateInstances<T>(this Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectInstances(document, viewId, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var instance = (T)element;
            yield return instance;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds(this Document document, BuiltInCategory category)
    {
        foreach (var element in CollectTypes(document, category))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds(this Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        foreach (var element in CollectTypes(document, category, filter))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        foreach (var element in CollectTypes(document, category, filters))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds(this Document document)
    {
        foreach (var element in CollectTypes(document))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds(this Document document, ElementFilter filter)
    {
        foreach (var element in CollectTypes(document, filter))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds(this Document document, IEnumerable<ElementFilter> filters)
    {
        foreach (var element in CollectTypes(document, filters))
        {
            yield return element.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds<T>(this Document document, BuiltInCategory category)
        where T : Element
    {
        var elements = CollectTypes(document, category).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds<T>(this Document document, BuiltInCategory category,
        ElementFilter filter) where T : Element
    {
        var elements = CollectTypes(document, category, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds<T>(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectTypes(document, category, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds<T>(this Document document) where T : Element
    {
        var elements = CollectTypes(document).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds<T>(this Document document, ElementFilter filter)
        where T : Element
    {
        var elements = CollectTypes(document, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type.Id;
        }
    }

    [Pure]
    public static IEnumerable<ElementId> EnumerateTypeIds<T>(this Document document, IEnumerable<ElementFilter> filters)
        where T : Element
    {
        var elements = CollectTypes(document, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type.Id;
        }
    }

    [Pure]
    public static IEnumerable<Element> EnumerateTypes(this Document document, BuiltInCategory category)
    {
        return CollectTypes(document, category);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateTypes(this Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectTypes(document, category, filter);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateTypes(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectTypes(document, category, filters);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateTypes(this Document document)
    {
        return CollectTypes(document);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateTypes(this Document document, ElementFilter filter)
    {
        return CollectTypes(document, filter);
    }

    [Pure]
    public static IEnumerable<Element> EnumerateTypes(this Document document, IEnumerable<ElementFilter> filters)
    {
        return CollectTypes(document, filters);
    }

    [Pure]
    public static IEnumerable<T> EnumerateTypes<T>(this Document document, BuiltInCategory category) where T : Element
    {
        var elements = CollectTypes(document, category).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateTypes<T>(this Document document, BuiltInCategory category,
        ElementFilter filter) where T : Element
    {
        var elements = CollectTypes(document, category, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateTypes<T>(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters) where T : Element
    {
        var elements = CollectTypes(document, category, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateTypes<T>(this Document document) where T : Element
    {
        var elements = CollectTypes(document).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateTypes<T>(this Document document, ElementFilter filter) where T : Element
    {
        var elements = CollectTypes(document, filter).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type;
        }
    }

    [Pure]
    public static IEnumerable<T> EnumerateTypes<T>(this Document document, IEnumerable<ElementFilter> filters)
        where T : Element
    {
        var elements = CollectTypes(document, filters).OfClass(typeof(T));
        foreach (var element in elements)
        {
            var type = (T)element;
            yield return type;
        }
    }

    [Pure]
    public static FilteredElementCollector GetElements(this Document document)
    {
        return new FilteredElementCollector(document);
    }

    [Pure]
    public static FilteredElementCollector GetElements(this Document document, ElementId viewId)
    {
        return new FilteredElementCollector(document, viewId);
    }

    [Pure]
    public static FilteredElementCollector GetElements(this Document document, ICollection<ElementId> elementIds)
    {
        return new FilteredElementCollector(document, elementIds);
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, BuiltInCategory category)
    {
        return CollectInstances(document, category).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectInstances(document, category, filter).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, category, filters).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document)
    {
        return CollectInstances(document).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementFilter filter)
    {
        return CollectInstances(document, filter).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, filters).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementId viewId,
        BuiltInCategory category)
    {
        return CollectInstances(document, viewId, category).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementId viewId,
        BuiltInCategory category, ElementFilter filter)
    {
        return CollectInstances(document, viewId, category, filter).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementId viewId,
        BuiltInCategory category, IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, viewId, category, filters).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementId viewId)
    {
        return CollectInstances(document, viewId).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementId viewId, ElementFilter filter)
    {
        return CollectInstances(document, viewId, filter).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetInstanceIds(this Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, viewId, filters).ToElementIds();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, BuiltInCategory category)
    {
        return CollectInstances(document, category).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, BuiltInCategory category, ElementFilter filter)
    {
        return CollectInstances(document, category, filter).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, category, filters).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document)
    {
        return CollectInstances(document).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementFilter filter)
    {
        return CollectInstances(document, filter).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, filters).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementId viewId, BuiltInCategory category)
    {
        return CollectInstances(document, viewId, category).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementId viewId, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectInstances(document, viewId, category, filter).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementId viewId, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, viewId, category, filters).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementId viewId)
    {
        return CollectInstances(document, viewId).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementId viewId, ElementFilter filter)
    {
        return CollectInstances(document, viewId, filter).ToElements();
    }

    [Pure]
    public static IList<Element> GetInstances(this Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters)
    {
        return CollectInstances(document, viewId, filters).ToElements();
    }

    [Pure]
    public static ICollection<ElementId> GetTypeIds(this Document document, BuiltInCategory category)
    {
        return CollectTypes(document, category).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetTypeIds(this Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectTypes(document, category, filter).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetTypeIds(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectTypes(document, category, filters).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetTypeIds(this Document document)
    {
        return CollectTypes(document).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetTypeIds(this Document document, ElementFilter filter)
    {
        return CollectTypes(document, filter).ToElementIds();
    }

    [Pure]
    public static ICollection<ElementId> GetTypeIds(this Document document, IEnumerable<ElementFilter> filters)
    {
        return CollectTypes(document, filters).ToElementIds();
    }

    [Pure]
    public static IList<Element> GetTypes(this Document document, BuiltInCategory category)
    {
        return CollectTypes(document, category).ToElements();
    }

    [Pure]
    public static IList<Element> GetTypes(this Document document, BuiltInCategory category, ElementFilter filter)
    {
        return CollectTypes(document, category, filter).ToElements();
    }

    [Pure]
    public static IList<Element> GetTypes(this Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        return CollectTypes(document, category, filters).ToElements();
    }

    [Pure]
    public static IList<Element> GetTypes(this Document document)
    {
        return CollectTypes(document).ToElements();
    }

    [Pure]
    public static IList<Element> GetTypes(this Document document, ElementFilter filter)
    {
        return CollectTypes(document, filter).ToElements();
    }

    [Pure]
    public static IList<Element> GetTypes(this Document document, IEnumerable<ElementFilter> filters)
    {
        return CollectTypes(document, filters).ToElements();
    }

    private static void ApplyFilters(FilteredElementCollector elements, IEnumerable<ElementFilter> filters)
    {
        foreach (var elementFilter in filters)
        {
            elements.WherePasses(elementFilter);
        }
    }

    private static FilteredElementCollector CollectInstances(Document document)
    {
        return new FilteredElementCollector(document).WhereElementIsNotElementType();
    }

    private static FilteredElementCollector CollectInstances(Document document, BuiltInCategory category)
    {
        return CollectInstances(document).OfCategory(category);
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementFilter filter)
    {
        return CollectInstances(document).WherePasses(filter);
    }

    private static FilteredElementCollector CollectInstances(Document document, IEnumerable<ElementFilter> filters)
    {
        var elements = CollectInstances(document);
        ApplyFilters(elements, filters);
        return elements;
    }

    private static FilteredElementCollector CollectInstances(Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectInstances(document, category).WherePasses(filter);
    }

    private static FilteredElementCollector CollectInstances(Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        var elements = CollectInstances(document, category);
        ApplyFilters(elements, filters);
        return elements;
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementId viewId)
    {
        return new FilteredElementCollector(document, viewId).WhereElementIsNotElementType();
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementId viewId,
        BuiltInCategory category)
    {
        return CollectInstances(document, viewId).OfCategory(category);
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementId viewId, ElementFilter filter)
    {
        return CollectInstances(document, viewId).WherePasses(filter);
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementId viewId,
        IEnumerable<ElementFilter> filters)
    {
        var elements = CollectInstances(document, viewId);
        ApplyFilters(elements, filters);
        return elements;
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementId viewId,
        BuiltInCategory category, ElementFilter filter)
    {
        return CollectInstances(document, viewId, category).WherePasses(filter);
    }

    private static FilteredElementCollector CollectInstances(Document document, ElementId viewId,
        BuiltInCategory category, IEnumerable<ElementFilter> filters)
    {
        var elements = CollectInstances(document, viewId, category);
        ApplyFilters(elements, filters);
        return elements;
    }

    private static FilteredElementCollector CollectTypes(Document document)
    {
        return new FilteredElementCollector(document).WhereElementIsElementType();
    }

    private static FilteredElementCollector CollectTypes(Document document, BuiltInCategory category)
    {
        return CollectTypes(document).OfCategory(category);
    }

    private static FilteredElementCollector CollectTypes(Document document, ElementFilter filter)
    {
        return CollectTypes(document).WherePasses(filter);
    }

    private static FilteredElementCollector CollectTypes(Document document, IEnumerable<ElementFilter> filters)
    {
        var elements = CollectTypes(document);
        ApplyFilters(elements, filters);
        return elements;
    }

    private static FilteredElementCollector CollectTypes(Document document, BuiltInCategory category,
        ElementFilter filter)
    {
        return CollectTypes(document, category).WherePasses(filter);
    }

    private static FilteredElementCollector CollectTypes(Document document, BuiltInCategory category,
        IEnumerable<ElementFilter> filters)
    {
        var elements = CollectTypes(document, category);
        ApplyFilters(elements, filters);
        return elements;
    }
}