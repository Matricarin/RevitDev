using System;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using GetWallsPlugin.Providers;

namespace GetWallsPlugin;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class Plugin : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var uiDoc = commandData.Application;
        var doc = uiDoc.ActiveUIDocument.Document;
        var atomWallsProvider = new AtomWallsProvider(doc);
        var atomWalls = atomWallsProvider.GetAtomWalls();
        var outputInfo = string.Join(Environment.NewLine, atomWalls.Select(wall => $"{wall.Id} : {wall.Name}"));
        TaskDialog.Show("AtomWalls", outputInfo);
        return Result.Succeeded;
    }
}