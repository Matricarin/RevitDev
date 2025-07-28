using Autodesk.Revit.DB;

namespace RevitDev.Common.Helpers;

public class FamilyLoadOptions : IFamilyLoadOptions
{
    private readonly bool _isOverWrite;

    public FamilyLoadOptions(bool isOverWrite = true)
    {
        _isOverWrite = isOverWrite;
    }

    public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
    {
        overwriteParameterValues = _isOverWrite;
        return true;
    }

    public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source,
        out bool overwriteParameterValues)
    {
        source = FamilySource.Family;
        overwriteParameterValues = true;
        return true;
    }
}