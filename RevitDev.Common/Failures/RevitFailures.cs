using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using Autodesk.Revit.DB;

namespace RevitDev.Common.Failures;

public static class RevitFailures
{
    [Pure]
    public static Dictionary<Guid, string> GetAllFailures()
    {
        var dict = new Dictionary<Guid, string>();

        var type = typeof(BuiltInFailures);

        foreach (var nestedType in type.GetNestedTypes(BindingFlags.Public | BindingFlags.Static))
        {
            foreach (var property in nestedType.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                var id = property.GetValue(null) as FailureDefinitionId;

                if (id != null)
                {
                    var guid = id.Guid;

                    var name = $"BuiltInFailures.{nestedType.Name}.{property.Name}";

                    dict.Add(guid, name);
                }
            }
        }

        return dict;
    }
}