using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using RevitDev.Common.Helpers.Comparers;

namespace RevitDev.Common.Extensions;

public static class DocumentExtensions
{
    private const BuiltInCategory GenericModelCategory = BuiltInCategory.OST_GenericModel;

    public static void CloseLinkedDocument(this Document rootDoc, Document linkedDocument, bool isSynchronized = false)
    {
        var linkType = rootDoc.GetLinkType(linkedDocument.Title);
        if (linkType == null)
        {
            return;
        }

        var transactOptions = new TransactWithCentralOptions();
        var syncOptions = new SynchronizeWithCentralOptions();

        var relOpt = new RelinquishOptions(true);
        syncOptions.SetRelinquishOptions(relOpt);

        try
        {
            if (isSynchronized)
            {
                linkedDocument.SynchronizeWithCentral(transactOptions, syncOptions);
            }

            linkedDocument.Close(true);
        }
        catch
        {
            // Подавление исключений
        }

        linkType.Reload();
    }

    [Pure]
    public static DirectShape CreateDirectShape(this Document document, IEnumerable<GeometryObject> geometryObjects,
        BuiltInCategory builtInCategory = GenericModelCategory)
    {
        var categoryId = new ElementId(builtInCategory);
        var ds = DirectShape.CreateElement(document, categoryId);
        ds.SetShape(new List<GeometryObject>(geometryObjects));
        ds.SetName(ds.Category.Name);
        return ds;
    }

    [Pure]
    public static DirectShape CreateDirectShape(this Document document, GeometryObject geometryObject,
        BuiltInCategory builtInCategory = GenericModelCategory)
    {
        return CreateDirectShape(document, new[] { geometryObject }, builtInCategory);
    }

    [Pure]
    public static DirectShape CreateDirectShape(this Document document, DirectShapeType directShapeType,
        Transform? transform = null)
    {
        transform = transform ?? Transform.Identity;
        var directShape = DirectShape.CreateElementInstance(document, directShapeType.Id, directShapeType.Category.Id,
            directShapeType.GetDefinitionId(), transform);
        directShape.SetName(directShape.Category.Name);
        return directShape;
    }

    [Pure]
    public static DirectShapeType CreateDirectShapeType(this Document document,
        IEnumerable<GeometryObject> geometryObjects, string? typeName = null,
        BuiltInCategory builtInCategory = GenericModelCategory)
    {
        if (string.IsNullOrWhiteSpace(typeName))
        {
            typeName = Category.GetCategory(document, builtInCategory).Name;
        }

        var directShapeType = DirectShapeType.Create(document, typeName, new ElementId(builtInCategory));
        directShapeType.SetShape(new List<GeometryObject>(geometryObjects));
        DirectShapeLibrary.GetDirectShapeLibrary(document)
            .AddDefinitionType(directShapeType.GetDefinitionId(), directShapeType.Id);

        return directShapeType;
    }

    [Pure]
    public static DirectShapeType CreateDirectShapeType(this Document document, GeometryObject geometryObject,
        string? typeName = null, BuiltInCategory builtInCategory = GenericModelCategory)
    {
        return CreateDirectShapeType(document, new[] { geometryObject }, typeName, builtInCategory);
    }

    [Pure]
    public static ICollection<ElementId> DeleteDirectShape(this Document document,
        BuiltInCategory builtInCategory = GenericModelCategory)
    {
        var elementIds = document.GetInstanceIds(builtInCategory, new ElementClassFilter(typeof(DirectShape)));
        return document.Delete(elementIds);
    }

    [Pure]
    public static IEnumerable<int> GetCategoriesIds(this Document doc, IEnumerable<int> excludeCategories,
        bool includeSubCategories = true)
    {
        return doc.GetCategoriesIdsIEnumerable(includeSubCategories)
            .Except(excludeCategories)
            .Distinct()
            .ToList();
    }

    [Pure]
    public static RevitLinkType? GetLinkType(this Document rootDoc, string linkedDocTitle)
    {
        return new FilteredElementCollector(rootDoc)
                .OfCategory(BuiltInCategory.OST_RvtLinks)
                .OfClass(typeof(RevitLinkType))
                .FirstOrDefault(lt => linkedDocTitle.Equals(Path.GetFileNameWithoutExtension(lt.Name))) as
            RevitLinkType;
    }

    [Pure]
    public static Document? GetOpenedLinkedDocument(this Document rootDoc, string linkedDocTitle)
    {
        var linkedDoc = rootDoc.Application.Documents
            .Cast<Document>()
            .FirstOrDefault(doc => doc.Title.Equals(linkedDocTitle));
        if (linkedDoc == null)
        {
            return null;
        }

        if (!linkedDoc.IsLinked)
        {
            return linkedDoc;
        }

        var linkType = rootDoc.GetLinkType(linkedDocTitle);
        if (linkType == null)
        {
            return null;
        }

        var fileName = string.Empty;
        ModelPath? modelPath = null;

        if (linkedDoc.IsWorkshared)
        {
            modelPath = linkedDoc.GetWorksharingCentralModelPath();
        }

        if (modelPath == null
            || modelPath.Empty)
        {
            fileName = linkedDoc.PathName;
        }

        linkType.Unload(null);

        Document? lDoc = null;
        try
        {
            lDoc = modelPath != null && !modelPath.Empty
                ? rootDoc.Application.OpenDocumentFile(modelPath, new OpenOptions())
                : rootDoc.Application.OpenDocumentFile(fileName);
        }
        catch
        {
            // Подавление исключений
        }

        return lDoc;
    }

    [Pure]
    public static string GetProjectPath(this Document doc)
    {
        ModelPath? modelPath = null;

        if (doc.IsWorkshared)
        {
            modelPath = doc.GetWorksharingCentralModelPath();
        }

        return modelPath == null || modelPath.Empty
            ? doc.PathName
            : ModelPathUtils.ConvertModelPathToUserVisiblePath(modelPath);
    }

    [Pure]
    public static IEnumerable<View> GetViews(this Document doc, IEnumerable<string> viewsNames, bool isOrder = true)
    {
        var views = new FilteredElementCollector(doc)
            .OfClass(typeof(ViewSheet))
            .Cast<ViewSheet>()
            .Where(sheet => viewsNames.Contains(sheet.Title));

        if (isOrder)
        {
            views = views.OrderBy(view => view.SheetNumber, new SemiNumericComparer());
        }

        return views;
    }

    [Pure]
    private static IEnumerable<int> GetCategoriesIdsIEnumerable(this Document doc,
        bool onlyAllowsBoundParameters = false,
        bool includeSubCategories = true)
    {
        foreach (Category category in doc.Settings.Categories)
        {
            if (onlyAllowsBoundParameters)
            {
                if (category.AllowsBoundParameters)
                {
                    yield return category.Id.GetIdValue();
                }
            }
            else
            {
                yield return category.Id.GetIdValue();
            }

            if (!includeSubCategories)
            {
                continue;
            }

            foreach (Category subCategory in category.SubCategories)
            {
                if (onlyAllowsBoundParameters)
                {
                    if (subCategory.AllowsBoundParameters)
                    {
                        yield return subCategory.Id.GetIdValue();
                    }
                }
                else
                {
                    yield return subCategory.Id.GetIdValue();
                }
            }
        }
    }
}