using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class DirectShapeExtensions
{
    public static DirectShape Create(this DirectShapeType directShapeType, Transform? transform = null)
    {
        return directShapeType.Document.CreateDirectShape(directShapeType, transform);
    }

    public static string GetDefinitionId(this DirectShapeType directShapeType)
    {
        return directShapeType.Id.ToString();
    }
}