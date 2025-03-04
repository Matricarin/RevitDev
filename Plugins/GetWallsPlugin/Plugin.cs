using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace GetWallsPlugin;

[Transaction(TransactionMode.Manual)]
public class Plugin : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        throw new System.NotImplementedException();
    }
}