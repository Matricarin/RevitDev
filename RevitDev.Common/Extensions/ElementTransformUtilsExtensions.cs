using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class ElementTransformUtilsExtensions
{
    [Pure]
    public static bool CanBeMirrored(this Element element)
    {
        return ElementTransformUtils.CanMirrorElement(element.Document, element.Id);
    }

    [Pure]
    public static bool CanMirrorElements(this ICollection<ElementId> elementIds, Document document)
    {
        return ElementTransformUtils.CanMirrorElements(document, elementIds);
    }

    [Pure]
    public static ICollection<ElementId> Copy(this Element element, double deltaX, double deltaY, double deltaZ)
    {
        return ElementTransformUtils.CopyElement(element.Document, element.Id, new XYZ(deltaX, deltaY, deltaZ));
    }

    [Pure]
    public static ICollection<ElementId> Copy(this Element element, XYZ vector)
    {
        return ElementTransformUtils.CopyElement(element.Document, element.Id, vector);
    }

    [Pure]
    public static ICollection<ElementId> CopyElements(this ICollection<ElementId> elementsToCopy, View sourceView,
        View destinationView)
    {
        return ElementTransformUtils.CopyElements(sourceView, elementsToCopy, destinationView, null, null);
    }

    [Pure]
    public static ICollection<ElementId> CopyElements(this ICollection<ElementId> elementsToCopy,
        View sourceView,
        View destinationView,
        Transform additionalTransform,
        CopyPasteOptions options)
    {
        return ElementTransformUtils.CopyElements(sourceView, elementsToCopy, destinationView, additionalTransform,
            options);
    }

    [Pure]
    public static ICollection<ElementId> CopyElements(this ICollection<ElementId> elementsToCopy,
        Document sourceDocument, Document destinationDocument)
    {
        return ElementTransformUtils.CopyElements(sourceDocument, elementsToCopy, destinationDocument, null, null);
    }

    [Pure]
    public static ICollection<ElementId> CopyElements(this ICollection<ElementId> elementsToCopy,
        Document sourceDocument,
        Document destinationDocument,
        Transform transform,
        CopyPasteOptions options)
    {
        return ElementTransformUtils.CopyElements(sourceDocument, elementsToCopy, destinationDocument, transform,
            options);
    }

    [Pure]
    public static ICollection<ElementId> CopyElements(this ICollection<ElementId> elementsToCopy, Document document,
        XYZ translation)
    {
        return ElementTransformUtils.CopyElements(document, elementsToCopy, translation);
    }

    [Pure]
    public static Transform GetTransformFromViewToView(this View sourceView, View destinationView)
    {
        return ElementTransformUtils.GetTransformFromViewToView(sourceView, destinationView);
    }

    [Pure]
    public static Element Mirror(this Element element, Plane plane)
    {
        ElementTransformUtils.MirrorElement(element.Document, element.Id, plane);
        return element;
    }

    [Pure]
    public static ICollection<ElementId> MirrorElements(this ICollection<ElementId> elementsToMirror, Document document,
        Plane plane, bool mirrorCopies)
    {
        return ElementTransformUtils.MirrorElements(document, elementsToMirror, plane, mirrorCopies);
    }

    [Pure]
    public static Element Move(this Element element, double deltaX = 0d, double deltaY = 0d, double deltaZ = 0d)
    {
        ElementTransformUtils.MoveElement(element.Document, element.Id, new XYZ(deltaX, deltaY, deltaZ));
        return element;
    }

    [Pure]
    public static Element Move(this Element element, XYZ vector)
    {
        ElementTransformUtils.MoveElement(element.Document, element.Id, vector);
        return element;
    }

    [Pure]
    public static ICollection<ElementId> MoveElements(this ICollection<ElementId> elementsToMove, Document document,
        XYZ translation)
    {
        ElementTransformUtils.MoveElements(document, elementsToMove, translation);
        return elementsToMove;
    }

    [Pure]
    public static Element Rotate(this Element element, Line axis, double angle)
    {
        ElementTransformUtils.RotateElement(element.Document, element.Id, axis, angle);
        return element;
    }

    [Pure]
    public static ICollection<ElementId> RotateElements(this ICollection<ElementId> elementsToRotate, Document document,
        Line axis, double angle)
    {
        ElementTransformUtils.RotateElements(document, elementsToRotate, axis, angle);
        return elementsToRotate;
    }
}