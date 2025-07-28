using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using RevitDev.Common.Helpers;

namespace RevitDev.Common.Extensions;

public static class FamilyExtensions
{
    public static void AddFamilyParameters(this IEnumerable<Family> families, Document doc,
        IEnumerable<ExternalDefinition> parameters)
    {
        var parametersList = parameters.ToList();
        foreach (var family in families)
        {
            var familyDoc = doc.EditFamily(family);
            using (var trans = new Transaction(familyDoc, "Добавление параметров в семейство"))
            {
                trans.Start();

                var fm = familyDoc.FamilyManager;
                foreach (var parameter in parametersList)
                {
                    if (fm.get_Parameter(parameter.Name) == null)
                    {
                        fm.AddParameter(parameter, BuiltInParameterGroup.INVALID, true);
                    }
                }

                trans.Commit();
            }

            familyDoc.LoadFamily(doc, new FamilyLoadOptions());
        }
    }
}