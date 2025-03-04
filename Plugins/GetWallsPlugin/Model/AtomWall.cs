using Autodesk.Revit.DB;

namespace GetWallsPlugin.Model;

public class AtomWall
{
    public ElementId Id { get; }
    public string Name { get; }

    public AtomWall(ElementId id, string name)
    {
        Id = id;
        Name = name;
    }
}