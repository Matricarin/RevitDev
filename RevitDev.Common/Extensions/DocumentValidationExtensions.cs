using System.Diagnostics.Contracts;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Extensions;

public static class DocumentValidationExtensions
{
    [Pure]
    public static bool CanDeleteElement(this Element element)
    {
        return DocumentValidation.CanDeleteElement(element.Document, element.Id);
    }
}