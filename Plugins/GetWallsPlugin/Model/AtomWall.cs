using Autodesk.Revit.DB;

namespace GetWallsPlugin.Model;

public class AtomWall
{
    public ElementId Id { get; }
    public string Name { get; }

    public AtomWall(Wall wall)
    {
        Id = wall.Id;
        Name = wall.Name;
    }
}