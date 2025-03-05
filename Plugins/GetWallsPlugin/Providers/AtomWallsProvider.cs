using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using GetWallsPlugin.Extensions;
using GetWallsPlugin.Model;

namespace GetWallsPlugin.Providers;

public class AtomWallsProvider
{
    private readonly FilteredElementCollector _collector;
    public AtomWallsProvider(Document? document)
    {
        if (document.IsNull())
        {
            throw new NullReferenceException();
        }

        _collector = new FilteredElementCollector(document);
    }
    
    public IEnumerable<AtomWall> GetAtomWalls()
    {
        using var enumerator = _collector.OfClass(typeof(Wall)).GetEnumerator();
        return enumerator.ToIEnumerable<AtomWall>();
    }
}