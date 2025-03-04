using System;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace GetWallsPlugin;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class Plugin : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var uiDoc = commandData.Application;
        var doc = uiDoc.ActiveUIDocument.Document;
        var elementCollector = new FilteredElementCollector(doc);
        var allWalls = elementCollector.OfClass(typeof(Wall)).WhereElementIsNotElementType().ToElements();
        TaskDialog.Show("Walls: ",string.Join(Environment.NewLine, allWalls.Select(w => w.Name)) );
        return Result.Succeeded;
    }
}